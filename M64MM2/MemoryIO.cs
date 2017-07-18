using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace M64MM2
{
    static class MemoryIO
    {
        public static long BaseAddress = 0;
        public static bool IsEmuOpen => (emuProcess != null && !emuProcess.HasExited && emuProcessHandle != null);
        private static Process emuProcess;
        private static IntPtr emuProcessHandle;

        private const int PROCESS_ALL_ACCESS = 0x1F0FF;

        [DllImport("Kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesitedAccess, bool bInheritHandle, int dwProcessID);
        [DllImport("Kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, long nSize, ref long lpNumberOfBytesRead);
        [DllImport("Kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, long nSize, ref long lpNumberOfBytesWritten);

        #region Reading
        public static byte[] ReadBytes(long address, long size)
        {
            IntPtr ptr = new IntPtr(address);
            byte[] buffer = new byte[size];
            long bytesRead = 0;

            if (!IsMemSafe(address, size))
            {
                throw new UnauthorizedAccessException("Error: Program attempted to access memory outside of the allowed range.");
            }

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

            if (!IsMemSafe(address, size))
            {
                throw new UnauthorizedAccessException("Error: Program attempted to access memory outside of the allowed range.");
            }

            WriteProcessMemory(emuProcessHandle, ptr, data, size, ref bytesWritten);
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

        private static bool IsMemSafe(long address, long size)
        {
            //Don't read or write memory outside of Project64, for security and stability reasons
            //if (address < emuProcessHandle.ToInt64() + emuProcess.WorkingSet64 - size)
                return true;

            return false;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
