using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Utils {
    public struct Animation {
        public string Value { get; set; }
        public string Description { get; set; }
        public int RealIndex { get; set; }
        // You'll see.
        public int Length;
        public int LoopStart;
        public int LoopEnd;

        public static bool operator ==(Animation a, Animation b) {
            return a.Value == b.Value && a.Description == b.Description;
        }

        public static bool operator !=(Animation a, Animation b)
        {
            return !(a == b); //lol
        }
    }
}
