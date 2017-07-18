using System;
using System.Diagnostics;
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

        public static short ReadShort(long address)
        {
            long size = sizeof(short);
            byte[] buffer = ReadBytes(address, size);
            short value = BitConverter.ToInt16(buffer, 0);
            return value;
        }

        public static int ReadInt(long address)
        {
            long size = sizeof(int);
            byte[] buffer = ReadBytes(address, size);
            int value = BitConverter.ToInt32(buffer, 0);
            return value;
        }

        public static long ReadLong(long address)
        {
            long size = sizeof(long);
            byte[] buffer = ReadBytes(address, size);
            long value = BitConverter.ToInt64(buffer, 0);
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

        public static void WriteShort(long address, short data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            WriteBytes(address, buffer);
        }

        public static void WriteInt(long address, int data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            WriteBytes(address, buffer);
        }

        public static void WriteLong(long address, long data)
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
            int value = 0;

            long start = 0x10000000;
            long stop = 0x70000000;
            long step = 0x10000;

            //Check if the old base address is still valid
            if (BaseAddress > 0)
            {
                value = ReadInt(BaseAddress);

                if (value == 0x3C1A8032) return;
            }

            for (long scanAddress = start; scanAddress < stop - step; scanAddress += step)
            {
                value = ReadInt(scanAddress);

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
            if (address < emuProcessHandle.ToInt64() + emuProcess.WorkingSet64 - size)
                return true;

            return false;
        }
    }
}
