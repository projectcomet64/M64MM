using System;
using System.Drawing;
using M64MM.Utils.Extensions;

namespace M64MM.Utils
{
	public static class ColorSpace
    {
        public struct HSV
        {
            public static readonly HSV Identity;

            public double Hue;

            public double Saturation;

            public double Value;
        }

        public static void HSVToRGB(double hue, double saturation, double value, out Color result)
        {
            if (hue > 360.0)
            {
                hue -= 360.0;
            }
            if (hue < 0.0)
            {
                hue = 360.0 - hue;
            }
            saturation = saturation.Clamp(0.0, 1.0);
            value = value.Clamp(0.0, 1.0);
            byte[] array = new byte[3];
            for (int i = 0; i < 3; i++)
            {
                int n = 0;
                switch (i)
                {
                    case 0:
                        n = 5;
                        break;
                    case 1:
                        n = 3;
                        break;
                    case 2:
                        n = 1;
                        break;
                }
                double k = ((double)n + hue / 60.0) % 6.0;
                double val = value - value * saturation * Math.Max(0.0, Math.Min(Math.Min(k, 4.0 - k), 1.0));
                array[i] = (byte)Math.Round(val * 255.0);
            }
            result = Color.FromArgb(array[0], array[1], array[2]);
        }

        public static void RGBtoHSV(int r, int g, int b, out HSV result)
        {
            _ = (double)r / 255.0;
            _ = (double)g / 255.0;
            _ = (double)b / 255.0;
            double val = Math.Max(r, Math.Max(g, b));
            double num2 = val - (double)Math.Min(r, Math.Min(g, b));
            double hue = Color.FromArgb(r, g, b).GetHue();
            double saturation = ((val == 0.0) ? 0.0 : (num2 / val));
            result = new HSV
            {
                Hue = hue,
                Saturation = saturation,
                Value = val / 255.0
            };
        }
    }
}