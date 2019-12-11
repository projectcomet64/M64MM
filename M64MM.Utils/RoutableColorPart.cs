using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public struct RoutableColorPart
    {
        public string Name;
        public long[] Address86;
        public long[] Address88;
        public byte BankOffset86;
        public byte BankOffset88;
    }
}
