namespace M64MM2
{
    partial class AppearanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppearanceForm));
            this.marioSprite = new System.Windows.Forms.PictureBox();
            this.hatColorMain = new System.Windows.Forms.Button();
            this.hatColorShade = new System.Windows.Forms.Button();
            this.hairColorShade = new System.Windows.Forms.Button();
            this.hairColorMain = new System.Windows.Forms.Button();
            this.skinColorShade = new System.Windows.Forms.Button();
            this.skinColorMain = new System.Windows.Forms.Button();
            this.glovesColorShade = new System.Windows.Forms.Button();
            this.glovesColorMain = new System.Windows.Forms.Button();
            this.pantsColorShade = new System.Windows.Forms.Button();
            this.pantsColorMain = new System.Windows.Forms.Button();
            this.shoesColorShade = new System.Windows.Forms.Button();
            this.shoesColorMain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.btnLoadFromGame = new System.Windows.Forms.Button();
            this.btnResetColors = new System.Windows.Forms.Button();
            this.btnExportCode = new System.Windows.Forms.Button();
            this.btnImportCode = new System.Windows.Forms.Button();
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
            this.randomizerTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).BeginInit();
            this.grpColor.SuspendLayout();
            this.grpShading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).BeginInit();
            this.SuspendLayout();
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
            // hatColorMain
            // 
            this.hatColorMain.BackColor = System.Drawing.Color.Red;
            this.hatColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.hatColorMain, "hatColorMain");
            this.hatColorMain.Name = "hatColorMain";
            this.hatColorMain.UseVisualStyleBackColor = false;
            this.hatColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hatColorShade
            // 
            this.hatColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hatColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.hatColorShade, "hatColorShade");
            this.hatColorShade.Name = "hatColorShade";
            this.hatColorShade.UseVisualStyleBackColor = false;
            this.hatColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorShade
            // 
            this.hairColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(3)))), ((int)(((byte)(0)))));
            this.hairColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.hairColorShade, "hairColorShade");
            this.hairColorShade.Name = "hairColorShade";
            this.hairColorShade.UseVisualStyleBackColor = false;
            this.hairColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorMain
            // 
            this.hairColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(6)))), ((int)(((byte)(0)))));
            this.hairColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.hairColorMain, "hairColorMain");
            this.hairColorMain.Name = "hairColorMain";
            this.hairColorMain.UseVisualStyleBackColor = false;
            this.hairColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorShade
            // 
            this.skinColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(60)))));
            this.skinColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.skinColorShade, "skinColorShade");
            this.skinColorShade.Name = "skinColorShade";
            this.skinColorShade.UseVisualStyleBackColor = false;
            this.skinColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorMain
            // 
            this.skinColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(193)))), ((int)(((byte)(121)))));
            this.skinColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.skinColorMain, "skinColorMain");
            this.skinColorMain.Name = "skinColorMain";
            this.skinColorMain.UseVisualStyleBackColor = false;
            this.skinColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorShade
            // 
            this.glovesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.glovesColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.glovesColorShade, "glovesColorShade");
            this.glovesColorShade.Name = "glovesColorShade";
            this.glovesColorShade.UseVisualStyleBackColor = false;
            this.glovesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorMain
            // 
            this.glovesColorMain.BackColor = System.Drawing.Color.White;
            this.glovesColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.glovesColorMain, "glovesColorMain");
            this.glovesColorMain.Name = "glovesColorMain";
            this.glovesColorMain.UseVisualStyleBackColor = false;
            this.glovesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorShade
            // 
            this.pantsColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.pantsColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pantsColorShade, "pantsColorShade");
            this.pantsColorShade.Name = "pantsColorShade";
            this.pantsColorShade.UseVisualStyleBackColor = false;
            this.pantsColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorMain
            // 
            this.pantsColorMain.BackColor = System.Drawing.Color.Blue;
            this.pantsColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pantsColorMain, "pantsColorMain");
            this.pantsColorMain.Name = "pantsColorMain";
            this.pantsColorMain.UseVisualStyleBackColor = false;
            this.pantsColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorShade
            // 
            this.shoesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(14)))), ((int)(((byte)(7)))));
            this.shoesColorShade.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.shoesColorShade, "shoesColorShade");
            this.shoesColorShade.Name = "shoesColorShade";
            this.shoesColorShade.UseVisualStyleBackColor = false;
            this.shoesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorMain
            // 
            this.shoesColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(14)))));
            this.shoesColorMain.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.shoesColorMain, "shoesColorMain");
            this.shoesColorMain.Name = "shoesColorMain";
            this.shoesColorMain.UseVisualStyleBackColor = false;
            this.shoesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
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
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.btnLoadFromGame);
            this.grpColor.Controls.Add(this.btnResetColors);
            this.grpColor.Controls.Add(this.btnExportCode);
            this.grpColor.Controls.Add(this.btnImportCode);
            this.grpColor.Controls.Add(this.label7);
            this.grpColor.Controls.Add(this.hatColorMain);
            this.grpColor.Controls.Add(this.label8);
            this.grpColor.Controls.Add(this.hatColorShade);
            this.grpColor.Controls.Add(this.hairColorMain);
            this.grpColor.Controls.Add(this.label6);
            this.grpColor.Controls.Add(this.hairColorShade);
            this.grpColor.Controls.Add(this.label5);
            this.grpColor.Controls.Add(this.skinColorMain);
            this.grpColor.Controls.Add(this.label4);
            this.grpColor.Controls.Add(this.skinColorShade);
            this.grpColor.Controls.Add(this.label3);
            this.grpColor.Controls.Add(this.glovesColorMain);
            this.grpColor.Controls.Add(this.label2);
            this.grpColor.Controls.Add(this.glovesColorShade);
            this.grpColor.Controls.Add(this.label1);
            this.grpColor.Controls.Add(this.pantsColorMain);
            this.grpColor.Controls.Add(this.shoesColorShade);
            this.grpColor.Controls.Add(this.pantsColorShade);
            this.grpColor.Controls.Add(this.shoesColorMain);
            resources.ApplyResources(this.grpColor, "grpColor");
            this.grpColor.Name = "grpColor";
            this.grpColor.TabStop = false;
            // 
            // btnLoadFromGame
            // 
            resources.ApplyResources(this.btnLoadFromGame, "btnLoadFromGame");
            this.btnLoadFromGame.Name = "btnLoadFromGame";
            this.btnLoadFromGame.UseVisualStyleBackColor = true;
            this.btnLoadFromGame.Click += new System.EventHandler(this.loadFromGame);
            // 
            // btnResetColors
            // 
            resources.ApplyResources(this.btnResetColors, "btnResetColors");
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.UseVisualStyleBackColor = true;
            this.btnResetColors.Click += new System.EventHandler(this.resetColors);
            // 
            // btnExportCode
            // 
            resources.ApplyResources(this.btnExportCode, "btnExportCode");
            this.btnExportCode.Name = "btnExportCode";
            this.btnExportCode.UseVisualStyleBackColor = true;
            this.btnExportCode.Click += new System.EventHandler(this.openCopyPasteForm);
            // 
            // btnImportCode
            // 
            resources.ApplyResources(this.btnImportCode, "btnImportCode");
            this.btnImportCode.Name = "btnImportCode";
            this.btnImportCode.UseVisualStyleBackColor = true;
            this.btnImportCode.Click += new System.EventHandler(this.openCopyPasteForm);
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
            this.btnRandomizeShading.Click += new System.EventHandler(this.randomizeShadows);
            // 
            // btnResetShading
            // 
            resources.ApplyResources(this.btnResetShading, "btnResetShading");
            this.btnResetShading.Name = "btnResetShading";
            this.btnResetShading.UseVisualStyleBackColor = true;
            this.btnResetShading.Click += new System.EventHandler(this.resetShadows);
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
            this.tbBackFront.Value = -40;
            this.tbBackFront.ValueChanged += new System.EventHandler(this.changeShadows);
            // 
            // tbBottomTop
            // 
            resources.ApplyResources(this.tbBottomTop, "tbBottomTop");
            this.tbBottomTop.Maximum = 127;
            this.tbBottomTop.Minimum = -127;
            this.tbBottomTop.Name = "tbBottomTop";
            this.tbBottomTop.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBottomTop.Value = 40;
            this.tbBottomTop.ValueChanged += new System.EventHandler(this.changeShadows);
            // 
            // tbLeftRight
            // 
            resources.ApplyResources(this.tbLeftRight, "tbLeftRight");
            this.tbLeftRight.Maximum = 127;
            this.tbLeftRight.Minimum = -127;
            this.tbLeftRight.Name = "tbLeftRight";
            this.tbLeftRight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbLeftRight.Value = 40;
            this.tbLeftRight.ValueChanged += new System.EventHandler(this.changeShadows);
            // 
            // randomizerTimer
            // 
            this.randomizerTimer.Tick += new System.EventHandler(this.randomizerTimer_Tick);
            // 
            // AppearanceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpShading);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.marioSprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AppearanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).EndInit();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.grpShading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox marioSprite;
        private System.Windows.Forms.Button hatColorMain;
        private System.Windows.Forms.Button hatColorShade;
        private System.Windows.Forms.Button hairColorShade;
        private System.Windows.Forms.Button hairColorMain;
        private System.Windows.Forms.Button skinColorShade;
        private System.Windows.Forms.Button skinColorMain;
        private System.Windows.Forms.Button glovesColorShade;
        private System.Windows.Forms.Button glovesColorMain;
        private System.Windows.Forms.Button pantsColorShade;
        private System.Windows.Forms.Button pantsColorMain;
        private System.Windows.Forms.Button shoesColorShade;
        private System.Windows.Forms.Button shoesColorMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Timer randomizerTimer;
    }
}