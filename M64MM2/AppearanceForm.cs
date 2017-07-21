using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using M64MM2.Properties;

using static M64MM2.Utils;


namespace M64MM2
{
    public partial class AppearanceForm : Form
    {
        Color defaultHatMain = Color.FromArgb(255, 0, 0);
        Color defaultHatShade = Color.FromArgb(127, 0, 0);
        Color defaultHairMain = Color.FromArgb(115, 6, 0);
        Color defaultHairShade = Color.FromArgb(57, 3, 0);
        Color defaultSkinMain = Color.FromArgb(254, 193, 121);
        Color defaultSkinShade = Color.FromArgb(127, 96, 60);
        Color defaultGlovesMain = Color.FromArgb(255, 255, 255);
        Color defaultGlovesShade = Color.FromArgb(127, 127, 127);
        Color defaultPantsMain = Color.FromArgb(0, 0, 255);
        Color defaultPantsShade = Color.FromArgb(0, 0, 127);
        Color defaultShoesMain = Color.FromArgb(114, 28, 14);
        Color defaultShoesShade = Color.FromArgb(47, 14, 7);

        ColorMap hatMap = new ColorMap();
        ColorMap hairMap = new ColorMap();
        ColorMap skinMap = new ColorMap();
        ColorMap glovesMap = new ColorMap();
        ColorMap pantsMap = new ColorMap();
        ColorMap shoesMap = new ColorMap();

        public AppearanceForm()
        {
            InitializeComponent();

            hatMap.OldColor = Color.FromArgb(255, 0, 0);
            hatMap.NewColor = blendColors(hatColorMain.BackColor, hatColorShade.BackColor);

            hairMap.OldColor = Color.FromArgb(115, 6, 0);
            hairMap.NewColor = blendColors(hairColorMain.BackColor, hairColorShade.BackColor);

            skinMap.OldColor = Color.FromArgb(254, 193, 121);
            skinMap.NewColor = blendColors(skinColorMain.BackColor, skinColorShade.BackColor);

            glovesMap.OldColor = Color.FromArgb(220, 220, 220);
            glovesMap.NewColor = blendColors(glovesColorMain.BackColor, glovesColorShade.BackColor);

            pantsMap.OldColor = Color.FromArgb(0, 0, 255);
            pantsMap.NewColor = blendColors(pantsColorMain.BackColor, pantsColorShade.BackColor);

            shoesMap.OldColor = Color.FromArgb(114, 28, 14);
            shoesMap.NewColor = blendColors(shoesColorMain.BackColor, shoesColorShade.BackColor);
        }

        void marioSprite_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp = new Bitmap(Resources.CC_Mario_big);

            hatMap.NewColor = blendColors(hatColorMain.BackColor, hatColorShade.BackColor);
            hairMap.NewColor = blendColors(hairColorMain.BackColor, hairColorShade.BackColor);
            skinMap.NewColor = blendColors(skinColorMain.BackColor, skinColorShade.BackColor);
            glovesMap.NewColor = blendColors(glovesColorMain.BackColor, glovesColorShade.BackColor);
            pantsMap.NewColor = blendColors(pantsColorMain.BackColor, pantsColorShade.BackColor);
            shoesMap.NewColor = blendColors(shoesColorMain.BackColor, shoesColorShade.BackColor);

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
            Rectangle rect = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            g.Clear(BackColor);
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        //Blends two colors together via a quasi-additive formula and produces a result that's somewhat similar to SM64's lighting algorithm.
        Color blendColors(Color mainColor, Color shadeColor)
        {
            int r = (int)Math.Min((shadeColor.R / 1.25) + (mainColor.R / 2.0), 255);
            int g = (int)Math.Min((shadeColor.G / 1.25) + (mainColor.G / 2.0), 255);
            int b = (int)Math.Min((shadeColor.B / 1.25) + (mainColor.B / 2.0), 255);

            Color result = Color.FromArgb(r, g, b);
            return result;
        }


        void colorButton_Click(object s, EventArgs e)
        {
            Button sender = (Button) s;
            colorDialog.Color = sender.BackColor;

            if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
            if (!sender.Enabled) return;

            sender.BackColor = colorDialog.Color;
            marioSprite.Refresh();

            if (!IsEmuOpen || BaseAddress == 0) return;


            byte[] colorData = new byte[4];
            colorData[0] = sender.BackColor.R;
            colorData[1] = sender.BackColor.G;
            colorData[2] = sender.BackColor.B;
            colorData[3] = 0;

            int address = 0;
            switch (sender.Name)
            {
                case "pantsColorShade":
                    address = 0x07EC20;
                    break;
                case "pantsColorMain":
                    address = 0x07EC28;
                    break;
                case "hatColorShade":
                    address = 0x07EC38;
                    break;
                case "hatColorMain":
                    address = 0x07EC40;
                    break;
                case "glovesColorShade":
                    address = 0x07EC50;
                    break;
                case "glovesColorMain":
                    address = 0x07EC58;
                    break;
                case "shoesColorShade":
                    address = 0x07EC68;
                    break;
                case "shoesColorMain":
                    address = 0x07EC70;
                    break;
                case "skinColorShade":
                    address = 0x07EC80;
                    break;
                case "skinColorMain":
                    address = 0x07EC88;
                    break;
                case "hairColorShade":
                    address = 0x07EC98;
                    break;
                case "hairColorMain":
                    address = 0x07ECA0;
                    break;
            }

            if (address > 0)
            {
                WriteBytes(BaseAddress + address, SwapEndian(colorData, 4));
            }
        }

