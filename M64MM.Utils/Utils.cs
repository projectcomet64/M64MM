using System;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace M64MM
{
    public static class Utils
    {
        public static long BaseAddress;
        public static bool IsEmuOpen => (emuProcess != null && !emuProcess.HasExited);
        public enum ModelStatus
        {
            NONE,
            VANILLA,
            EMPTY,
            MODDED
        }
        public enum VanillaModelColor
        {
            PantsShade,
            PantsMain,
            HatShade,
            HatMain,
            GloveShade,
            GloveMain,
            ShoeShade,
            ShoeMain,
            SkinShade,
            SkinMain,
            HairShade,
            HairMain
        }
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

        public static ushort ReadUShort(long address)
        {
            long size = sizeof(ushort);
            byte[] buffer = ReadBytes(address, size);
            ushort value = BitConverter.ToUInt16(buffer, 0);
            return value;
        }

        public static uint ReadUInt(long address)
        {
            long size = sizeof(uint);
            byte[] buffer = ReadBytes(address, size);
            uint value = BitConverter.ToUInt32(buffer, 0);
            return value;
        }

        public static ulong ReadULong(long address)
        {
            long size = sizeof(ulong);
            byte[] buffer = ReadBytes(address, size);
            ulong value = BitConverter.ToUInt64(buffer, 0);
            return value;
        }
        #endregion


        #region Writing
        public static void WriteBytes(long address, byte[] data)
        {
            IntPtr ptr = new IntPtr(address);
            long size = data.LongLength;
            long bytesWritten = 0;

            WriteProcessMemory(emuProcessHandle, ptr, data, size, ref bytesWritten);
        }

        public static void WriteBatchBytes(string[] addresses, byte[] data, bool useBase)
        {
            SwapEndian(data, 4);
            long baseAddr;
            if (useBase == true)
            {
                baseAddr = BaseAddress;
            }
            else
            {
                baseAddr = 0;
            }
            foreach(string addr in addresses)
            {
                long address = Convert.ToInt64(addr, 16);
                WriteBytes(baseAddr + address, data);
            }
        }

        public static void WriteUShort(long address, ushort data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            WriteBytes(address, buffer);
        }

        public static void WriteUInt(long address, uint data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            WriteBytes(address, buffer);
        }

        public static void WriteULong(long address, ulong data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            WriteBytes(address, buffer);
        }
        #endregion


        public static void FindEmuProcess()
        {
            foreach (Process proc in Process.GetProcesses())
            {
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
                value = ReadUInt(BaseAddress);

                if (value == 0x3C1A8032) return;
            }

            for (long scanAddress = start; scanAddress < stop - step; scanAddress += step)
            {
                value = ReadUInt(scanAddress);

                if (value == 0x3C1A8032)
                {
                    BaseAddress = scanAddress;
                    return;
                }
            }

            //If we don't find anything, reset the base address to 0
            BaseAddress = 0;
        }

        public static void WriteColor(VanillaModelColor ModelPart, Color color_)
        {
            long writeToAddress = 0;
            byte[] colors = new byte[4];
                switch (ModelPart)
                {
                    case VanillaModelColor.PantsShade:
                        writeToAddress = 0x07EC20;
                        break;
                    case VanillaModelColor.PantsMain:
                        writeToAddress = 0x07EC28;
                        break;
                    case VanillaModelColor.HatShade:
                        writeToAddress = 0x07EC38;
                        break;
                    case VanillaModelColor.HatMain:
                        writeToAddress = 0x07EC40;
                        break;
                    case VanillaModelColor.GloveShade:
                        writeToAddress = 0x07EC50;
                        break;
                    case VanillaModelColor.GloveMain:
                        writeToAddress = 0x07EC58;
                        break;
                    case VanillaModelColor.ShoeShade:
                        writeToAddress = 0x07EC68;
                        break;
                    case VanillaModelColor.ShoeMain:
                        writeToAddress = 0x07EC70;
                        break;
                    case VanillaModelColor.SkinShade:
                        writeToAddress = 0x07EC80;
                        break;
                    case VanillaModelColor.SkinMain:
                        writeToAddress = 0x07EC88;
                        break;
                    case VanillaModelColor.HairShade:
                        writeToAddress = 0x07EC98;
                        break;
                    case VanillaModelColor.HairMain:
                        writeToAddress = 0x07ECA0;
                        break;
                }
            colors[0] = color_.R;
            colors[1] = color_.G;
            colors[2] = color_.B;
            colors[3] = 0x0;
            if (writeToAddress > 0)
            {
                WriteBytes(BaseAddress + writeToAddress, SwapEndian(colors, 4));
            }
        }

        public static ModelStatus ValidateModel()
        {
            byte[] Color1;
            byte[] Color2;
            byte[] Shadow1;
            byte[] FinalSetOfBytes;

            Color1 = SwapEndian(ReadBytes(BaseAddress + 0x07EC70, 4), 4);
            Color2 = SwapEndian(ReadBytes(BaseAddress + 0x07EC80, 4), 4);
            Shadow1 = SwapEndian(ReadBytes(BaseAddress + 0x07EC78, 4), 4);
            FinalSetOfBytes = SwapEndian(ReadBytes(BaseAddress + 0x07EC7C, 4), 4);

            //If the color data is all zeros (Testing...)
            if ((BitConverter.ToInt32(Color1, 0) == 0) &&
                (BitConverter.ToInt32(Color2, 0) == 0) &&
                (BitConverter.ToInt32(Shadow1, 0) == 0) &&
                (BitConverter.ToInt32(FinalSetOfBytes, 0) == 0))
            {
                return ModelStatus.EMPTY;
            }

            //If the color data is not RR GG BB *00* RR GG BB *00* XX YY ZZ *00* *00 00 00 00*
            if ((Color1[3] != 0)
                || (Color2[3] != 0)
                || (Shadow1[3] != 0)
                || (BitConverter.ToInt32(FinalSetOfBytes, 0) != 0))
            {
                //MessageBox.Show("Color data: Color 1[3] = " + (byte)Color1[3] + "\nColor 2[3] = " + (byte)Color2[3] + "\nShadow 1[3] = " + (byte)Shadow1[3]);
                return ModelStatus.MODDED;
            }
            //If all's good :)
            return ModelStatus.VANILLA;
        }

        public static void WaitForNextFrame()
        {
            int viNumber = BitConverter.ToUInt16(SwapEndian(ReadBytes(BaseAddress + 0x32D580, 4), 4), 0);
            while (BitConverter.ToUInt16(SwapEndian(ReadBytes(BaseAddress + 0x32D580, 4), 4), 0) != viNumber)
            {
                //Stall
            }
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
            for (int x = 0; x < array.Length / wordSize; x++)
            {
                Array.Reverse(array, x * wordSize, wordSize);
            }

            return array;
        }


        public static bool GetKey(Keys vKey)
        {
            return 0 != GetAsyncKeyState(vKey);
        }
    }

    public class UI
    {
        public static void ShowMsgBox(string text, string title = "")
        {
            MessageBox.Show(text, title);
        }
    }



    public interface IModule
    {
        void Initialize();
        void Update();
        void Reset();
        void Close(System.ComponentModel.CancelEventArgs e);
        string SafeName { get; }
        string Description { get; }
        ICollection GetCommands();
    }

    public class ToolCommand
    {
        public string name;
        public event EventHandler Summon;

        public ToolCommand(string n, EventHandler sm)
        {
            name = n;
            Summon += sm;
        }
    }

    public class Plugin
    {
        public IModule Module { get; }
        public bool Active { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public Plugin (IModule mod, string nm, string vr, string dc)
        {
            Module = mod;
            Name = nm;
            Version = vr;
            Description = dc;
            Active = true;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
