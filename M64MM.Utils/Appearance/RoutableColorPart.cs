using System;
using System.Drawing;

namespace M64MM.Utils
{
    public struct RoutableColorPart
    {
        public string Name;
        public long[] Address86;
        public long[] Address88;
        public uint BankOffset86;
        public uint BankOffset88;
        public Color DefaultLightColor;
        public Color DefaultShadowColor;
        public Color CurrentLightColor;
        public Color CurrentShadowColor;
    }
}
