using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using M64MM2.Properties;

using static M64MM2.Utils;


namespace M64MM2
{
    public partial class AppearanceForm : Form
    {
        readonly Random rand;

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

        static readonly int[] shadowAddresses = {
            0x07EC30,
            0x07EC48,
            0x07EC60,
            0x07EC78,
            0x07EC90,
            0x07ECA8
        };

        public AppearanceForm()
        {
            InitializeComponent();

            rand = new Random();

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

            // Set the image attribute'sender color mappings
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

        //Blends two colors together via a quasi-additive formula and produces a result that'sender somewhat similar to SM64'sender lighting algorithm.
        Color blendColors(Color mainColor, Color shadeColor)
        {
            int r = (int)Math.Min((shadeColor.R / 1.25) + (mainColor.R / 2.0), 255);
            int g = (int)Math.Min((shadeColor.G / 1.25) + (mainColor.G / 2.0), 255);
            int b = (int)Math.Min((shadeColor.B / 1.25) + (mainColor.B / 2.0), 255);

            Color result = Color.FromArgb(r, g, b);
            return result;
        }


        void colorButton_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button) sender;
            colorDialog.Color = senderButton.BackColor;

            if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
            if (!senderButton.Enabled) return;

            senderButton.BackColor = colorDialog.Color;
            marioSprite.Refresh();

            if (!IsEmuOpen || BaseAddress == 0) return;


            byte[] colorData = new byte[4];
            colorData[0] = senderButton.BackColor.R;
            colorData[1] = senderButton.BackColor.G;
            colorData[2] = senderButton.BackColor.B;
            colorData[3] = 0;

            int address = 0;
            switch (senderButton.Name)
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

        void applyAllColors()
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            byte[] colorData = new byte[4];
            colorData[3] = 0;

            colorData[0] = pantsColorShade.BackColor.R;
            colorData[1] = pantsColorShade.BackColor.G;
            colorData[2] = pantsColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC20, SwapEndian(colorData, 4));

