using System.Drawing;
using System.Collections;
using static M64MM.Utils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace M64MM.Utils {
    public class Looks {
        public enum ModelHeaderType {
            UNSET,
            CLASSIC,
            MOD,
            SPARK,
            EMPTY
        }

        public static List<ColorPart> x3sParts = new List<ColorPart> {
            new ColorPart {
                Name = "X3S Tint",
                Offset88 = 0x1C800,
                Offset86 = 0x1C808,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            }

        };

        public static List<ColorPart> sparkParts = new List<ColorPart>
        {
            new ColorPart
            {
                Name = "Hat",
                Offset88 = 0x18,
                Offset86 = 0x20,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            },
            new ColorPart
            {
                Name = "Hair",
                Offset88 = 0x78,
                Offset86 = 0x80,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            },
            new ColorPart
            {
                Name = "Skin",
                Offset88 = 0x60,
                Offset86 = 0x68,
                DefaultLightColor = Color.FromArgb(254, 193, 121),
                DefaultDarkColor = Color.FromArgb(127, 96, 60)
            },
            new ColorPart
            {
                Name = "Shirt",
                Offset88 = 0x90,
                Offset86 = 0x98,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            },
            new ColorPart
            {
                Name = "Shoulders",
                Offset88 = 0xA8,
                Offset86 = 0xB0,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            },
            new ColorPart
            {
                Name = "Arms",
                Offset88 = 0xC0,
                Offset86 = 0xC8,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            },
            new ColorPart
            {
                Name = "Gloves",
                Offset88 = 0x30,
                Offset86 = 0x38,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Overalls Top",
                Offset88 = 0x0,
                Offset86 = 0x8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            },
            new ColorPart
            {
                Name = "Overalls Bottom",
                Offset88 = 0xD8,
                Offset86 = 0xE0,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            },
            new ColorPart
            {
                Name = "Leg Top",
                Offset88 = 0xF0,
                Offset86 = 0xF8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            },
            new ColorPart
            {
                Name = "Leg Bottom",
                Offset88 = 0x108,
                Offset86 = 0x110,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            },
            new ColorPart
            {
                Name = "Shoes",
                Offset88 = 0x48,
                Offset86 = 0x50,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            },
            new ColorPart
            {
                Name = "Custom 1",
                Offset88 = 0x120,
                Offset86 = 0x128,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 2",
                Offset88 = 0x138,
                Offset86 = 0x140,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 3",
                Offset88 = 0x150,
                Offset86 = 0x158,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 4",
                Offset88 = 0x168,
                Offset86 = 0x170,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 5",
                Offset88 = 0x180,
                Offset86 = 0x188,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 6",
                Offset88 = 0x198,
                Offset86 = 0x1A0,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 7",
                Offset88 = 0x1B0,
                Offset86 = 0x1B8,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Custom 8",
                Offset88 = 0x1C8,
                Offset86 = 0x1D0,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            }
        };

        public static List<ColorPart> classicParts = new List<ColorPart>
        {
            new ColorPart
            {
                Name = "Hat & Shirt",
                Offset88 = 0x18,
                Offset86 = 0x20,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            },
            new ColorPart
            {
                Name = "Hair",
                Offset88 = 0x78,
                Offset86 = 0x80,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            },
            new ColorPart
            {
                Name = "Skin",
                Offset88 = 0x60,
                Offset86 = 0x68,
                DefaultLightColor = Color.FromArgb(254, 193, 121),
                DefaultDarkColor = Color.FromArgb(127, 96, 60)
            },
            new ColorPart
            {
                Name = "Gloves",
                Offset88 = 0x30,
                Offset86 = 0x38,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            },
            new ColorPart
            {
                Name = "Overalls",
                Offset88 = 0x0,
                Offset86 = 0x8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            },
            new ColorPart
            {
                Name = "Shoes",
                Offset88 = 0x48,
                Offset86 = 0x50,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            }
        };

        [Obsolete("May be removed very soon...")]
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

        public enum ShadowParts {
            X,
            Y,
            Z
        }

        public static string ValidateCC(string[] lines) {
            StringBuilder wholeCode = new StringBuilder();
            for (int lineNum = 0; lineNum < lines.Length; lineNum++) {
                //Remove spaces from each line so they don't mess up the character count
                // Also remove carriage returns and newlines (to make it not break if it's being loaded from file)
                string line = lines[lineNum].Replace(" ", "").TrimEnd('\r', '\n');

                //If the line is empty, ignore it
                if (string.IsNullOrEmpty(line)) continue;

                //If each line isn't exactly 12 characters long, it's not a valid code
                if (line.Length != 12) {
                    throw new ColorCodeInvalidException(lineNum + 1, line.Length);
                }

                //If the code tries to write data outside of where Mario's colors are located, it's not a valid code
                int address = int.Parse(line.Substring(2, 6), NumberStyles.HexNumber);
                if (address < 0x07EC20 || address > 0x07EE00) {
                    throw new ColorCodeInvalidException(lineNum + 1, line.Length, line.Substring(2, 6));
                }

                wholeCode.AppendLine(lines[lineNum]);
            }

            // no carriage return because I despise it
            return wholeCode.ToString().TrimEnd('\n').Replace("\r", "");
        }

        public static void FromColorCode(string code, List<ColorPart> cParts) {
            byte[] buffer = new byte[0x90];
            foreach (string line in code.Split('\n')) {
                var gsParts = line.Split(' ');
                if (gsParts.Length < 2) continue;
                var cData = Core.StringToByteArray(gsParts[1]);
                long addr = (long.Parse(gsParts[0], System.Globalization.NumberStyles.HexNumber) & 0x00FFFFFF) - 0x7EC20;
                // This means this is a SCC
                if (addr >= 0x1E0) {
                    continue;
                }
                if (addr >= 0x90 && buffer.Length == 0x90) {
                    byte[] neoBuffer = new byte[0x1E0];
                    buffer.CopyTo(neoBuffer, 0);
                    buffer = neoBuffer;
                }
                cData.CopyTo(buffer, addr);
            }

            foreach (ColorPart cPart in cParts) {
                if (cPart.Offset86 > buffer.Length) {
                    continue;
                }
                cPart.LightColor = Color.FromArgb(buffer[cPart.Offset86],
                    buffer[cPart.Offset86 + 1],
                    buffer[cPart.Offset86 + 2]);
                cPart.DarkColor = Color.FromArgb(buffer[cPart.Offset88],
                    buffer[cPart.Offset88 + 1],
                    buffer[cPart.Offset88 + 2]);
            }
        }
        
        public static ModelHeaderType AnalyzeHeader() {
            if (!IsEmuOpen)
                return ModelHeaderType.UNSET;

            long S04 = SegmentedToVirtual(0x04000000, false);
            byte[] ModelHeader = SwapEndian(ReadBytes(S04 + BaseAddress, 0x1E0), 4);
            int length = 0;
            int empties = 0;
            for (int i = 0; i < 0x1E0; i += 8) {
                if (ModelHeader[i] == 0 && ModelHeader[i + 1] == 0
                    && ModelHeader[i + 2] == 0) {
                    if (ModelHeader[i + 3] != 0xFF) {
                        empties++;
                        length++;
                    }
                    continue;
                }
                // todo: improve this with cometchar tier reading
                if ((ModelHeader[i + 3] == 0 || ModelHeader[i + 3] == 255) && (ModelHeader[i + 7] == 0 || ModelHeader[i + 7] == 255)
                ) {
                    length++;
                }
                else {
                    break;
                }
            }
            if (empties == length && length == 60) {
                return ModelHeaderType.EMPTY;
            }
            if (length < 13) {
                return ModelHeaderType.MOD;
            }
            else if (length >= 13 && length < 60) {
                return ModelHeaderType.CLASSIC;
            }
            else if (length == 60) {
                return ModelHeaderType.SPARK;
            }
            else if (length == 0) {
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
        [Obsolete("May be removed very soon...")]
        public static void WriteRoutableColor(RoutableColorPart part, bool defaults = false) {
            byte[] colorLight;
            byte[] colorShadow;

            if (defaults) {
                colorLight = new byte[] { part.DefaultLightColor.R, part.DefaultLightColor.G, part.DefaultLightColor.B, 0 };
                colorShadow = new byte[] { part.DefaultLightColor.R, part.DefaultLightColor.G, part.DefaultLightColor.B, 0 };
            }
            else {
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
        [Obsolete("May be removed very soon...")]
        public static void WriteRoutableShading(RoutableColorPart part, byte[] shadowDir) {
            shadowDir[3] = 0;
            WriteBytes(SegmentedToVirtual((0x04000000 + part.BankOffset86 + 8)), shadowDir);
        }

        [Obsolete("May be removed very soon...")]
        public static void RouteColor(RoutableColorPart source, RoutableColorPart target) {
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