using M64MM.Additions;
using M64MM.Utils.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.SettingsManager;

namespace M64MM.Utils
{
    public static class Core
    {
        public static StringBuilder AddonErrorsBuilder;
        public static List<Addon> moduleList = new List<Addon>();
        public static long BaseAddress;
        public static List<Animation> animList = new List<Animation>();
        public static List<CameraStyle> camStyles = new List<CameraStyle>();
        public static List<ColorCodeGS> colorCodeGamesharks = new List<ColorCodeGS>();
        public static Animation defaultAnimation;
        public static byte[] emptyWord = new byte[] { 0, 0, 0, 0 };
        public static SettingsGroup coreSettingsGroup;
        static bool _cameraFrozen = false;
        static bool _cameraSoftFrozen = false;

        public static bool PowerCamEnabled { get; set; }

        public static bool CameraFrozen
        {
            get
            {
                return _cameraFrozen;
            }
            private set { }
        }

        public static bool CameraSoftFrozen
        {
            get
            {
                return _cameraSoftFrozen;
            }
            private set { }
        }

        #region Events (internal use recommended)
        public static event EventHandler<int> LevelChanged;
        public static event EventHandler<Process[]> MoreThanOneEmuFound;
        public static event EventHandler EmulatorSelected;
        public static event EventHandler<bool> BaseAddressUpdate;
        #endregion

        // Settings related variables
        public static bool enableHotkeys;
        public static bool enableUpdates;

        // Timers
        public static Timer programTimer = new Timer();

        public static uint ingameTimer;
        public static uint previousFrame;

        static int _previousLevelID;
        public static int CurrentLevelID
        {
            get
            {
                int id = BitConverter.ToInt16(SwapEndian(ReadBytes(BaseAddress + 0x32DDFA, 2), 4), 0);
                if (id != _previousLevelID)
                {
                    UpdateCoreEntityAddress();
                    OnLevelChanged(id);
                }
                _previousLevelID = id;
                return id;
            }
            private set { }
        }

        public static byte[] CameraState
        {
            get
            {
                return SwapEndian(ReadBytes(BaseAddress + 0x33C848, 4), 4);
            }
            private set { }
        }

        // Animation Index
        public static short AnimationIndex
        {
            get
            {
                return BitConverter.ToInt16(SwapEndian(ReadBytes(BaseAddress + CoreEntityAddress + 0x3A, 2), 4), 0);
            }
            private set { }
        }

        public enum ModelStatus
        {
            NONE,
            CLASSIC,
            EMPTY,
            MOD,
            COMET
        }

        public static ModelStatus modelStatus = ModelStatus.NONE;

        #region Native methods and process related
        static Process emuProcess;
        public static bool StopProcessSearch;
        static IntPtr emuProcessHandle;
        const int PROCESS_ALL_ACCESS = 0x01F0FF;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, long nSize, ref long lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, long nSize, ref long lpNumberOfBytesWritten);

        public static bool IsEmuOpen
        {
            get
            {
                try
                {
                    return (emuProcess != null && !emuProcess.HasExited);
                }
                catch
                {
                    return false;
                }
            }
            private set { }
        }
        #endregion

        #region Composer related

        static uint _coreEntityAddress;

        public static uint CoreEntityAddress
        {
            get
            {
                return _coreEntityAddress;
            }
            private set { }
        }

        public static void UpdateCoreEntityAddress()
        {
            uint caughtA = BitConverter.ToUInt32(
            ReadBytes(BaseAddress + 0x33B1F8, 4), 0);
            uint caughtFilt = caughtA & 0x00FFFFFF;
            if (caughtA > 0)
            {
                if (caughtFilt != _coreEntityAddress)
                {
                    PerformCoreEntAddressChange(caughtFilt);
                }
                _coreEntityAddress = caughtFilt;
            }
            else
            {
                _coreEntityAddress = 0;
            }
        }

