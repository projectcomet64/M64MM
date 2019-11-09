using System.Drawing;
using static M64MM.Utils.Core;
namespace M64MM.Utils
{
    public class Looks
    {

        static readonly int[] shadowAddresses = {
            0x07EC30,
            0x07EC48,
            0x07EC60,
            0x07EC78,
            0x07EC90,
            0x07ECA8
        };

        public enum ShadowParts
        {
            X,
            Y,
            Z
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
                WriteBytes(BaseAddress + writeToAddress, SwapEndianRet(colors, 4));
            }
        }

        public static void changeShadow(int amount, ShadowParts part)
        {
            byte[] data = new byte[1];
            data[0] = (byte)amount;

            foreach (int address in shadowAddresses)
            {
                switch (part)
                {
                    case ShadowParts.X:
                        WriteBytes(BaseAddress + address + 3, data);
                        break;
                    case ShadowParts.Y:
                        WriteBytes(BaseAddress + address + 2, data);
                        break;
                    case ShadowParts.Z:
                        WriteBytes(BaseAddress + address + 1, data);
                        break;
                }
            }
        }
    }
}