namespace M64MM2 {
    partial class AppearanceForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppearanceForm));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.cbPartListOverride = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCCParts = new System.Windows.Forms.Label();
            this.lbPart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLightCol = new System.Windows.Forms.Button();
            this.btnDarkCol = new System.Windows.Forms.Button();
            this.lbColors = new System.Windows.Forms.ListBox();
            this.btnLoadFromGame = new System.Windows.Forms.Button();
            this.btnResetColors = new System.Windows.Forms.Button();
            this.btnExportCode = new System.Windows.Forms.Button();
            this.btnImportCode = new System.Windows.Forms.Button();
            this.marioSprite = new System.Windows.Forms.PictureBox();
            this.grpShading = new System.Windows.Forms.GroupBox();
            this.btnRandomizeShading = new System.Windows.Forms.Button();
            this.btnResetShading = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBackFront = new System.Windows.Forms.TrackBar();
            this.tbBottomTop = new System.Windows.Forms.TrackBar();
            this.tbLeftRight = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sPARKColorcodeTransformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClassicToSpark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSPARKShirtPants = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSPARKShorts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSPARKShortSleeves = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestoreSPARKCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTransforms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grpRand = new System.Windows.Forms.GroupBox();
            this.cbRandMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.clbRandSel = new System.Windows.Forms.CheckedListBox();
            this.grpCCRepo = new System.Windows.Forms.GroupBox();
            this.lbCCs = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tmrRandom = new System.Windows.Forms.Timer(this.components);
            this.lbWarning = new System.Windows.Forms.Label();
            this.grpColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).BeginInit();
            this.grpShading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.grpRand.SuspendLayout();
            this.grpCCRepo.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.cbPartListOverride);
            this.grpColor.Controls.Add(this.label1);
            this.grpColor.Controls.Add(this.lbCCParts);
            this.grpColor.Controls.Add(this.lbPart);
            this.grpColor.Controls.Add(this.label7);
            this.grpColor.Controls.Add(this.label8);
            this.grpColor.Controls.Add(this.btnLightCol);
            this.grpColor.Controls.Add(this.btnDarkCol);
            this.grpColor.Controls.Add(this.lbColors);
            this.grpColor.Controls.Add(this.btnLoadFromGame);
            this.grpColor.Controls.Add(this.btnResetColors);
            this.grpColor.Controls.Add(this.btnExportCode);
            resources.ApplyResources(this.grpColor, "grpColor");
            this.grpColor.Name = "grpColor";
            this.grpColor.TabStop = false;
            // 
            // cbPartListOverride
            // 
            this.cbPartListOverride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartListOverride.FormattingEnabled = true;
            this.cbPartListOverride.Items.AddRange(new object[] {
            resources.GetString("cbPartListOverride.Items"),
            resources.GetString("cbPartListOverride.Items1"),
            resources.GetString("cbPartListOverride.Items2")});
            resources.ApplyResources(this.cbPartListOverride, "cbPartListOverride");
            this.cbPartListOverride.Name = "cbPartListOverride";
            this.cbPartListOverride.SelectedIndexChanged += new System.EventHandler(this.cbPartListOverride_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbCCParts
            // 
            resources.ApplyResources(this.lbCCParts, "lbCCParts");
            this.lbCCParts.Name = "lbCCParts";
            // 
            // lbPart
            // 
            resources.ApplyResources(this.lbPart, "lbPart");
            this.lbPart.Name = "lbPart";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // btnLightCol
            // 
            this.btnLightCol.BackColor = System.Drawing.Color.Red;
            this.btnLightCol.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnLightCol, "btnLightCol");
            this.btnLightCol.Name = "btnLightCol";
            this.btnLightCol.UseVisualStyleBackColor = false;
            this.btnLightCol.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // btnDarkCol
            // 
            this.btnDarkCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDarkCol.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnDarkCol, "btnDarkCol");
            this.btnDarkCol.Name = "btnDarkCol";
            this.btnDarkCol.UseVisualStyleBackColor = false;
            this.btnDarkCol.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // lbColors
            // 
            this.lbColors.FormattingEnabled = true;
            resources.ApplyResources(this.lbColors, "lbColors");
            this.lbColors.Name = "lbColors";
            this.lbColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbColors_DrawItem);
            this.lbColors.SelectedValueChanged += new System.EventHandler(this.lbColors_SelectedValueChanged);
            // 
            // btnLoadFromGame
            // 
            resources.ApplyResources(this.btnLoadFromGame, "btnLoadFromGame");
            this.btnLoadFromGame.Name = "btnLoadFromGame";
            this.btnLoadFromGame.UseVisualStyleBackColor = true;
            this.btnLoadFromGame.Click += new System.EventHandler(this.LoadFromGame);
            // 
            // btnResetColors
            // 
            resources.ApplyResources(this.btnResetColors, "btnResetColors");
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.UseVisualStyleBackColor = true;
            this.btnResetColors.Click += new System.EventHandler(this.ResetColors);
            // 
            // btnExportCode
            // 
            resources.ApplyResources(this.btnExportCode, "btnExportCode");
            this.btnExportCode.Name = "btnExportCode";
            this.btnExportCode.UseVisualStyleBackColor = true;
            this.btnExportCode.Click += new System.EventHandler(this.OpenCopyPasteForm);
            // 
            // btnImportCode
            // 
            resources.ApplyResources(this.btnImportCode, "btnImportCode");
            this.btnImportCode.Name = "btnImportCode";
            this.btnImportCode.UseVisualStyleBackColor = true;
            this.btnImportCode.Click += new System.EventHandler(this.OpenCopyPasteForm);
            // 
            // marioSprite
            // 
            this.marioSprite.BackColor = System.Drawing.Color.Transparent;
            this.marioSprite.Image = global::M64MM2.Properties.Resources.CC_Mario_big;
            resources.ApplyResources(this.marioSprite, "marioSprite");
            this.marioSprite.Name = "marioSprite";
            this.marioSprite.TabStop = false;
            this.marioSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.marioSprite_Paint);
            this.marioSprite.DoubleClick += new System.EventHandler(this.marioSprite_DoubleClick);
            // 
            // grpShading
            // 
            this.grpShading.Controls.Add(this.btnRandomizeShading);
            this.grpShading.Controls.Add(this.btnResetShading);
            this.grpShading.Controls.Add(this.label13);
            this.grpShading.Controls.Add(this.label14);
            this.grpShading.Controls.Add(this.label15);
            this.grpShading.Controls.Add(this.label12);
            this.grpShading.Controls.Add(this.label11);
            this.grpShading.Controls.Add(this.label10);
            this.grpShading.Controls.Add(this.tbBackFront);
            this.grpShading.Controls.Add(this.tbBottomTop);
            this.grpShading.Controls.Add(this.tbLeftRight);
            resources.ApplyResources(this.grpShading, "grpShading");
            this.grpShading.Name = "grpShading";
            this.grpShading.TabStop = false;
            // 
            // btnRandomizeShading
            // 
            resources.ApplyResources(this.btnRandomizeShading, "btnRandomizeShading");
            this.btnRandomizeShading.Name = "btnRandomizeShading";
            this.btnRandomizeShading.UseVisualStyleBackColor = true;
            this.btnRandomizeShading.Click += new System.EventHandler(this.RandomizeShadows);
            // 
            // btnResetShading
            // 
            resources.ApplyResources(this.btnResetShading, "btnResetShading");
            this.btnResetShading.Name = "btnResetShading";
            this.btnResetShading.UseVisualStyleBackColor = true;
            this.btnResetShading.Click += new System.EventHandler(this.ResetShadows);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tbBackFront
            // 
            resources.ApplyResources(this.tbBackFront, "tbBackFront");
            this.tbBackFront.Maximum = 127;
            this.tbBackFront.Minimum = -127;
            this.tbBackFront.Name = "tbBackFront";
            this.tbBackFront.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBackFront.Value = 40;
            this.tbBackFront.ValueChanged += new System.EventHandler(this.UpdateTrackbar);
            // 
            // tbBottomTop
            // 
            resources.ApplyResources(this.tbBottomTop, "tbBottomTop");
            this.tbBottomTop.Maximum = 127;
            this.tbBottomTop.Minimum = -127;
            this.tbBottomTop.Name = "tbBottomTop";
            this.tbBottomTop.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBottomTop.Value = 40;
            this.tbBottomTop.ValueChanged += new System.EventHandler(this.UpdateTrackbar);
            // 
            // tbLeftRight
            // 
            resources.ApplyResources(this.tbLeftRight, "tbLeftRight");
            this.tbLeftRight.Maximum = 127;
            this.tbLeftRight.Minimum = -127;
            this.tbLeftRight.Name = "tbLeftRight";
            this.tbLeftRight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbLeftRight.Value = 40;
            this.tbLeftRight.ValueChanged += new System.EventHandler(this.UpdateTrackbar);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sPARKColorcodeTransformsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // sPARKColorcodeTransformsToolStripMenuItem
            // 
            this.sPARKColorcodeTransformsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClassicToSpark,
            this.tsmiSPARKShirtPants,
            this.tsmiSPARKShorts,
            this.tsmiSPARKShortSleeves,
            this.tsmiRestoreSPARKCustom});
            this.sPARKColorcodeTransformsToolStripMenuItem.Name = "sPARKColorcodeTransformsToolStripMenuItem";
            resources.ApplyResources(this.sPARKColorcodeTransformsToolStripMenuItem, "sPARKColorcodeTransformsToolStripMenuItem");
            // 
            // tsmiClassicToSpark
            // 
            this.tsmiClassicToSpark.Name = "tsmiClassicToSpark";
            resources.ApplyResources(this.tsmiClassicToSpark, "tsmiClassicToSpark");
            this.tsmiClassicToSpark.Click += new System.EventHandler(this.btnTFCC2SCC_Click);
            // 
            // tsmiSPARKShirtPants
            // 
            this.tsmiSPARKShirtPants.Name = "tsmiSPARKShirtPants";
            resources.ApplyResources(this.tsmiSPARKShirtPants, "tsmiSPARKShirtPants");
            this.tsmiSPARKShirtPants.Click += new System.EventHandler(this.btnTFShirtPants_Click);
            // 
            // tsmiSPARKShorts
            // 
            this.tsmiSPARKShorts.Name = "tsmiSPARKShorts";
            resources.ApplyResources(this.tsmiSPARKShorts, "tsmiSPARKShorts");
            this.tsmiSPARKShorts.Click += new System.EventHandler(this.btnTFShorties_Click);
            // 
            // tsmiSPARKShortSleeves
            // 
            this.tsmiSPARKShortSleeves.Name = "tsmiSPARKShortSleeves";
            resources.ApplyResources(this.tsmiSPARKShortSleeves, "tsmiSPARKShortSleeves");
            this.tsmiSPARKShortSleeves.Click += new System.EventHandler(this.btnTFSCCSleeves_Click);
            // 
            // tsmiRestoreSPARKCustom
            // 
            this.tsmiRestoreSPARKCustom.Name = "tsmiRestoreSPARKCustom";
            resources.ApplyResources(this.tsmiRestoreSPARKCustom, "tsmiRestoreSPARKCustom");
            this.tsmiRestoreSPARKCustom.Click += new System.EventHandler(this.btnTFCustomRestore_Click);
            // 
            // cmsTransforms
            // 
            this.cmsTransforms.Name = "cmsTransforms";
            resources.ApplyResources(this.cmsTransforms, "cmsTransforms");
            // 
            // grpRand
            // 
            this.grpRand.Controls.Add(this.cbRandMode);
            this.grpRand.Controls.Add(this.label16);
            this.grpRand.Controls.Add(this.clbRandSel);
            resources.ApplyResources(this.grpRand, "grpRand");
            this.grpRand.Name = "grpRand";
            this.grpRand.TabStop = false;
            // 
            // cbRandMode
            // 
            this.cbRandMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRandMode.FormattingEnabled = true;
            this.cbRandMode.Items.AddRange(new object[] {
            resources.GetString("cbRandMode.Items"),
            resources.GetString("cbRandMode.Items1")});
            resources.ApplyResources(this.cbRandMode, "cbRandMode");
            this.cbRandMode.Name = "cbRandMode";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // clbRandSel
            // 
            this.clbRandSel.FormattingEnabled = true;
            resources.ApplyResources(this.clbRandSel, "clbRandSel");
            this.clbRandSel.Name = "clbRandSel";
            // 
            // grpCCRepo
            // 
            this.grpCCRepo.Controls.Add(this.lbCCs);
            this.grpCCRepo.Controls.Add(this.btnRefresh);
            this.grpCCRepo.Controls.Add(this.btnImportCode);
            resources.ApplyResources(this.grpCCRepo, "grpCCRepo");
            this.grpCCRepo.Name = "grpCCRepo";
            this.grpCCRepo.TabStop = false;
            // 
            // lbCCs
            // 
            this.lbCCs.FormattingEnabled = true;
            resources.ApplyResources(this.lbCCs, "lbCCs");
            this.lbCCs.Name = "lbCCs";
            this.lbCCs.Sorted = true;
            this.lbCCs.DoubleClick += new System.EventHandler(this.lbCCs_DoubleClick);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tmrRandom
            // 
            this.tmrRandom.Tick += new System.EventHandler(this.tmrRandom_Tick);
            // 
            // lbWarning
            // 
            resources.ApplyResources(this.lbWarning, "lbWarning");
            this.lbWarning.Name = "lbWarning";
            // 
            // NewAppearanceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.grpRand);
            this.Controls.Add(this.grpCCRepo);
            this.Controls.Add(this.grpShading);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.marioSprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AppearanceForm";
            this.grpColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).EndInit();
            this.grpShading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpRand.ResumeLayout(false);
            this.grpRand.PerformLayout();
            this.grpCCRepo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox marioSprite;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.GroupBox grpShading;
        private System.Windows.Forms.Button btnExportCode;
        private System.Windows.Forms.Button btnImportCode;
        private System.Windows.Forms.Button btnLoadFromGame;
        private System.Windows.Forms.Button btnResetColors;
        private System.Windows.Forms.TrackBar tbLeftRight;
        private System.Windows.Forms.TrackBar tbBackFront;
        private System.Windows.Forms.TrackBar tbBottomTop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnResetShading;
        private System.Windows.Forms.Button btnRandomizeShading;
        private System.Windows.Forms.ListBox lbColors;
        private System.Windows.Forms.Button btnLightCol;
        private System.Windows.Forms.Button btnDarkCol;
        private System.Windows.Forms.Label lbCCParts;
        private System.Windows.Forms.Label lbPart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip cmsTransforms;
        private System.Windows.Forms.ToolStripMenuItem tsmiClassicToSpark;
        private System.Windows.Forms.ToolStripMenuItem tsmiSPARKShirtPants;
        private System.Windows.Forms.ToolStripMenuItem tsmiSPARKShorts;
        private System.Windows.Forms.ToolStripMenuItem tsmiSPARKShortSleeves;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestoreSPARKCustom;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sPARKColorcodeTransformsToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpRand;
        private System.Windows.Forms.ComboBox cbRandMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckedListBox clbRandSel;
        private System.Windows.Forms.GroupBox grpCCRepo;
        private System.Windows.Forms.ListBox lbCCs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer tmrRandom;
        private System.Windows.Forms.Label lbWarning;
        private System.Windows.Forms.ComboBox cbPartListOverride;
        private System.Windows.Forms.Label label1;
    }
}