        public static short AnimationTimer
        {
            get
            {
                return (short)BitConverter.ToUInt16(
                    ReadBytes(BaseAddress + CoreEntityAddress + 0x42, sizeof(short)), 0);
            }
        }

        public static uint AnimDataAddress
        {
            get
            {
                uint addr = BitConverter.ToUInt32(
                ReadBytes(BaseAddress + CoreEntityAddress + 0x3C, 4), 0) & 0x00FFFFFF;
                return addr;
            }
        }

        public static bool ValidateAnimDataAddress()
        {
            return (AnimDataAddress > 0);
        }

        #endregion

        #region Settings related

        public static async void InitSettings()
        {
            bool settingsExist = File.Exists($"{Application.StartupPath}/config.json");
            if (settingsExist)
            {
                using (StreamReader rs = new StreamReader($"{Application.StartupPath}/config.json"))
                {
                    string jsonRead = await rs.ReadToEndAsync();
                    JSONToSettings(jsonRead);
                    coreSettingsGroup = GetSettingsGroup("core");
                    UpdateLocalVariables();
                }
            }
            else
            {
                coreSettingsGroup = GetSettingsGroup("core", true);
                coreSettingsGroup.SetSettingValue("enableHotkeys", true);
                coreSettingsGroup.SetSettingValue("enableUpdateCheck", true);
                UpdateLocalVariables();
                using (StreamWriter rw = new StreamWriter($"{Application.StartupPath}/config.json"))
                {
                    string settings = SettingsToJSON();
                    await rw.WriteAsync(settings);
                }
            }
        }

        public static async void SaveSettings()
        {
            using (FileStream fs = new FileStream($"{Application.StartupPath}/config.json", FileMode.Truncate))
            {
                StreamWriter rw = new StreamWriter(fs);
                await rw.FlushAsync();
                string settings = SettingsToJSON();
                await rw.WriteAsync(settings);
                rw.Close();
                rw.Dispose();
            }
            UpdateLocalVariables();
        }

        static void UpdateLocalVariables()
        {
            enableHotkeys = coreSettingsGroup.EnsureSettingValue<bool>("enableHotkeys");
            enableUpdates = coreSettingsGroup.EnsureSettingValue<bool>("enableUpdateCheck");
        }

        #endregion

        #region Animation related

