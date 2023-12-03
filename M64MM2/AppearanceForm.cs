using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keyshift.Core.Classes;
using Keyshift.Core.Classes.Rack;
using M64MM.Utils;
using M64MM.Utils.TimelineTools;
using M64MM2.Properties;
using static M64MM.Utils.Core;
using static M64MM.Utils.Looks;

namespace M64MM2
{
    public partial class AppearanceForm : Form
    {
        readonly Random _rand = new Random();

        private readonly List<ColorCodeGS> _currentSelection = new List<ColorCodeGS>();

        ColorMap hatMap = new ColorMap();
        ColorMap hairMap = new ColorMap();
        ColorMap skinMap = new ColorMap();
        ColorMap glovesMap = new ColorMap();
        ColorMap pantsMap = new ColorMap();
        ColorMap shoesMap = new ColorMap();

        private bool _keyframeable = false;

        private Timeline _appearanceTimeline = Core.TimelineCollection.Timelines["appearance"].Timeline;

        private FloatKeyframeRack _krShadingX, _krShadingY, _krShadingZ;

        private BindingList<ColorPart> _chosenParts = new BindingList<ColorPart>();
        public AppearanceForm()
        {
            InitializeComponent();
            LightsetChanged += (sender, lightset) => { UpdateColorPartList(); };
            lbColors.DrawMode = DrawMode.OwnerDrawFixed;
            lbColors.ItemHeight = 16;

            switch (modelStatus)
            {
                case ModelHeaderType.CLASSIC:
                    {
                        CurrentLightset = DefaultLightsets.ClassicLightset;
                        break;
                    }
                case ModelHeaderType.SPARK:
                    {
                        CurrentLightset = DefaultLightsets.SparkLightset;
                        break;
                    }
            }

            cbRandMode.SelectedIndex = 0;
            if (lbColors.Items.Count > 0)
            {
                lbColors.SelectedIndex = 0;
            }

            hatMap.OldColor = Color.FromArgb(255, 0, 0);

            hairMap.OldColor = Color.FromArgb(115, 6, 0);

            skinMap.OldColor = Color.FromArgb(254, 193, 121);

            glovesMap.OldColor = Color.FromArgb(220, 220, 220);

            pantsMap.OldColor = Color.FromArgb(0, 0, 255);

            shoesMap.OldColor = Color.FromArgb(114, 28, 14);

            marioSprite_Paint(marioSprite, new PaintEventArgs(Graphics.FromImage(marioSprite.Image), Rectangle.Empty));

            lbColors.DataSource = _chosenParts;

            foreach (ColorCodeGS cc in colorCodeGamesharks)
            {
                lbCCs.Items.Add(cc);
                clbRandSel.Items.Add(cc);
            }

            LoadFromGame(null, null);
        }

        void colorButton_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            colorDialog.Color = senderButton.BackColor;

            if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
            if (!senderButton.Enabled) return;

            senderButton.BackColor = colorDialog.Color;
            marioSprite.Refresh();

            if ((!IsEmuOpen || BaseAddress == 0) && (modelStatus != ModelHeaderType.CLASSIC || modelStatus != ModelHeaderType.SPARK)
                && lbColors.SelectedItem == null) return;

            switch (senderButton.Name)
            {
                case "btnLightCol":
                    ((ColorPart)lbColors.SelectedItem).LightColor = senderButton.BackColor;
                    break;
                case "btnDarkCol":
                    ((ColorPart)lbColors.SelectedItem).DarkColor = senderButton.BackColor;
                    break;
            }
            WriteColorPart((ColorPart)lbColors.SelectedItem);
            lbColors.Refresh();
        }

        public static void WriteColorPart(ColorPart cPart)
        {

            cPart.CommitColorsToRam();
        }

