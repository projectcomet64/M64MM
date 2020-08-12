using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using M64MM.Utils;
using M64MM2.Properties;
using static M64MM.Utils.Core;
using static M64MM.Utils.Looks;

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

            foreach(RoutableColorPart rtc in defaultRoutableParts)
            {
                cbRoutingSource.Items.Add(rtc.Name);
                if (rtc.Address86.Length > 0 && rtc.Address88.Length > 0)
                {
                cbRoutingTarget.Items.Add(rtc.Name);
                }
            }

            cbRoutingSource.SelectedIndex = 0;
            cbRoutingTarget.SelectedIndex = 0;

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
            Button senderButton = (Button)sender;
            colorDialog.Color = senderButton.BackColor;
            VanillaModelColor modelColor = VanillaModelColor.GloveMain;

            if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
            if (!senderButton.Enabled) return;

            senderButton.BackColor = colorDialog.Color;
            marioSprite.Refresh();

            if ((!IsEmuOpen || BaseAddress == 0) && modelStatus != ModelStatus.CLASSIC) return;

            switch (senderButton.Name)
            {
                case "pantsColorShade":
                    modelColor = VanillaModelColor.PantsShade;
                    break;
                case "pantsColorMain":
                    modelColor = VanillaModelColor.PantsMain;
                    break;
                case "hatColorShade":
                    modelColor = VanillaModelColor.HatShade;
                    break;
                case "hatColorMain":
                    modelColor = VanillaModelColor.HatMain;
                    break;
                case "glovesColorShade":
                    modelColor = VanillaModelColor.GloveShade;
                    break;
                case "glovesColorMain":
                    modelColor = VanillaModelColor.GloveMain;
                    break;
                case "shoesColorShade":
                    modelColor = VanillaModelColor.ShoeShade;
                    break;
                case "shoesColorMain":
                    modelColor = VanillaModelColor.ShoeMain;
                    break;
                case "skinColorShade":
                    modelColor = VanillaModelColor.SkinShade;
                    break;
                case "skinColorMain":
                    modelColor = VanillaModelColor.SkinMain;
                    break;
                case "hairColorShade":
                    modelColor = VanillaModelColor.HairShade;
                    break;
                case "hairColorMain":
                    modelColor = VanillaModelColor.HairMain;
                    break;
            }

            WriteColor(modelColor, senderButton.BackColor);
        }

        void applyAllColors()
        {
            if ((!IsEmuOpen || BaseAddress == 0) && modelStatus != ModelStatus.CLASSIC) return;

            WriteColor(VanillaModelColor.PantsShade, pantsColorShade.BackColor);

            WriteColor(VanillaModelColor.PantsMain, pantsColorMain.BackColor);

            WriteColor(VanillaModelColor.HatShade, hatColorShade.BackColor);

            WriteColor(VanillaModelColor.HatMain, hatColorMain.BackColor);

            WriteColor(VanillaModelColor.GloveShade, glovesColorShade.BackColor);

            WriteColor(VanillaModelColor.GloveMain, glovesColorMain.BackColor);

            WriteColor(VanillaModelColor.ShoeShade, shoesColorShade.BackColor);

            WriteColor(VanillaModelColor.ShoeMain, shoesColorMain.BackColor);

            WriteColor(VanillaModelColor.SkinShade, skinColorShade.BackColor);

            WriteColor(VanillaModelColor.SkinMain, skinColorMain.BackColor);

            WriteColor(VanillaModelColor.HairShade, hairColorShade.BackColor);

            WriteColor(VanillaModelColor.HairMain, hairColorMain.BackColor);
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
            FromColorCode(code);
            marioSprite.Refresh();
            loadFromGame(null, null);
        }

        string[] GenerateColorCode()
        {
            List<string> code = new List<string>();
            /*
             NOTE: These will only work on a regular SM64 ROM where Bank 04 is where
             where it should be. Bank 04 changes position in RAM if it were to be longer,
             or someone decided to use a tweak that changes its location in RAM to give more
             space to something else like Skelux's Music Extension (SM64 Editor 2.x)
             */
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
            //TODO: Change the ReadBytes to use SegmentedToVirtual
            if ((!IsEmuOpen || BaseAddress == 0) && modelStatus != ModelStatus.CLASSIC) return;

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

        void updateTrackbar(object sender, EventArgs e)
        {
            TrackBar changedBar = ((TrackBar)sender);
            ShadowParts part = ShadowParts.X;
            switch (changedBar.Name)
            {
                case "tbLeftRight":
                    part = ShadowParts.X;
                    break;
                case "tbBottomTop":
                    part = ShadowParts.Y;
                    break;
                case "tbBackFront":
                    part = ShadowParts.Z;
                    break;
            }
            ChangeShadow(changedBar.Value, part);
        }


        void resetShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = 0x28;
            tbBottomTop.Value = 0x28;
            tbBackFront.Value = 0x28;
        }

        void randomizeShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = rand.Next(-127, 128);
            tbBottomTop.Value = rand.Next(-127, 128);
            tbBackFront.Value = rand.Next(-127, 128);
        }

        private void btnReroute_Click(object sender, EventArgs e)
        {
            RouteColor(defaultRoutableParts[cbRoutingSource.SelectedIndex], defaultRoutableParts[cbRoutingTarget.SelectedIndex]);
        }
    }
}