        /// <summary>
        /// Writes the animation swap from oldAnimation to newAnimation
        /// </summary>
        /// <param name="oldAnimation"></param>
        /// <param name="newAnimation"></param>
        public static void WriteAnimationSwap(Animation oldAnimation, Animation newAnimation)
        {
            if (oldAnimation.Value == "" || newAnimation.Value == "")
            {
                throw new ArgumentException($"--Resources.invalidAnimSelected Invalid animation selected: {oldAnimation.Description} -> {newAnimation.Description}");
            }

            byte[] stuffToWrite = SwapEndian(StringToByteArray(newAnimation.Value), 4);
            long address = BaseAddress + 0x64040 + (oldAnimation.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
        }


        /// <summary>
        /// Returns the Animation index from the animList that the current animation has selected in memory.
        /// </summary>
        /// <param name="anim"></param>
        /// <returns></returns>
        public static int GetCurrentAnimationIndex(Animation anim)
        {
            long address = BaseAddress + 0x64040 + (anim.RealIndex + 1) * 8;
            byte[] currentAnim = SwapEndian(ReadBytes(address, 8), 4);
            string currentAnimValue = BitConverter.ToString(currentAnim).Replace("-", "");

            int index = animList.FindIndex(x => x.Value == currentAnimValue);
            return index;
        }

        public static void WriteAnimationReset(Animation anim)
        {
            if (anim.Value == "")
            {
                throw new ArgumentException($"--Resources.invalidAnimSelected Invalid animation selected: {anim.Description}");
            }

            byte[] stuffToWrite = SwapEndian(StringToByteArray(anim.Value), 4);
            long address = BaseAddress + 0x64040 + (anim.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
        }

        public static bool LoadAnimationData()
        {
            try
            {
                using (StreamReader sr = new StreamReader($"{Application.StartupPath}/animation_data.txt"))
                {
                    while (!sr.EndOfStream && sr.Peek() != 0)
                    {
                        string rawLine = sr.ReadLine();
                        string[] splitLine = rawLine.Trim().Split('|');

                        Animation anim = new Animation
                        {
                            Value = splitLine[0],
                            Description = splitLine[1],
                            RealIndex = int.Parse(splitLine[2])
                        };

                        animList.Add(anim);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static string[] GetAnimationNames()
        {
            return animList.Select(x => x.Description).ToArray();
        }

        #endregion

        #region Camera related

        public static void ToggleCameraFreeze()
        {
#if DEBUG
            Debug.WriteLine("Camera freeze toggled");
#endif
            if (!CameraFrozen)
            {
                _cameraFrozen = true;
                byte[] data = { 0x80 };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }
            else
            {
                _cameraFrozen = false;
                byte[] data = { 0x00 };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }

        }

        public static void ToggleCameraSoftFreeze()
        {
            if (!CameraSoftFrozen)
            {
                _cameraSoftFrozen = true;
                WriteBytes(BaseAddress + 0x33B204, BitConverter.GetBytes(0x8001C520));
            }
            else
            {
                _cameraSoftFrozen = false;
                WriteBytes(BaseAddress + 0x33B204, BitConverter.GetBytes(0x8033C520));
            }

        }

        public static bool LoadCameraData()
        {
            try
            {
                using (StreamReader sr = new StreamReader($"{Application.StartupPath}/camera_data.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string rawLine = sr.ReadLine().Trim();
                        string[] splitLine = rawLine.Split('|');
                        CameraStyle style = new CameraStyle
                        {
                            Value = byte.Parse(splitLine[0], NumberStyles.HexNumber),
                            Name = splitLine[1]
                        };
                        camStyles.Add(style);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void PowercamHack()
        {
            // Animation index is -1 when the game is transitioning which is just about perfect
            // Only override camera reset (flag 0x08) when the game is transitioning
            // Works before entering Castle Grounds and literally any level transition
            if (PowerCamEnabled && AnimationIndex == -1)
            {
                // Glitchy: AVOID CAMERA FROM RESETTING (Flag 0x08)
                WriteBytes(BaseAddress + 0x33C84B, new byte[] { (byte)(CameraState[0] & ~(0x8)) });
            }

            if (CameraFrozen && ((CameraState[0] & 0x80) != 0x20))
            {
                // Glitchy: Program says camera is frozen but game says otherwise
                // OK, in that case let's just enable the flag back
                byte[] data = { (byte)(CameraState[0] | 0x80) };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }
            //Don't overwrite the camera state if we're in non-bugged first-person
            else if (CameraFrozen && ((CameraState[0] & 0x20) == 0x20))
            {
                // Glitchy: Camera status is actually a flag, which means we just need to take away
                // the first person flag to restore, so it doesn't do a false alarm on newly
                // loaded emulator instances (freezing camera Wayyyyyyyy up in the sky)
                byte[] data = { (byte)(CameraState[0] & ~(0x20)) };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }
        }

        #endregion

        #region Reading
        public static byte[] ReadBytes(long address, long size)
        {
            IntPtr ptr = new IntPtr(address);
            byte[] buffer = new byte[size];
            long bytesRead = 0;

            ReadProcessMemory(emuProcessHandle, ptr, buffer, size, ref bytesRead);
            return buffer;
        }
        #endregion

        #region Writing
        public static void WriteBytes(long address, byte[] data, bool swap = false)
        {
            IntPtr ptr = new IntPtr(address);
            long size = data.LongLength;
            long bytesWritten = 0;

            if (swap)
            {
                data = SwapEndian(data, 4);
            }

            WriteProcessMemory(emuProcessHandle, ptr, data, size, ref bytesWritten);
        }

        public static void WriteBatchBytes(long[] addresses, byte[] data, bool useBase, bool swap = false)
        {
            long baseAddr = useBase ? BaseAddress : 0;
            foreach (long addr in addresses)
            {
                WriteBytes(baseAddr + addr, data, swap);
            }
        }
        #endregion

        #region Event methods

        static void OnLevelChanged(int levelID)
        {
            LevelChanged?.Invoke(null, levelID);
        }

        static void OnMoreThanMoreEmuFound(Process[] plist)
        {
            MoreThanOneEmuFound?.Invoke(null, plist);
        }

        static void OnEmulatorSelected()
        {
            EmulatorSelected?.Invoke(null, null);
        }

        #endregion

        /// <summary>
        /// Find the emulator we're going to hook to.
        /// </summary>
        public static void FindEmuProcess()
        {
            if (IsEmuOpen)
            {
                return;
            }
            List<Process> emulators = Process.GetProcesses().Where(x => x.ProcessName.Contains("Project64")).ToList();

            if (emulators.Count > 1)
            {
                #if DEBUG
                Debug.WriteLine($"Found more than one PJ64: {emulators.Count}");
                #endif
                StopProcessSearch = true;
                OnMoreThanMoreEmuFound(emulators.ToArray());
                return;
            }

            if (emulators.Count != 0)
            {
                StopProcessSearch = true;
                SelectEmuProcess(emulators[0]);
                return;
            }

            StopProcessSearch = false;

        }
        public static void SelectEmuProcess(Process proc)
        {
            emuProcess = proc;
            emuProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, false, emuProcess.Id);
            StopProcessSearch = false;
            OnEmulatorSelected();
        }
        public static void ResetEmuProcess()
        {
            StopProcessSearch = false;
            emuProcess = null;
            emuProcessHandle = IntPtr.Zero;
        }

        /// <summary>
        /// Find the base address. Big-endian Mario 64 ROMs always start with the same 4 bytes.
        /// </summary>
        public static void FindBaseAddress()
        {
            long start = 0x20000000;
            long stop = 0xF0000000;
            long step = 0x10000;

            uint value;
            //Check if the old base address is still valid
            if (BaseAddress > 0)
            {
                value = BitConverter.ToUInt32(ReadBytes(BaseAddress, sizeof(uint)), 0);

                if (value == 0x3C1A8032) return;
            }

            for (long scanAddress = start; scanAddress < stop - step; scanAddress += step)
            {
                value = BitConverter.ToUInt32(ReadBytes(scanAddress, sizeof(uint)), 0);

                if (value == 0x3C1A8032)
                {
                    //Speed up the check for the game since the base address was found
                    programTimer.Interval = 100;
                    BaseAddress = scanAddress;
                    return;
                }
            }

            //Slow down the check so if the program is open we don't overload the CPU
            programTimer.Interval = 1000;
            //If we don't find anything, reset the base address to 0
            BaseAddress = 0;

        }

        /// <summary>
        /// Gets the Virtual Address of the Segmented Address. Works (almost) identical to the equivalent in-game function.
        /// SM64 has a table of segments in RAM that has pointers to segments from Segment 00 to Segment 1F.
        /// </summary>
        /// <param name="address">Segmented address to turn into Virtual</param>
        /// <param name="useBase">If the Base Address of the Emulator should be added to the returned address (defaults to true)</param>
        /// <returns>The Virtual Address of the given Segmented Address</returns>
        // This exists because it would appear some ROMs change the RAM location of Bank 04, effectively breaking color codes.
        public static long SegmentedToVirtual(uint address, bool useBase = true)
        {
            byte[] byteArray = BitConverter.GetBytes(address);
            if (byteArray.Length == 4)
            {
                uint segment = address >> 24;
                uint segmentedOffset = address & 0x00FFFFFF;
                if (segment <= 0x1F && segment >= 0)
                {
                    long segmentedBase = (BitConverter.ToUInt32(
                    ReadBytes(BaseAddress + 0x33B400 + segment * 4, 4), 0));
                    //MinValue of int just so happens to be 0x80000000 so it's perfect
                    return segmentedBase + segmentedOffset + (useBase ? BaseAddress : 0);
                }
                else
                {
                    throw new ArgumentException("Segments range from 00 to 1F.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid address");
            }
        }

        #region Addon loading related

        public static void LoadAddonsFromFolder(string path = "")
        {
            // TODO: Add the different path loading
            // NO SANDBOX
            // AppDomains are incredibly messy
            // Let's just hope you don't download anything suspicious
            // HEAVILY considering moving back the Addon namespace back to .netFX

            AddonErrorsBuilder = new StringBuilder();
            _ = new ToolStripMenuItem("Addons");
            try
            { // Loading DLLs from the desired path location (If not, .\Addons)
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = Application.StartupPath + "\\Addons";
                }

                DirectoryInfo d = new DirectoryInfo(path);
                foreach (FileInfo file in d.GetFiles("*.dll"))
                { // For each DLL
                    try // If getting all types fails for some reason (Ex: cannot load required assembly)...
                    {
                        Assembly assmb;
                        try
                        {
                            // If the DLL is invalid or has no assembly (Not .NET?) this will throw an exception
                            // Checking if it has an assembly first will allow us to just skip it.
                            assmb = Assembly.LoadFrom(file.FullName);
                        }
                        catch (Exception ex)
                        {
                            AddonErrorsBuilder.AppendFormat("{0} [LOAD WARNING] - DLL {1} does not appear to have assembly info or is a corrupted DLL.\nAddon loading for this DLL has been skipped. If this is not an addon DLL but a native dependency, this is normal.\nThese warnings can be suppressed in a future.\n--------\n", DateTime.Now.ToLongTimeString(), file.Name);
                            continue;
                        }
                       
                        Type[] classes = assmb.GetTypes();
                        foreach (Type typ in classes)
                        {
                            if (typ.GetInterface("IModule") != null)
                            { // If type implements interface IModule
                                IModule mod = (IModule)assmb.CreateInstance(typ.FullName); // Instance the IModule
                                Addon neoAddon = new Addon(mod, mod.SafeName, FileVersionInfo.GetVersionInfo(file.FullName).FileVersion.ToString(), mod.Description, mod.AddonIcon ?? Resources.defaultAddonIcon); // Instance Addon
                                moduleList.Add(neoAddon); // Add addon to the plugins list
                            }
                        }
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        AddonErrorsBuilder.AppendFormat("{0} [LOAD ERROR] - Error while loading addon from DLL {1}. Exception: {2}\nAre all the dependencies met?\n--------\n", DateTime.Now.ToLongTimeString(), ex.Types[0].Module.ToString(), ex.Message);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Addons");
                MessageBox.Show("No addons folder was present, addons folder created.\nMake sure you're running M64MM from an extracted folder.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static List<ToolCommand> GetAddonCommands(Addon addon)
        {
            IModule mod = addon.Module;
            List<ToolCommand> tc_list = mod.GetCommands(); // Get list of custom commands
            if (tc_list != null)
            {
                return tc_list;
            }
            else
            {
                // Return a Nothing instead of just throwing null
                // Here only for a future
                return new List<ToolCommand>();
            }
        }

        #endregion


        #region Color Code related
        public static void LoadColorCodeRepo()
        {
            if (!Directory.Exists(Application.StartupPath + "\\Colorcodes"))
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Colorcodes");
                    return;
                }
                catch (Exception)
                {
                    return;
                    // TODO: Make it add exception to warnings list
                }
            }
            colorCodeGamesharks.Clear();
            DirectoryInfo d = new DirectoryInfo(Application.StartupPath + "\\Colorcodes");
            foreach (FileInfo file in d.GetFiles("*.txt"))
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    try
                    {
                        ColorCodeGS ccG = new ColorCodeGS
                        {
                            Name = Path.GetFileNameWithoutExtension(file.FullName),
                            Gameshark = Looks.ValidateCC(sr.ReadToEnd().Split('\n'))
                        };
                        colorCodeGamesharks.Add(ccG);

                    }
                    catch (Exception)
                    {
                        continue;
                        // Skip this CC
                        // Make the warning object so not only addons but CCs too can have "issue checking"
                    }
                }
            }
        }
        #endregion

        //TODO: Deprecate. There should be no need for this
        /// <summary>
        /// Validates a model in Bank 04 and returns which kind of model is it.
        /// </summary>
        /// <param name="updateGlobal">Update the global variable?</param>
        /// <returns>The model type</returns>
        public static ModelStatus ValidateModel(bool updateGlobal = true)
        {
            byte[] Color1;
            byte[] Color2;
            byte[] Shadow1;
            byte[] FinalSetOfBytes;
            ModelStatus ms = ModelStatus.NONE;

            Color1 = SwapEndian(ReadBytes(SegmentedToVirtual(0x04000050, true), 4), 4);
            Color2 = SwapEndian(ReadBytes(SegmentedToVirtual(0x04000060, true), 4), 4);
            Shadow1 = SwapEndian(ReadBytes(SegmentedToVirtual(0x04000058, true), 4), 4);
            FinalSetOfBytes = SwapEndian(ReadBytes(SegmentedToVirtual(0x0400005C, true), 4), 4);

            //If the color data is all zeros
            if ((BitConverter.ToInt32(Color1, 0) == 0) &&
                (BitConverter.ToInt32(Color2, 0) == 0) &&
                (BitConverter.ToInt32(Shadow1, 0) == 0) &&
                (BitConverter.ToInt32(FinalSetOfBytes, 0) == 0))
            {
                ms = ModelStatus.EMPTY;
            }

            //If the color data is not RR GG BB *00* RR GG BB *00* XX YY ZZ *00* *00 00 00 00*
            if ((Color1[3] != 0)
                || (Color2[3] != 0)
                || (Shadow1[3] != 0)
                || (BitConverter.ToInt32(FinalSetOfBytes, 0) != 0))
            {
                ms = ModelStatus.MOD;
            }

            // CometROMs are different now.

            //If all data is okay but then final bytes equal zero
            if ((BitConverter.ToInt32(Color1, 0) != 0) &&
                (BitConverter.ToInt32(Color2, 0) != 0) &&
                (BitConverter.ToInt32(Shadow1, 0) != 0) &&
                (BitConverter.ToInt32(FinalSetOfBytes, 0) == 0))
            {
                ms = ModelStatus.CLASSIC;
            }

            if (updateGlobal)
            {
                modelStatus = ms;
            }
            return ms;
        }

        /// <summary>
        /// Gets a list of animation strings by looking within its name.
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>An AutoCompleteStringCollection containing the top 3 matches.</returns>
        public static AutoCompleteStringCollection GetQueriedAnimations(string query = "")
        {
            List<Animation> alist = animList.Where(a => a.Description.Contains(query)).Take(3).ToList();
            AutoCompleteStringCollection results = new AutoCompleteStringCollection();
            foreach (Animation anim in alist)
            {
                results.Add(anim.Description);
            }
            return results;
        }

        /// <summary>
        /// Transforms a hex string into a byte array.
        /// </summary>
        /// <param name="hex">Hexadecimal string</param>
        /// <returns>A byte array from the string provided</returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        /// <summary>
        /// Swaps endianness of the given Byte array.
        /// </summary>
        /// <param name="array">The Byte array to swap</param>
        /// <param name="wordSize">Word size</param>
        /// <returns>A byteswapped Byte array</returns>
        public static byte[] SwapEndian(byte[] array, int wordSize)
        {
            byte[] byteArray = new byte[array.Length];
            array.CopyTo(byteArray, 0);
            for (int x = 0; x < byteArray.Length / wordSize; x++)
            {
                Array.Reverse(byteArray, x * wordSize, wordSize);
            }

            return byteArray;
        }

        #region Plugin Execution
        /// <summary>
        /// Is executed when Base Address updates from an older value to another.
        /// </summary>
        public async static void PerformBaseAddrUpd()
        {
            for (int i = 0; i < moduleList.Count(); i++)
            {
                if (moduleList[i].Active == true)
                {
                    try
                    {
                        await Task.Run(() => moduleList[i].Module.OnBaseAddressFound());
                        continue;
                    }
                    catch (Exception e)
                    {
                        AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing BaseAddressFound from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                        MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                        moduleList[i].Active = false;
                    }
                }
            }
        }

        public async static void PerformCoreEntAddressChange(uint addr)
        {
            for (int i = 0; i < moduleList.Count(); i++)
            {
                if (moduleList[i].Active == true)
                {
                    try
                    {
                        await Task.Run(() => moduleList[i].Module.OnCoreEntAddressChange(addr));
                        continue;
                    }
                    catch (Exception e)
                    {
                        AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing OnCoreEntAddressChange from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                        MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                        moduleList[i].Active = false;
                    }
                }
            }
        }

        /// <summary>
        /// Is executed when Base Address is zero.
        /// </summary>
        public async static void PerformBaseAddrZero()
        {
            for (int i = 0; i < moduleList.Count(); i++)
            {
                if (moduleList[i].Active == true)
                {
                    try
                    {
                        await Task.Run(() => moduleList[i].Module.OnBaseAddressZero());
                        continue;
                    }
                    catch (Exception e)
                    {
                        AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing BaseAddressZero from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                        MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                        moduleList[i].Active = false;
                    }
                }
            }
        }

        /// <summary>
        /// Is executed every in-game frame. (Prone to FPS drops)
        /// </summary>
        public async static void PerformUpdate()
        {
            while (true)
            {
                //Ingame timer update
                // Using VI timer instead of Input timer (Input timer stops counting when transitioning)
                ingameTimer = ReadBytes(BaseAddress + 0x32D580, 2)[0];
                //If there's a level loaded EVEN if there's no model
                if (modelStatus != ModelStatus.NONE)
                {
                    // a VI is executed @ 2x the framerate
                    // NTSC VI: 60hz = 30fps (technically 29.970 but we don't mess with that.)
                    // PAL VI: 50hz = 25fps
                    // hahaha did you know NTSC used to be dubbed "Never The Same Color"
                    if (ingameTimer > previousFrame + 1)
                    {
                        //Set new value
                        previousFrame = ingameTimer;
                        //Ingame timer is a variable that INCREMENTS every frame in game. In case our previous snapshot of said value is above the timer:
                        for (int i = 0; i < moduleList.Count(); i++)
                        {
                            //Unity 1996
                            if (moduleList[i].Active == true)
                            {
                                try
                                {
                                    moduleList[i].Module.Update();
                                    continue;
                                }
                                catch (Exception e)
                                {
                                    AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing Update from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                                    MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                                    moduleList[i].Active = false;
                                }

                            }
                        }
                    }
                    else if (ingameTimer <= previousFrame)
                    {
                        previousFrame = ingameTimer;
                        ingameTimer = ReadBytes(BaseAddress + 0x32D580, 2)[0];
                    }
                }
                // zzz
                await Task.Delay(10);
            }
        }
        #endregion

        public static bool GetKey(Keys vKey) => GetAsyncKeyState(vKey) != 0;
    }
}