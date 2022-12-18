using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static M64MM.Utils.Core;

namespace M64MM.Utils
{
    public class ColorPart
    {
        public string Name { get; set; }
        public uint Offset88 { get; set; }
        public uint Offset86 { get; set; }
        public uint OffsetLightDir => Offset86 + 8;
        public Color LightColor { get; set; }
        public Color DarkColor { get; set; }
        public Color DefaultLightColor { get; set; }
        public Color DefaultDarkColor { get; set; }

        public void CommitColorsToRam() {
            CommitColorsToRam(SegmentedToVirtual(0x04000000));
        }

        public void CommitColorsToRam(long baseOffset) {
            byte[] colors_L = {LightColor.R, LightColor.G, LightColor.B, 0x0};
            byte[] colors_D = {DarkColor.R, DarkColor.G, DarkColor.B, 0x0};

            if (colors_L.Sum(x => (int)x) == 0) colors_L[3] = 0xFF;
            if (colors_D.Sum(x => (int)x) == 0) colors_D[3] = 0xFF;

            
            WriteBytes(baseOffset + Offset86, SwapEndian(colors_L, 4));
            WriteBytes(baseOffset + Offset88, SwapEndian(colors_D, 4));

            WriteBytes(baseOffset + Offset86 + 4, SwapEndian(colors_L, 4));
            WriteBytes(baseOffset + Offset88 + 4, SwapEndian(colors_D, 4));
        }

        public void ChangeLightDirection(byte nX, byte nY, byte nZ) {
            ChangeLightDirection(SegmentedToVirtual(0x04000000), nX, nY, nZ);
        }

        public void ChangeLightDirection(long baseOffset, byte nX, byte nY, byte nZ) {
            WriteBytes(baseOffset + OffsetLightDir, new byte[]{ nX, nY, nZ, 00}, true);
        }

        public string ToGameshark() {
            // It's like this because I want color codes to be "universal" so if S04 ends up
            // being in another location I just subtract 0x7EC20 from each line

            StringBuilder code = new StringBuilder();
            string[] addressToWrite = new string[2];

            addressToWrite[0] = (0x7EC20 + Offset88).ToString("X6");
            addressToWrite[1] = (0x7EC20 + Offset88 + 2).ToString("X6");
            code.AppendLine($"81{addressToWrite[0]} {DarkColor.R:X2}{DarkColor.G:X2}");
            code.AppendLine($"81{addressToWrite[1]} {DarkColor.B:X2}00");

            addressToWrite[0] = (0x7EC20 + Offset86).ToString("X6");
            addressToWrite[1] = (0x7EC20 + Offset86 + 2).ToString("X6");
            code.AppendLine($"81{addressToWrite[0]} {LightColor.R:X2}{LightColor.G:X2}");
            code.AppendLine($"81{addressToWrite[1]} {LightColor.B:X2}00");
            return code.ToString();
        }

    }
}
