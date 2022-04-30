using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public class ColorCodeInvalidException : Exception
    {
        int _line;
        int _length;
        string _addr;
        public int Line { get { return _line; } private set { } }
        public int Length { get { return _length; } private set { } }
        public string Address { get { return _addr; } private set { } }

        public ColorCodeInvalidException(int line, int length = 0, string addr = null) : base()
        {
            _line = line;
            _length = length;
            _addr = addr;
        }
    }
}
