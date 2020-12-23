using System.Drawing;
using System.Collections;
using static M64MM.Utils.Core;
using System;
using System.Linq;
using System.Globalization;

namespace M64MM.Utils
{
    public class Looks
    {
        public enum ModelHeaderType
        {
            UNSET,
            CLASSIC,
            MOD,
            SPARK,
            EMPTY
        }

        public static readonly RoutableColorPart[] defaultRoutableParts =
        {
            new RoutableColorPart()
            {
                Name = "Overalls",
                Address86 = new long[] { 0x8B8CC },
                Address88 = new long[] { 0x8B8D4 },
                BankOffset86 = 8,
                BankOffset88 = 0,
                DefaultLightColor = Color.Blue,
                DefaultShadowColor = Color.FromArgb(0,0,127)
            },
            new RoutableColorPart()
            {
                Name = "Left Arm",
                Address86 = new long[] { 0x8BDFC },
                Address88 = new long[] { 0x8BE04 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18,
                DefaultLightColor = Color.Red,
                DefaultShadowColor = Color.FromArgb(127,0,0)
            },
            new RoutableColorPart()
            {
                Name = "Right Arm",
                Address86 = new long[] { 0x8CA0C },
                Address88 = new long[] { 0x8CA14 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18,
                DefaultLightColor = Color.Red,
                DefaultShadowColor = Color.FromArgb(127,0,0)
            },
            new RoutableColorPart()
            {
                Name = "Left Glove",
                Address86 = new long[] { 0x8C514 },
                Address88 = new long[] { 0x8C51C },
                BankOffset86 = 0x38,
                BankOffset88 = 0x30,
                DefaultLightColor = Color.White,
                DefaultShadowColor = Color.FromArgb(127,127,127)
            },
            new RoutableColorPart()
            {
                Name = "Right Glove",
                Address86 = new long[] { 0x8D07C },
                Address88 = new long[] { 0x8D084 },
                BankOffset86 = 0x38,
                BankOffset88 = 0x30,
                DefaultLightColor = Color.White,
                DefaultShadowColor = Color.FromArgb(127,127,127)
            },
            new RoutableColorPart()
            {
                Name = "Left Leg",
                Address86 = new long[] { 0x8D3E4 },
                Address88 = new long[] { 0x8D3EC },
                BankOffset86 = 8,
                BankOffset88 = 0,
                DefaultLightColor = Color.Blue,
                DefaultShadowColor = Color.FromArgb(0,0,127)
            },
            new RoutableColorPart()
            {
                Name = "Right Leg",
                Address86 = new long[] { 0x8DBDC },
                Address88 = new long[] { 0x8DBE4 },
                BankOffset86 = 8,
                BankOffset88 = 0,
                DefaultLightColor = Color.Blue,
                DefaultShadowColor = Color.FromArgb(0,0,127)
            },
            new RoutableColorPart()
            {
                Name = "Left Shoe",
                Address86 = new long[] { 0x8D8C4 },
                Address88 = new long[] { 0x8D8CC },
                BankOffset86 = 0x50,
                BankOffset88 = 0x48,
                DefaultLightColor = Color.FromArgb(144,28,14),
                DefaultShadowColor = Color.FromArgb(47,14,7)
            },
            new RoutableColorPart()
            {
                Name = "Right Shoe",
                Address86 = new long[] { 0x8E10C },
                Address88 = new long[] { 0x8E114 },
                BankOffset86 = 0x50,
                BankOffset88 = 0x48,
                DefaultLightColor = Color.FromArgb(144,28,14),
                DefaultShadowColor = Color.FromArgb(47,14,7)
            },
            new RoutableColorPart()
            {
                Name = "Hat and Shirt",
                Address86 = new long[] { 0x8EF74, 0x9058C },
                Address88 = new long[] { 0x8EF7C, 0x90594 },
                BankOffset86 = 0x20,
                BankOffset88 = 0x18,
                DefaultLightColor = Color.Red,
                DefaultShadowColor = Color.FromArgb(127,0,0)
            },
            new RoutableColorPart()
            {
                Name = "Hair",
                Address86 = new long[] { 0x905A4 },
                Address88 = new long[] { 0x905AC },
                BankOffset86 = 0x80,
                BankOffset88 = 0x78,
                DefaultLightColor = Color.FromArgb(115,6,0),
                DefaultShadowColor = Color.FromArgb(57,3,0)
            },
            new RoutableColorPart()
            {
                Name = "Skin",
                Address86 = new long[0],
                Address88 = new long[0],
                BankOffset86 = 0x68,
                BankOffset88 = 0x60,
                DefaultLightColor = Color.FromArgb(254,193,121),
                DefaultShadowColor = Color.FromArgb(127,96,60)

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
            // Model checking may detect it as empty if every color is black but the last byte is also 0
            // Short circuit until I find a more smart way to detect if a model truly is empty
            colors[3] = (byte)((colors[0] == 0 && colors[1] == 0 && colors[2] == 0) ? 0xFF : 0x0);
            if (writeToAddress > 0)
            {
                WriteBytes(writeToAddress, SwapEndian(colors, 4));
            }
        }

        public static string ValidateCC(string[] lines)
        {
            string wholeCode = "";
            for (int lineNum = 0; lineNum < lines.Length; lineNum++)
            {
                //Remove spaces from each line so they don't mess up the character count
                // Also remove carriage returns and newlines (to make it not break if it's being loaded from file)
                string line = lines[lineNum].Replace(" ", "").TrimEnd('\r', '\n');

                //If the line is empty, ignore it
                if (string.IsNullOrEmpty(line)) continue;

                //If each line isn't exactly 12 characters long, it's not a valid code
                if (line.Length != 12)
                {
                    throw new ClassicColorCodeInvalidException(lineNum+1, line.Length);
                }

                //If the code tries to write data outside of where Mario's colors are located, it's not a valid code
                int address = int.Parse(line.Substring(2, 6), NumberStyles.HexNumber);
                if (address < 0x07EC20 || address > 0x07ECA6)
                {
                    throw new ClassicColorCodeInvalidException(lineNum+1, line.Length, line.Substring(2, 6));
                }

                wholeCode += line;
            }
            return wholeCode;
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

        public static ModelHeaderType AnalyzeHeader()
        {
            if (!IsEmuOpen)
                return ModelHeaderType.UNSET;

            long S04 = SegmentedToVirtual(0x04000000, false);
            byte[] ModelHeader = SwapEndian(ReadBytes(S04 + BaseAddress, 0x1E0), 4);
            int length = 0;
            int empties = 0;
            for (int i = 0; i < 0x1E0; i += 8)
            {
                if (ModelHeader[i] == 0 && ModelHeader[i+1] == 0
                    && ModelHeader[i+2] == 0)
                {
                    if (ModelHeader[i + 3] != 0xFF)
                    {
                        empties++;
                        length++;
                    }
                    continue;
                }
                if ((ModelHeader[i + 3] == 0 || ModelHeader[i + 3] == 255) && (ModelHeader[i + 7] == 0 || ModelHeader[i + 7] == 255))
                {
                    length++;
                }
                else
                {
                    break;
                }
            }
            if (empties == length && length == 60)
            {
                return ModelHeaderType.EMPTY;
            }
            if (length < 13)
            {
                return ModelHeaderType.MOD;
            }
            else if (length >= 13 && length < 60)
            {
                return ModelHeaderType.CLASSIC;
            }
            else if (length == 60)
            {
                return ModelHeaderType.SPARK;
            }
            else if (length == 0)
            {
                return ModelHeaderType.EMPTY;
            }
            return ModelHeaderType.UNSET;
        }


        /// <summary>
        /// Write the public Color variables to the location in memory where it's located
        /// That is, to speak, "Light" and "Shadow".
        /// </summary>
        /// <param name="part">The RoutableColorPart to be changed</param>
        /// <param name="defaults">Write defaults instead?</param>
        public static void WriteRoutableColor(RoutableColorPart part, bool defaults = false)
        {
            byte[] colorLight;
            byte[] colorShadow;

            if (defaults)
            {
                colorLight = new byte[] { part.DefaultLightColor.R, part.DefaultLightColor.G, part.DefaultLightColor.B, 0 };
                colorShadow = new byte[] { part.DefaultLightColor.R, part.DefaultLightColor.G, part.DefaultLightColor.B, 0 };
            }
            else
            {
                colorLight = new byte[] { part.CurrentLightColor.R, part.CurrentLightColor.G, part.CurrentLightColor.B, 0 };
                colorShadow = new byte[] { part.CurrentShadowColor.R, part.CurrentShadowColor.G, part.CurrentShadowColor.B, 0 };
            }

            WriteBytes(SegmentedToVirtual((0x04000000 + part.BankOffset86)), colorLight);
            WriteBytes(SegmentedToVirtual((0x04000000 + part.BankOffset88)), colorShadow);
        }

        /// <summary>
        /// Write the following shadow values to the location in memory where this part specifies
        /// </summary>
        /// <param name="part">The RoutableColorPart to be changed</param>
        public static void WriteRoutableShading(RoutableColorPart part, byte[] shadowDir)
        {
            shadowDir[3] = 0;
            WriteBytes(SegmentedToVirtual((0x04000000 + part.BankOffset86 + 8)), shadowDir);
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

            // what is this
            /*
            for (int i = 0; i < adjustedTarget.Address86.Length; i++)
            {
                adjustedTarget.Address86[i] = adjustedTarget.Address86[i];
            }
            for (int i = 0; i < adjustedTarget.Address88.Length; i++)
            {
                adjustedTarget.Address88[i] = adjustedTarget.Address88[i];
            }*/

            // TODO: Regression testing: try out the router once again.
            WriteBatchBytes(adjustedTarget.Address86, BitConverter.GetBytes(0x04000000 + source.BankOffset86).Reverse().ToArray(), true, true);
            WriteBatchBytes(adjustedTarget.Address88, BitConverter.GetBytes(0x04000000 + source.BankOffset88).Reverse().ToArray(), true, true);
        }
    }
}