        void importColorCode(object s, EventArgs e)
        {
            
        }

        void exportColorCode(object s, EventArgs e)
        {

        }

        void resetColors(object sender, EventArgs e)
        {
            pantsColorShade.BackColor = defaultPantsShade;
            pantsColorMain.BackColor = defaultPantsMain;
            hatColorShade.BackColor = defaultHatShade;
            hatColorMain.BackColor = defaultHatMain;
            glovesColorShade.BackColor = defaultGlovesShade;
            glovesColorMain.BackColor = defaultGlovesMain;
            shoesColorShade.BackColor = defaultShoesShade;
            shoesColorMain.BackColor = defaultShoesMain;
            skinColorShade.BackColor = defaultSkinShade;
            skinColorMain.BackColor = defaultSkinMain;
            hairColorShade.BackColor = defaultHairShade;
            hairColorMain.BackColor = defaultHairMain;

            if (!IsEmuOpen || BaseAddress == 0) return;


            byte[] colorData = new byte[4];
            colorData[3] = 0;

            colorData[0] = defaultPantsShade.R;
            colorData[1] = defaultPantsShade.G;
            colorData[2] = defaultPantsShade.B;
            WriteBytes(BaseAddress + 0x07EC20, SwapEndian(colorData, 4));

            colorData[0] = defaultPantsMain.R;
            colorData[1] = defaultPantsMain.G;
            colorData[2] = defaultPantsMain.B;
            WriteBytes(BaseAddress + 0x07EC28, SwapEndian(colorData, 4));

            colorData[0] = defaultHatShade.R;
            colorData[1] = defaultHatShade.G;
            colorData[2] = defaultHatShade.B;
            WriteBytes(BaseAddress + 0x07EC38, SwapEndian(colorData, 4));
            
            colorData[0] = defaultHatMain.R;
            colorData[1] = defaultHatMain.G;
            colorData[2] = defaultHatMain.B;
            WriteBytes(BaseAddress + 0x07EC40, SwapEndian(colorData, 4));

            colorData[0] = defaultGlovesShade.R;
            colorData[1] = defaultGlovesShade.G;
            colorData[2] = defaultGlovesShade.B;
            WriteBytes(BaseAddress + 0x07EC50, SwapEndian(colorData, 4));

            colorData[0] = defaultGlovesMain.R;
            colorData[1] = defaultGlovesMain.G;
            colorData[2] = defaultGlovesMain.B;
            WriteBytes(BaseAddress + 0x07EC58, SwapEndian(colorData, 4));

            colorData[0] = defaultShoesShade.R;
            colorData[1] = defaultShoesShade.G;
            colorData[2] = defaultShoesShade.B;
            WriteBytes(BaseAddress + 0x07EC68, SwapEndian(colorData, 4));

            colorData[0] = defaultShoesMain.R;
            colorData[1] = defaultShoesMain.G;
            colorData[2] = defaultShoesMain.B;
            WriteBytes(BaseAddress + 0x07EC70, SwapEndian(colorData, 4));

            colorData[0] = defaultSkinShade.R;
            colorData[1] = defaultSkinShade.G;
            colorData[2] = defaultSkinShade.B;
            WriteBytes(BaseAddress + 0x07EC80, SwapEndian(colorData, 4));

            colorData[0] = defaultSkinMain.R;
            colorData[1] = defaultSkinMain.G;
            colorData[2] = defaultSkinMain.B;
            WriteBytes(BaseAddress + 0x07EC88, SwapEndian(colorData, 4));

            colorData[0] = defaultHairShade.R;
            colorData[1] = defaultHairShade.G;
            colorData[2] = defaultHairShade.B;
            WriteBytes(BaseAddress + 0x07EC98, SwapEndian(colorData, 4));

            colorData[0] = defaultHairMain.R;
            colorData[1] = defaultHairMain.G;
            colorData[2] = defaultHairMain.B;
            WriteBytes(BaseAddress + 0x07ECA0, SwapEndian(colorData, 4));
        }

        void loadFromGame(object sender, EventArgs e)
        {
            byte[] colorData;

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC20, 4), 4);
            pantsColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC28, 4), 4);
            pantsColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC38, 4), 4);
            hatColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC40, 4), 4);
            hatColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC50, 4), 4);
            glovesColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC58, 4), 4);
            glovesColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC68, 4), 4);
            shoesColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC70, 4), 4);
            shoesColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC80, 4), 4);
            skinColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC88, 4), 4);
            skinColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07EC98, 4), 4);
            hairColorShade.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            colorData = SwapEndian(ReadBytes(BaseAddress + 0x07ECA0, 4), 4);
            hairColorMain.BackColor = Color.FromArgb(colorData[0], colorData[1], colorData[2]);

            marioSprite.Refresh();


            if (MessageBox.Show(this, "Set these colors as default?", "Set defaults?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            defaultPantsShade = pantsColorShade.BackColor;
            defaultPantsMain = pantsColorMain.BackColor;
            defaultHatShade = hatColorShade.BackColor;
            defaultHatMain = hatColorMain.BackColor;
            defaultGlovesShade = glovesColorShade.BackColor;
            defaultGlovesMain = glovesColorMain.BackColor;
            defaultShoesShade = shoesColorShade.BackColor;
            defaultShoesMain = shoesColorMain.BackColor;
            defaultSkinShade = skinColorShade.BackColor;
            defaultSkinMain = skinColorMain.BackColor;
            defaultHairShade = hairColorShade.BackColor;
            defaultHairMain = hairColorMain.BackColor;
        }
    }
}