        void DefaultAllColors()
        {
            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.LightColor = cPart.DefaultLightColor;
                cPart.DarkColor = cPart.DefaultDarkColor;
                cPart.CommitColorsToRam();
            }
        }

        void ApplyAllColors(bool refreshList = true)
        {
            if ((!IsEmuOpen || BaseAddress == 0) && (modelStatus != ModelHeaderType.CLASSIC || modelStatus != ModelHeaderType.SPARK)) return;

            btnLightCol.BackColor = ((ColorPart)lbColors.SelectedItem).LightColor;
            btnDarkCol.BackColor = ((ColorPart)lbColors.SelectedItem).DarkColor;

            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.CommitColorsToRam();
            }

            if (refreshList && !tmrRandom.Enabled)
            {
                lbColors_SelectedValueChanged(null, null);
                lbColors.Refresh();
            }
        }

        void OpenCopyPasteForm(object sender, EventArgs e)
        {
            CopyPasteForm form = new CopyPasteForm();

            Button senderButton = (Button)sender;

            if (senderButton.Name == btnImportCode.Name)
            {
                form.lblInfo.Text = Resources.colorCodeImportMsg;
                form.btnFile.Text = Resources.colorCodeFromFile;
                form.ShowDialog(this);
            }
            else if (senderButton.Name == btnExportCode.Name)
            {
                form.lblInfo.Text = Resources.colorCodeExportMsg;
                form.btnCancel.Visible = false;
                form.tbColorCode.ReadOnly = true;
                form.tbColorCode.Text = GenerateColorCode();
                form.btnFile.Text = Resources.colorCodeToFile;
                form.ShowDialog(this);
            }
        }

        public void ParseColorCode(string code)
        {
            // all my homies hate U+000D CARRIAGE RETURN 
            FromColorCode(code.Replace("\r", ""), _chosenParts.ToList());
            marioSprite.Refresh();
            lbColors.Refresh();
            ApplyAllColors();
        }

        public void ChangeShadow()
        {
            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.ChangeLightDirection(lightDirectionPanel1.LightX, (sbyte)-lightDirectionPanel1.LightY , (sbyte)-lightDirectionPanel1.LightZ);
            }
        }

        public void ChangeShadow(byte X, byte Y, byte Z)
        {
            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.ChangeLightDirection(X, Y, Z);
            }
        }

        string GenerateColorCode()
        {
            StringBuilder code = new StringBuilder();

            foreach (ColorPart cPart in _chosenParts)
            {
                code.Append(cPart.ToGameshark());
            }

            return code.ToString();
        }

        void ResetColors(object sender, EventArgs e)
        {
            marioSprite.Refresh();
            DefaultAllColors();
            lbColors.Refresh();
        }

        void LoadFromGame(object sender, EventArgs e)
        {
            if ((!IsEmuOpen || BaseAddress == 0) && (modelStatus != ModelHeaderType.CLASSIC || modelStatus != ModelHeaderType.SPARK)) return;
            long seg04addr = SegmentedToVirtual(0x04000000);
            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.PullColorsFromRam();
            }
            lbColors.Refresh();
            marioSprite.Refresh();
        }

        void marioSprite_DoubleClick(object sender, EventArgs e)
        {
            if (!tmrRandom.Enabled)
            {
                _currentSelection.Clear();
                _currentSelection.AddRange(clbRandSel.CheckedItems.Cast<ColorCodeGS>());
                tmrRandom.Start();
                lbColors.Refresh();
            }
            else
            {
                tmrRandom.Stop();
                lbColors.Refresh();
            }

        }

        public void ExecuteRandomCC()
        {

            int mode = cbRandMode.SelectedIndex;
            switch (mode)
            {
                case 0:
                    foreach (ColorPart cPart in _chosenParts)
                    {
                        cPart.LightColor = Color.FromArgb(_rand.Next(255), _rand.Next(255), _rand.Next(255));
                        cPart.DarkColor = Color.FromArgb(_rand.Next(255), _rand.Next(255), _rand.Next(255));
                    }
                    break;
                case 1:
                    if (_currentSelection.Count == 0) break;
                    // FUCK CARRIAGE RETURN
                    FromColorCode(_currentSelection[_rand.Next(_currentSelection.Count)].Gameshark.Replace("\r", ""),
                        _chosenParts.ToList());
                    break;
            }

            marioSprite.Refresh();
            ApplyAllColors();
        }

        void UpdateTrackbar(object sender, EventArgs e)
        {
            TrackBar changedBar = ((TrackBar)sender);
            ShadowAxis part = ShadowAxis.X;
            switch (changedBar.Name)
            {
                case "tbLeftRight":
                    part = ShadowAxis.X;
                    break;
                case "tbBottomTop":
                    part = ShadowAxis.Y;
                    break;
                case "tbBackFront":
                    part = ShadowAxis.Z;
                    break;
            }

            if (_keyframeable && cbRecord.Checked)
            {
                switch (part)
                {
                    case ShadowAxis.X:
                        _appearanceTimeline.AddValueToRack("shadeX");
                        break;
                    case ShadowAxis.Y:
                        _appearanceTimeline.AddValueToRack("shadeY");
                        break;
                    case ShadowAxis.Z:
                        _appearanceTimeline.AddValueToRack("shadeZ");
                        break;
                }
            }

            ChangeShadow();
        }


        void ResetShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = 0x28;
            tbBottomTop.Value = 0x28;
            tbBackFront.Value = 0x28;
        }

        void RandomizeShadows(object sender, EventArgs e)
        {
            tbLeftRight.Value = _rand.Next(-127, 128);
            tbBottomTop.Value = _rand.Next(-127, 128);
            tbBackFront.Value = _rand.Next(-127, 128);
        }

        private void lbColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush textColor = new SolidBrush(((Control)sender).ForeColor);
            SolidBrush SelectedColor = new SolidBrush(Color.White);
            SolidBrush lightColor = new SolidBrush(((ColorPart)lbColors.Items[e.Index]).LightColor);
            SolidBrush darkColor = new SolidBrush(((ColorPart)lbColors.Items[e.Index]).DarkColor);
            if (tmrRandom.Enabled)
            {
                e.Graphics.DrawImageUnscaled(Resources.randomSlot, new Point(e.Bounds.X, e.Bounds.Y));
                e.Graphics.DrawImageUnscaled(Resources.randomSlot, new Point(e.Bounds.X + 16, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(lightColor, new Rectangle(new Point(e.Bounds.X, e.Bounds.Y), new Size(16, 16)));
                e.Graphics.FillRectangle(darkColor, new Rectangle(new Point(e.Bounds.X + 16, e.Bounds.Y), new Size(16, 16)));
            }
            e.Graphics.DrawString(((ColorPart)lbColors.Items[e.Index]).Name,
                DefaultFont,
                ((ListBox)sender).SelectedIndex == e.Index ? SelectedColor : textColor,
                new Point(e.Bounds.X + 32, e.Bounds.Y));
        }

        private void lbColors_SelectedValueChanged(object sender, EventArgs e)
        {
            btnLightCol.BackColor = ((ColorPart)lbColors.SelectedItem).LightColor;
            btnDarkCol.BackColor = ((ColorPart)lbColors.SelectedItem).DarkColor;
            lbColors.Refresh();
        }

        private void btnTFCC2SCC_Click(object sender, EventArgs e)
        {
            ColorPart hatShirt = _chosenParts.FirstOrDefault(x => x.Name == "Hat");
            IEnumerable<ColorPart> hatTransform = _chosenParts.Where(x => x.Name == "Arms" || x.Name == "Shoulders" || x.Name == "Shirt");

            ColorPart overall = _chosenParts.FirstOrDefault(x => x.Name == "Overalls Top");
            IEnumerable<ColorPart> overallTransform = _chosenParts.Where(x => x.Name.StartsWith("Leg") || x.Name == "Overalls Bottom");

            foreach (ColorPart cp in hatTransform)
            {
                cp.LightColor = hatShirt.LightColor;
                cp.DarkColor = hatShirt.DarkColor;
            }

            foreach (ColorPart cp in overallTransform)
            {
                cp.LightColor = overall.LightColor;
                cp.DarkColor = overall.DarkColor;
            }
            ApplyAllColors();
        }

        private void btnTFShirtPants_Click(object sender, EventArgs e)
        {
            ColorPart shirt = _chosenParts.FirstOrDefault(x => x.Name == "Shirt");
            ColorPart overall = _chosenParts.FirstOrDefault(x => x.Name == "Overalls Top");

            IEnumerable<ColorPart> shirtTransform = _chosenParts.Where(x => x.Name == "Arms" || x.Name == "Shoulders" || x.Name == "Overalls Top");
            IEnumerable<ColorPart> overallTransform = _chosenParts.Where(x => x.Name.StartsWith("Leg") || x.Name == "Overalls Bottom");

            foreach (ColorPart cp in overallTransform)
            {
                cp.LightColor = overall.LightColor;
                cp.DarkColor = overall.DarkColor;
            }

            foreach (ColorPart cp in shirtTransform)
            {
                cp.LightColor = shirt.LightColor;
                cp.DarkColor = shirt.DarkColor;
            }
            ApplyAllColors();
        }

        private void btnTFShorties_Click(object sender, EventArgs e)
        {
            ColorPart skin = _chosenParts.FirstOrDefault(x => x.Name == "Skin");
            ColorPart legbottom = _chosenParts.FirstOrDefault(x => x.Name == "Leg Bottom");

            legbottom.LightColor = skin.LightColor;
            legbottom.DarkColor = skin.DarkColor;

            ApplyAllColors();
        }

        private void btnTFSCCSleeves_Click(object sender, EventArgs e)
        {
            ColorPart skin = _chosenParts.FirstOrDefault(x => x.Name == "Skin");
            ColorPart arm = _chosenParts.FirstOrDefault(x => x.Name == "Arms");

            arm.LightColor = skin.LightColor;
            arm.DarkColor = skin.DarkColor;

            ApplyAllColors();
        }

        private void btnTFSCCHardShade(object sender, EventArgs e)
        {
            foreach (ColorPart cPart in _chosenParts)
            {
                cPart.DarkColor = Color.Black;
            }

            ApplyAllColors();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnTFCustomRestore_Click(object sender, EventArgs e)
        {
            IEnumerable<ColorPart> customTransform = _chosenParts.Where(x => x.Name.StartsWith("Custom"));

            foreach (ColorPart cPart in customTransform)
            {
                cPart.LightColor = Color.White;
                cPart.DarkColor = Color.FromArgb(128, 128, 128);
            }

            ApplyAllColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmsTransforms.Show((Control)sender, ((Control)sender).Width / 2, ((Control)sender).Height / 2);
        }

        private void tmrRandom_Tick(object sender, EventArgs e)
        {
            ExecuteRandomCC();
        }

        /// <summary>
        /// Blends two colors together via a quasi-additive formula and produces a result that's somewhat similar to SM64's lighting algorithm.
        /// </summary>
        /// <param name="mainColor">Diffuse color</param>
        /// <param name="shadeColor">Ambient color</param>
        /// <returns></returns>
        Color BlendColors(Color mainColor, Color shadeColor)
        {
            int r = (int)Math.Min((shadeColor.R / 1.25) + (mainColor.R / 2.0), 255);
            int g = (int)Math.Min((shadeColor.G / 1.25) + (mainColor.G / 2.0), 255);
            int b = (int)Math.Min((shadeColor.B / 1.25) + (mainColor.B / 2.0), 255);

            Color result = Color.FromArgb(r, g, b);
            return result;
        }

        public void marioSprite_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bmp = new Bitmap(Resources.CC_Mario_big);
            if (_chosenParts == null || _chosenParts.Count == 0 || !(CurrentLightset.NormalColorcodeCompatible || CurrentLightset.SparkCompatible)) return;

            // Ho boy.
            ColorPart hatCol = _chosenParts.FirstOrDefault(x => x.Name == "Hat" || x.Name == "Hat & Shirt" || x.Name == "X3S Tint");
            ColorPart hairCol = _chosenParts.FirstOrDefault(x => x.Name == "Hair" || x.Name == "X3S Tint");
            ColorPart skinCol = _chosenParts.FirstOrDefault(x => x.Name == "Skin" || x.Name == "X3S Tint");
            ColorPart overallsCol = _chosenParts.FirstOrDefault(x => x.Name == "Overalls" || x.Name == "Overalls Top" || x.Name == "X3S Tint");
            ColorPart gloveCol = _chosenParts.FirstOrDefault(x => x.Name == "Gloves" || x.Name == "X3S Tint");
            ColorPart shoeCol = _chosenParts.FirstOrDefault(x => x.Name == "Shoes" || x.Name == "X3S Tint");

            hatMap.NewColor = BlendColors(hatCol.LightColor, hatCol.DarkColor);
            hairMap.NewColor = BlendColors(hairCol.LightColor, hairCol.DarkColor);
            skinMap.NewColor = BlendColors(skinCol.LightColor, skinCol.DarkColor);
            glovesMap.NewColor = BlendColors(gloveCol.LightColor, gloveCol.DarkColor);
            pantsMap.NewColor = BlendColors(overallsCol.LightColor, overallsCol.DarkColor);
            shoesMap.NewColor = BlendColors(shoeCol.LightColor, shoeCol.DarkColor);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadColorCodeRepo();
            lbCCs.Items.Clear();
            clbRandSel.Items.Clear();
            foreach (ColorCodeGS cc in colorCodeGamesharks)
            {
                lbCCs.Items.Add(cc);
                clbRandSel.Items.Add(cc);
            }
        }

        private void lbCCs_DoubleClick(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                ParseColorCode(((ColorCodeGS)((ListBox)sender).SelectedItem).Gameshark);
                marioSprite.Refresh();
            }
        }

        private void btnKeyframe_Click(object sender, EventArgs e)
        {
            _krShadingX = new FloatKeyframeRack(() =>
            {
                float valu = 0;
                Invoke(new MethodInvoker(() =>
                {
                    valu = tbLeftRight.Value;
                }));
                return valu;
            });

            _krShadingY = new FloatKeyframeRack(() =>
            {
                float valu = 0;
                Invoke(new MethodInvoker(() =>
                {
                    valu = tbBottomTop.Value;
                }));
                return valu;
            });

            _krShadingZ = new FloatKeyframeRack(() =>
            {
                float valu = 0;
                Invoke(new MethodInvoker(() =>
                {
                    valu = tbBackFront.Value;
                }));
                return valu;
            });

            // Only one is needed to change the entire set
            _krShadingX.CurrentFrameChanged += (() => {
                ChangeShadow((byte)Math.Round(_krShadingX.CalculateInterpolation()),
                    (byte)Math.Round(_krShadingY.CalculateInterpolation()),
                    (byte)Math.Round(_krShadingZ.CalculateInterpolation()));
            });

            _krShadingX.Name = "Shading Horz.";
            _krShadingY.Name = "Shading Vert.";
            _krShadingZ.Name = "Shading Depth";
            _appearanceTimeline.AddRack("shadeX", _krShadingX);
            _appearanceTimeline.AddRack("shadeY", _krShadingY);
            _appearanceTimeline.AddRack("shadeZ", _krShadingZ);
            _keyframeable = true;
            btnKeyframe.Enabled = false;
            cbRecord.Enabled = true;
        }

        private void tbBackFront_Scroll(object sender, EventArgs e) {
            lightDirectionPanel1.SetLightDirection(lightDirectionPanel1.LightX, lightDirectionPanel1.LightY, (sbyte)tbBackFront.Value);
        }

        private void lightDirectionPanel1_ValueChange(object sender, EventArgs e)
        {
            ChangeShadow();
        }

        private void UpdateColorPartList()
        {
            _chosenParts = new BindingList<ColorPart>(CurrentLightset.Parts);
            _chosenParts.ResetBindings();
            lbColors.DataSource = _chosenParts;
            lbColors.ResetBindings();
        }

        private void cbPartListOverride_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Again, .ToList() clones.
            switch (cbPartListOverride.SelectedIndex)
            {
                case 0:
                    {
                        CurrentLightset = DefaultLightsets.ClassicLightset;
                        if (modelStatus != ModelHeaderType.CLASSIC)
                        {
                            MessageBox.Show(
                                string.Format(Resources.incompatibleModelMsg, "CLASSIC", modelStatus.ToString()), "Whoa!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    }
                case 1:
                    {
                        CurrentLightset = DefaultLightsets.SparkLightset;
                        if (modelStatus != ModelHeaderType.SPARK)
                        {
                            MessageBox.Show(
                                string.Format(Resources.incompatibleModelMsg, "SPARK", modelStatus.ToString()), "Whoa!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    }
                case 2:
                    {
                        CurrentLightset = DefaultLightsets.X3SLightset;
                        MessageBox.Show(
                                // The most C# developer thing ever: using LINQ in unexpected places
                                Resources.x3sMsg, $"A{string.Join("", Enumerable.Range(1, _rand.Next(1, 10)).Select(x => "HA").ToArray())}HA",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                case 3:
                    {
                        CurrentLightset = DefaultLightsets.PeachGrass;
                        MessageBox.Show(
                            // Refer to the comment above
                            Resources.peachGrassMsg, $"A{string.Join("", Enumerable.Range(1, _rand.Next(2, 6)).Select(x => "HA").ToArray())}- WAIT NO-",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
            }
            LoadFromGame(this, EventArgs.Empty);
        }
    }
}