            colorData[0] = pantsColorMain.BackColor.R;
            colorData[1] = pantsColorMain.BackColor.G;
            colorData[2] = pantsColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC28, SwapEndian(colorData, 4));

            colorData[0] = hatColorShade.BackColor.R;
            colorData[1] = hatColorShade.BackColor.G;
            colorData[2] = hatColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC38, SwapEndian(colorData, 4));

            colorData[0] = hatColorMain.BackColor.R;
            colorData[1] = hatColorMain.BackColor.G;
            colorData[2] = hatColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC40, SwapEndian(colorData, 4));

            colorData[0] = glovesColorShade.BackColor.R;
            colorData[1] = glovesColorShade.BackColor.G;
            colorData[2] = glovesColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC50, SwapEndian(colorData, 4));

            colorData[0] = glovesColorMain.BackColor.R;
            colorData[1] = glovesColorMain.BackColor.G;
            colorData[2] = glovesColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC58, SwapEndian(colorData, 4));

            colorData[0] = shoesColorShade.BackColor.R;
            colorData[1] = shoesColorShade.BackColor.G;
            colorData[2] = shoesColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC68, SwapEndian(colorData, 4));

            colorData[0] = shoesColorMain.BackColor.R;
            colorData[1] = shoesColorMain.BackColor.G;
            colorData[2] = shoesColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC70, SwapEndian(colorData, 4));

            colorData[0] = skinColorShade.BackColor.R;
            colorData[1] = skinColorShade.BackColor.G;
            colorData[2] = skinColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC80, SwapEndian(colorData, 4));

            colorData[0] = skinColorMain.BackColor.R;
            colorData[1] = skinColorMain.BackColor.G;
            colorData[2] = skinColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC88, SwapEndian(colorData, 4));

            colorData[0] = hairColorShade.BackColor.R;
            colorData[1] = hairColorShade.BackColor.G;
            colorData[2] = hairColorShade.BackColor.B;
            WriteBytes(BaseAddress + 0x07EC98, SwapEndian(colorData, 4));

            colorData[0] = hairColorMain.BackColor.R;
            colorData[1] = hairColorMain.BackColor.G;
            colorData[2] = hairColorMain.BackColor.B;
            WriteBytes(BaseAddress + 0x07ECA0, SwapEndian(colorData, 4));
        }

        void openCopyPasteForm(object sender, EventArgs e)
        {
            CopyPasteForm form = new CopyPasteForm();

            Button senderButton = (Button)sender;

            if (senderButton.Name == btnImportCode.Name)
            {
                form.lblInfo.Text = Resources.colorCodeImportMsg;

                form.ShowDialog(this);
            }
            else if (senderButton.Name == btnExportCode.Name)
            {
                form.lblInfo.Text = Resources.colorCodeExportMsg;
                form.btnCancel.Visible = false;
                form.tbColorCode.ReadOnly = true;
                form.tbColorCode.Lines = GenerateColorCode();

                form.ShowDialog(this);
            }
        }

        public void ParseColorCode(string code)
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
                        hatColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x40:
                        hatColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x98:
                        hairColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0xA0:
                        hairColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x80:
                        skinColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x88:
                        skinColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x50:
                        glovesColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x58:
                        glovesColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x20:
                        pantsColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x28:
                        pantsColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x68:
                        shoesColorShade.BackColor = Color.FromArgb(r, g, b);
                        break;
                    case 0x70:
                        shoesColorMain.BackColor = Color.FromArgb(r, g, b);
                        break;
                }
            }

            marioSprite.Refresh();
            applyAllColors();

            askSetDefaultColors();
        }

        string[] GenerateColorCode()
        {
            List<string> code = new List<string>();

            foreach (Control control in this.grpColor.Controls)
            {
                Button button = control as Button;
                if (button == null || !string.IsNullOrWhiteSpace(button.Text)) continue;

                string[] addressToWrite = new string[2];
                switch (button.Name)
                {
                    case "hatColorShade":
                        addressToWrite[0] = "07EC38";
                        addressToWrite[1] = "07EC3A";
                        break;
                    case "hatColorMain":
                        addressToWrite[0] = "07EC40";
                        addressToWrite[1] = "07EC42";
                        break;
                    case "hairColorShade":
                        addressToWrite[0] = "07EC98";
                        addressToWrite[1] = "07EC9A";
                        break;
                    case "hairColorMain":
                        addressToWrite[0] = "07ECA0";
                        addressToWrite[1] = "07ECA2";
                        break;
                    case "skinColorShade":
                        addressToWrite[0] = "07EC80";
                        addressToWrite[1] = "07EC82";
                        break;
                    case "skinColorMain":
                        addressToWrite[0] = "07EC88";
                        addressToWrite[1] = "07EC8A";
                        break;
                    case "glovesColorShade":
                        addressToWrite[0] = "07EC50";
                        addressToWrite[1] = "07EC52";
                        break;
                    case "glovesColorMain":
                        addressToWrite[0] = "07EC58";
                        addressToWrite[1] = "07EC5A";
                        break;
                    case "pantsColorShade":
                        addressToWrite[0] = "07EC20";
                        addressToWrite[1] = "07EC22";
                        break;
                    case "pantsColorMain":
                        addressToWrite[0] = "07EC28";
                        addressToWrite[1] = "07EC2A";
                        break;
                    case "shoesColorShade":
                        addressToWrite[0] = "07EC68";
                        addressToWrite[1] = "07EC6A";
                        break;
                    case "shoesColorMain":
                        addressToWrite[0] = "07EC70";
                        addressToWrite[1] = "07EC72";
                        break;
                }

                code.Add("81" + addressToWrite[0] + " " + button.BackColor.R.ToString("X2") + button.BackColor.G.ToString("X2"));
                code.Add("81" + addressToWrite[1] + " " + button.BackColor.B.ToString("X2") + "00");
            }

            return code.ToArray();
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

            marioSprite.Refresh();
            applyAllColors();
        }

        void loadFromGame(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

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
            
            askSetDefaultColors();
        }

        void askSetDefaultColors()
        {
            if (MessageBox.Show(this, Resources.setDefaultColorsMsg, Resources.setDefaultColorsMsgTitle, MessageBoxButtons.YesNo) == DialogResult.No)
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

        void marioSprite_DoubleClick(object sender, EventArgs e)
        {
            if (!randomizerTimer.Enabled)
                randomizerTimer.Start();
            else
                randomizerTimer.Stop();
        }

        private void randomizerTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control control in this.grpColor.Controls)
            {
                if (control is Button && String.IsNullOrEmpty(control.Text))
                {
                    control.BackColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                }
            }

            marioSprite.Refresh();
            applyAllColors();
        }


        void resetShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = 0x28;
            tbBottomTop.Value = 0x28;
            tbBackFront.Value = -0x28;

            foreach (Control c in this.grpShading.Controls)
            {
                if (c is TrackBar)
                {
                    changeShadows(c, null);
                }
            }
        }

        void randomizeShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = rand.Next(-127, 128);
            tbBottomTop.Value = rand.Next(-127, 128);
            tbBackFront.Value = rand.Next(-127, 128);

            foreach (Control c in this.grpShading.Controls)
            {
                if (c is TrackBar)
                {
                    changeShadows(c, null);
                }
            }
        }

        void changeShadows(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            TrackBar senderBar = (TrackBar) sender;
            byte[] data = new byte[1];

            foreach (int address in shadowAddresses)
            {
                if (senderBar.Name == "tbLeftRight")
                {
                    data[0] = (byte)senderBar.Value;
                    WriteBytes(BaseAddress + address + 3, data);
                }
                else if (senderBar.Name == "tbBottomTop")
                {
                    data[0] = (byte)senderBar.Value;
                    WriteBytes(BaseAddress + address + 2, data);
                }
                else if (senderBar.Name == "tbBackFront")
                {
                    data[0] = (byte)-senderBar.Value;
                    WriteBytes(BaseAddress + address + 1, data);
                }
            }
        }
    }
}
