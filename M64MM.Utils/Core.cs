using System;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using M64MM.Additions;

namespace M64MM.Utils
{
    //TODO: Move M64MM.Utils to a dotnetStandard project, to reduce .NETFX dependency
    public static class Core
    {
        public static StringBuilder AddonErrorsBuilder;
        public static List<Addon> moduleList = new List<Addon>();
        public static long BaseAddress;
        public static List<Animation> animList;
        public static List<CameraStyle> camStyles;
        public static Animation defaultAnimation;
        public static byte[] emptyWord = new byte[] { 0, 0, 0, 0 };
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
        public static UInt32 ingameTimer;
        public static UInt32 previousFrame;
        public static int CurrentLevelID => BitConverter.ToInt16(SwapEndian(ReadBytes(BaseAddress + 0x32DDFA, 2), 4), 0);
        public enum ModelStatus
        {
            NONE,
            VANILLA,
            EMPTY,
            MODDED,
            COMET
        }
        public static ModelStatus modelStatus = ModelStatus.NONE;
        static Process emuProcess;
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
                byte[] val = ReadBytes(baseAddr + addr, 1);
                WriteBytes(baseAddr + addr, data, swap);
            }
        }
        #endregion


        public static void FindEmuProcess()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                // TODO: Mupen support
                if (proc.ProcessName.Contains("Project64"))
                {
                    emuProcess = proc;
                    emuProcessHandle = OpenProcess(PROCESS_ALL_ACCESS, false, emuProcess.Id);
                    break;
                }
            }
        }


        public static void FindBaseAddress()
        {
            uint value = 0;

            long start = 0x20000000;
            long stop = 0x60000000;
            long step = 0x10000;

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
                    BaseAddress = scanAddress;
                    return;
                }
            }

            //If we don't find anything, reset the base address to 0
            BaseAddress = 0;

        }

        public static ModelStatus ValidateModel(bool updateGlobal = true)
        {
            byte[] Color1;
            byte[] Color2;
            byte[] Shadow1;
            byte[] FinalSetOfBytes;
            ModelStatus ms = ModelStatus.NONE;

            Color1 = SwapEndian(ReadBytes(BaseAddress + 0x07EC70, 4), 4);
            Color2 = SwapEndian(ReadBytes(BaseAddress + 0x07EC80, 4), 4);
            Shadow1 = SwapEndian(ReadBytes(BaseAddress + 0x07EC78, 4), 4);
            FinalSetOfBytes = SwapEndian(ReadBytes(BaseAddress + 0x07EC7C, 4), 4);

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
                ms = ModelStatus.MODDED;
            }

            //If the final bytes spell "CMT"
            //Fourth byte is for the CometROM version.
            //More checks will be done when a ROM is a CometROM.
            if ((FinalSetOfBytes[0] == 0x43
                && FinalSetOfBytes[1] == 0x4D
                && FinalSetOfBytes[2] == 0x54))
            {
                ms = ModelStatus.COMET;
            }

            //If all data is okay but then final bytes equal zero
            if ((BitConverter.ToInt32(Color1, 0) != 0) &&
                (BitConverter.ToInt32(Color2, 0) != 0) &&
                (BitConverter.ToInt32(Shadow1, 0) != 0) &&
                (BitConverter.ToInt32(FinalSetOfBytes, 0) == 0))
            {
                ms = ModelStatus.VANILLA;
            }

            if (updateGlobal)
            {
                modelStatus = ms;
            }
            return ms;
        }

        public static AutoCompleteStringCollection GetQueriedAnimations(string query = "")
        {
            List<Animation> alist = animList.Where(a => a.Description.Contains(query)).Take(3).ToList();
            AutoCompleteStringCollection results = new AutoCompleteStringCollection();
            foreach(Animation anim in alist)
            {
                results.Add(anim.Description);
            }
            return results;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

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

        public async static void performBaseAddrUpd()
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
                        AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing Update from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                        MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                        moduleList[i].Active = false;
                    }

                }
            }
        }

        public async static void performBaseAddrZero()
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
                        AddonErrorsBuilder.AppendFormat("{0} [RUNTIME ERROR] - Error while executing Update from Addon {1}. Exception: {2}\nAddon has been disabled.\n--------\n", DateTime.Now.ToLongTimeString(), moduleList[i].Name, e.Message);
                        MessageBox.Show("Addon " + moduleList[i].Name + " stopped due to an error:\n" + e.ToString());
                        moduleList[i].Active = false;
                    }

                }
            }
        }

        public async static void performUpdate()
        {
            while (true)
            {
                //Ingame timer update
                //ingameTimer = (BitConverter.ToUInt16(SwapEndian(ReadBytes(BaseAddress + 0x32D580, 2), 4), 0));
                ingameTimer = ReadBytes(BaseAddress + 0x32D5D4, 2)[0];
                //If there's a level loaded EVEN if there's no model
                if (modelStatus != ModelStatus.NONE)
                {
                    if (ingameTimer > previousFrame)
                    {
                        //Set new value
                        previousFrame = ingameTimer;
                        //If the ingame timer reaches zero then let's just write 255 more to it
                        //This was when using a variable that decremented each frame, with VI Timer this shouldn't need to be used anymore
                        /*
                        if (ingameTimer == 0)
                        {
                            await Task.Run(() => { WriteUInt(BaseAddress + 0x33B198, 255); });
                        }
                        */
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
                        ingameTimer = await Task.Run(() => ReadBytes(BaseAddress + 0x32D5D4, 2)[0]);
                    }
                }
                // zzz
                await Task.Delay(10);
            }
        }

        public static bool GetKey(Keys vKey)
        {
            return 0 != GetAsyncKeyState(vKey);
        }
    }
}
