using System.Drawing;
using System.Collections;
using static M64MM.Utils.Core;
namespace M64MM.Utils
{
    public class Looks
    {

        public static readonly RoutableColorPart[] defaultRoutableParts =
        {
            new RoutableColorPart()
            {
                Name = "Overalls",
                Address86 = new long[] { 0x8B8CC },
                Address88 = new long[] { 0x8B8D4 },
                BankOffset86 = 8,
                BankOffset88 = 0
            },
            new RoutableColorPart()
            {
                Name = "Left Arm",
                Address86 = new long[] { 0x8BDFC },
                Address88 = new long[] { 0x8BE04 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18
            },
            new RoutableColorPart()
            {
                Name = "Right Arm",
                Address86 = new long[] { 0x8CA0C },
                Address88 = new long[] { 0x8CA14 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18
            },
            new RoutableColorPart()
            {
                Name = "Left Glove",
                Address86 = new long[] { 0x8C514 },
                Address88 = new long[] { 0x8C51C },
                BankOffset86 = 0x38,
                BankOffset88 = 0x30
            },
            new RoutableColorPart()
            {
                Name = "Right Glove",
                Address86 = new long[] { 0x8D07C },
                Address88 = new long[] { 0x8D084 },
                BankOffset86 = 0x38,
                BankOffset88 = 0x30
            },
            new RoutableColorPart()
            {
                Name = "Left Leg",
                Address86 = new long[] { 0x8D3E4 },
                Address88 = new long[] { 0x8D3EC },
                BankOffset86 = 8,
                BankOffset88 = 0
            },
            new RoutableColorPart()
            {
                Name = "Right Leg",
                Address86 = new long[] { 0x8DBDC },
                Address88 = new long[] { 0x8DBE4 },
                BankOffset86 = 8,
                BankOffset88 = 0
            },
            new RoutableColorPart()
            {
                Name = "Left Shoe",
                Address86 = new long[] { 0x8D8C4 },
                Address88 = new long[] { 0x8D8CC },
                BankOffset86 = 0x50,
                BankOffset88 = 0x48
            },
            new RoutableColorPart()
            {
                Name = "Right Shoe",
                Address86 = new long[] { 0x8E10C },
                Address88 = new long[] { 0x8E114 },
                BankOffset86 = 0x50,
                BankOffset88 = 0x48
            },
            new RoutableColorPart()
            {
                Name = "Hat and Shirt",
                Address86 = new long[] { 0x8EF74, 0x9058C },
                Address88 = new long[] { 0x8EF7C, 0x90594 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18
            },
            new RoutableColorPart()
            {
                Name = "Hair",
                Address86 = new long[] { 0x905A4 },
                Address88 = new long[] { 0x905AC },
                BankOffset86 = 0x80,
                BankOffset88 = 0x78
            },
            new RoutableColorPart()
            {
                Name = "Skin",
                Address86 = new long[0],
                Address88 = new long[0],
                BankOffset86 = 0x68,
                BankOffset88 = 0x60
            }
        };

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
                    writeToAddress = SegmentedToVirtual(0x04000000);
                    break;
                case VanillaModelColor.PantsMain:
                    writeToAddress = SegmentedToVirtual(0x04000008);
                    break;
                case VanillaModelColor.HatShade:
                    writeToAddress = SegmentedToVirtual(0x04000018);
                    break;
                case VanillaModelColor.HatMain:
                    writeToAddress = SegmentedToVirtual(0x04000020);
                    break;
                case VanillaModelColor.GloveShade:
                    writeToAddress = SegmentedToVirtual(0x04000030);
                    break;
                case VanillaModelColor.GloveMain:
                    writeToAddress = SegmentedToVirtual(0x04000038);
                    break;
                case VanillaModelColor.ShoeShade:
                    writeToAddress = SegmentedToVirtual(0x04000048);
                    break;
                case VanillaModelColor.ShoeMain:
                    writeToAddress = SegmentedToVirtual(0x04000050);
                    break;
                case VanillaModelColor.SkinShade:
                    writeToAddress = SegmentedToVirtual(0x04000060);
                    break;
                case VanillaModelColor.SkinMain:
                    writeToAddress = SegmentedToVirtual(0x04000068);
                    break;
                case VanillaModelColor.HairShade:
                    writeToAddress = SegmentedToVirtual(0x04000078);
                    break;
                case VanillaModelColor.HairMain:
                    writeToAddress = SegmentedToVirtual(0x04000080);
                    break;
            }
            colors[0] = color_.R;
            colors[1] = color_.G;
            colors[2] = color_.B;
            colors[3] = 0x0;
            if (writeToAddress > 0)
            {
                WriteBytes(writeToAddress, SwapEndian(colors, 4));
            }
        }

        public static void FromColorCode(string code)
        {
            //Trim some data we don't need anymore. Now each line of the color code is represented by 3 bytes.
            byte[] data = StringToByteArray(code.Replace("8107EC", ""));

            //Every 6 bytes of the trimmed data represents one color.
            //The first line holds the red and green values, and the second line holds the blue value.
            for (int i = 0; i < data.Length / 6; i++)
            {
                byte r = data[(i * 6) + 1];
                byte g = data[(i * 6) + 2];
                byte b = data[(i * 6) + 4];

                switch (data[(i * 6)])
                {
                    case 0x38:
                        WriteColor(VanillaModelColor.HatShade, Color.FromArgb(r, g, b));
                        break;
                    case 0x40:
                        WriteColor(VanillaModelColor.HatMain, Color.FromArgb(r, g, b));
                        break;
                    case 0x98:
                        WriteColor(VanillaModelColor.HairShade, Color.FromArgb(r, g, b));
                        break;
                    case 0xA0:
                        WriteColor(VanillaModelColor.HairMain, Color.FromArgb(r, g, b));
                        break;
                    case 0x80:
                        WriteColor(VanillaModelColor.SkinShade, Color.FromArgb(r, g, b));
                        break;
                    case 0x88:
                        WriteColor(VanillaModelColor.SkinMain, Color.FromArgb(r, g, b));
                        break;
                    case 0x50:
                        WriteColor(VanillaModelColor.GloveShade, Color.FromArgb(r, g, b));
                        break;
                    case 0x58:
                        WriteColor(VanillaModelColor.GloveMain, Color.FromArgb(r, g, b));
                        break;
                    case 0x20:
                        WriteColor(VanillaModelColor.PantsShade, Color.FromArgb(r, g, b));
                        break;
                    case 0x28:
                        WriteColor(VanillaModelColor.PantsMain, Color.FromArgb(r, g, b));
                        break;
                    case 0x68:
                        WriteColor(VanillaModelColor.ShoeShade, Color.FromArgb(r, g, b));
                        break;
                    case 0x70:
                        WriteColor(VanillaModelColor.ShoeMain, Color.FromArgb(r, g, b));
                        break;
                }
            }
        }

        public static void ChangeShadow(int amount, ShadowParts part)
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

        public static void RouteColor(RoutableColorPart source, RoutableColorPart target)
        {
            RoutableColorPart adjustedTarget = new RoutableColorPart()
            {
                Name = target.Name,
                Address86 = new long[target.Address86.Length],
                Address88 = new long[target.Address88.Length],
                BankOffset86 = target.BankOffset86,
                BankOffset88 = target.BankOffset88
            };
            target.Address86.CopyTo(adjustedTarget.Address86, 0);
            target.Address88.CopyTo(adjustedTarget.Address88, 0);
            for (int i = 0; i < adjustedTarget.Address86.Length; i++)
            {
                adjustedTarget.Address86[i] = adjustedTarget.Address86[i];
            }
            for (int i = 0; i < adjustedTarget.Address88.Length; i++)
            {
                adjustedTarget.Address88[i] = adjustedTarget.Address88[i];
            }

            WriteBatchBytes(adjustedTarget.Address86, new byte[] { 04, 0, 0, source.BankOffset86 }, true, true);
            WriteBatchBytes(adjustedTarget.Address88, new byte[] { 04, 0, 0, source.BankOffset88 }, true, true);
        }
    }
}