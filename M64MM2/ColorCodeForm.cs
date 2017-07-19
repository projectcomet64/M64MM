using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M64MM2.Properties;

using static M64MM2.Utils;


namespace M64MM2
{
    public partial class ColorCodeForm : Form
    {
        ColorMap hatMap = new ColorMap();
        ColorMap hairMap = new ColorMap();
        ColorMap skinMap = new ColorMap();
        ColorMap glovesMap = new ColorMap();
        ColorMap pantsMap = new ColorMap();
        ColorMap shoesMap = new ColorMap();

        public ColorCodeForm()
        {
            InitializeComponent();

            hatMap.OldColor = Color.FromArgb(255, 0, 0);
            hatMap.NewColor = additiveColorBlend(hatColorMain.BackColor, hatColorShade.BackColor);

            hairMap.OldColor = Color.FromArgb(115, 6, 0);
            hairMap.NewColor = additiveColorBlend(hairColorMain.BackColor, hairColorShade.BackColor);

            skinMap.OldColor = Color.FromArgb(254, 193, 121);
            skinMap.NewColor = additiveColorBlend(skinColorMain.BackColor, skinColorShade.BackColor);

            glovesMap.OldColor = Color.FromArgb(220, 220, 220);
            glovesMap.NewColor = additiveColorBlend(glovesColorMain.BackColor, glovesColorShade.BackColor);

            pantsMap.OldColor = Color.FromArgb(0, 0, 255);
            pantsMap.NewColor = additiveColorBlend(pantsColorMain.BackColor, pantsColorShade.BackColor);

            shoesMap.OldColor = Color.FromArgb(114, 28, 14);
            shoesMap.NewColor = additiveColorBlend(shoesColorMain.BackColor, shoesColorShade.BackColor);
        }

        private void marioSprite_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp = new Bitmap(Resources.CC_Mario_big);

            hatMap.NewColor = additiveColorBlend(hatColorMain.BackColor, hatColorShade.BackColor);
            hairMap.NewColor = additiveColorBlend(hairColorMain.BackColor, hairColorShade.BackColor);
            skinMap.NewColor = additiveColorBlend(skinColorMain.BackColor, skinColorShade.BackColor);
            glovesMap.NewColor = additiveColorBlend(glovesColorMain.BackColor, glovesColorShade.BackColor);
            pantsMap.NewColor = additiveColorBlend(pantsColorMain.BackColor, pantsColorShade.BackColor);
            shoesMap.NewColor = additiveColorBlend(shoesColorMain.BackColor, shoesColorShade.BackColor);

            // Set the image attribute's color mappings
            ColorMap[] colorMap = new ColorMap[6];
            colorMap[0] = hatMap;
            colorMap[1] = hairMap;
            colorMap[2] = skinMap;
            colorMap[3] = glovesMap;
            colorMap[4] = pantsMap;
            colorMap[5] = shoesMap;

            ImageAttributes attr = new ImageAttributes();
            attr.SetRemapTable(colorMap);

            // Draw using the color map
            dynamic rect = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            g.Clear(BackColor);
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        private Color additiveColorBlend(Color mainColor, Color shadeColor)
        {
            int r = Math.Min((int)(shadeColor.R * 1.25) - (int)((shadeColor.R - mainColor.R) / 2.5), 255);
            int g = Math.Min((int)(shadeColor.G * 1.25) - (int)((shadeColor.G - mainColor.G) / 2.5), 255);
            int b = Math.Min((int)(shadeColor.B * 1.25) - (int)((shadeColor.B - mainColor.B) / 2.5), 255);

            Color result = Color.FromArgb(r, g, b);
            return result;
        }

        private void colorButton_Click(object s, EventArgs e)
        {
            Button sender = (Button) s;
            colorDialog.Color = sender.BackColor;

            if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
            if (!sender.Enabled) return;

            sender.BackColor = colorDialog.Color;
            marioSprite.Refresh();

            byte[] colorData = new byte[4];
            colorData[0] = sender.BackColor.R;
            colorData[1] = sender.BackColor.G;
            colorData[2] = sender.BackColor.B;
            colorData[3] = 0;

            int address = 0;
            switch (sender.Name)
            {
                case "pantsColorShade":
                    address = 0x7EC20;
                    break;
                case "pantsColorMain":
                    address = 0x7EC28;
                    break;
                case "hatColorShade":
                    address = 0x7EC38;
                    break;
                case "hatColorMain":
                    address = 0x7EC40;
                    break;
                case "glovesColorShade":
                    address = 0x7EC50;
                    break;
                case "glovesColorMain":
                    address = 0x7EC58;
                    break;
                case "shoesColorShade":
                    address = 0x7EC68;
                    break;
                case "shoesColorMain":
                    address = 0x7EC70;
                    break;
                case "skinColorShade":
                    address = 0x7EC80;
                    break;
                case "skinColorMain":
                    address = 0x7EC88;
                    break;
                case "hairColorShade":
                    address = 0x7EC98;
                    break;
                case "hairColorMain":
                    address = 0x7ECA0;
                    break;
            }

            if (address > 0)
            {
                WriteBytes(BaseAddress + address, SwapEndian(colorData, 4));
            }
        }
    }
}
