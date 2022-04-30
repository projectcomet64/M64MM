using System;
using System.Diagnostics;

namespace M64MM.Utils {
    public class EmuFoundEventArgs : EventArgs {
        public Process[] ProcessList { get; }
        public bool HasInaccessibleProcesses { get; }

        public EmuFoundEventArgs(Process[] processList, bool hasInaccessibleProcesses) {
            ProcessList = processList;
            HasInaccessibleProcesses = hasInaccessibleProcesses;
        }
    }
}