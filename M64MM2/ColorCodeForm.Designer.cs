namespace M64MM2
{
    partial class ColorCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorCodeForm));
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
            this.grpShading = new System.Windows.Forms.GroupBox();
            this.btnImportCode = new System.Windows.Forms.Button();
            this.btnExportCode = new System.Windows.Forms.Button();
            this.btnLoadFromGame = new System.Windows.Forms.Button();
            this.btnResetColors = new System.Windows.Forms.Button();
            this.tbLeftRight = new System.Windows.Forms.TrackBar();
            this.tbBottomTop = new System.Windows.Forms.TrackBar();
            this.tbBackFront = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnResetShading = new System.Windows.Forms.Button();
            this.btnRandomizeShading = new System.Windows.Forms.Button();
            this.randomizerTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).BeginInit();
            this.grpColor.SuspendLayout();
            this.grpShading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).BeginInit();
            this.SuspendLayout();
            // 
            // marioSprite
            // 
            this.marioSprite.BackColor = System.Drawing.Color.Transparent;
            this.marioSprite.Image = global::M64MM2.Properties.Resources.CC_Mario_big;
            this.marioSprite.Location = new System.Drawing.Point(258, 51);
            this.marioSprite.Name = "marioSprite";
            this.marioSprite.Size = new System.Drawing.Size(192, 256);
            this.marioSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.marioSprite.TabIndex = 0;
            this.marioSprite.TabStop = false;
            this.marioSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.marioSprite_Paint);
            // 
            // hatColorMain
            // 
            this.hatColorMain.BackColor = System.Drawing.Color.Red;
            this.hatColorMain.ForeColor = System.Drawing.Color.Black;
            this.hatColorMain.Location = new System.Drawing.Point(6, 32);
            this.hatColorMain.Name = "hatColorMain";
            this.hatColorMain.Size = new System.Drawing.Size(48, 24);
            this.hatColorMain.TabIndex = 1;
            this.hatColorMain.UseVisualStyleBackColor = false;
            this.hatColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hatColorShade
            // 
            this.hatColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hatColorShade.ForeColor = System.Drawing.Color.Black;
            this.hatColorShade.Location = new System.Drawing.Point(60, 32);
            this.hatColorShade.Name = "hatColorShade";
            this.hatColorShade.Size = new System.Drawing.Size(48, 24);
            this.hatColorShade.TabIndex = 2;
            this.hatColorShade.UseVisualStyleBackColor = false;
            this.hatColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorShade
            // 
            this.hairColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(3)))), ((int)(((byte)(0)))));
            this.hairColorShade.ForeColor = System.Drawing.Color.Black;
            this.hairColorShade.Location = new System.Drawing.Point(60, 62);
            this.hairColorShade.Name = "hairColorShade";
            this.hairColorShade.Size = new System.Drawing.Size(48, 24);
            this.hairColorShade.TabIndex = 4;
            this.hairColorShade.UseVisualStyleBackColor = false;
            this.hairColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorMain
            // 
            this.hairColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(6)))), ((int)(((byte)(0)))));
            this.hairColorMain.ForeColor = System.Drawing.Color.Black;
            this.hairColorMain.Location = new System.Drawing.Point(6, 62);
            this.hairColorMain.Name = "hairColorMain";
            this.hairColorMain.Size = new System.Drawing.Size(48, 24);
            this.hairColorMain.TabIndex = 3;
            this.hairColorMain.UseVisualStyleBackColor = false;
            this.hairColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorShade
            // 
            this.skinColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(60)))));
            this.skinColorShade.ForeColor = System.Drawing.Color.Black;
            this.skinColorShade.Location = new System.Drawing.Point(60, 92);
            this.skinColorShade.Name = "skinColorShade";
            this.skinColorShade.Size = new System.Drawing.Size(48, 24);
            this.skinColorShade.TabIndex = 6;
            this.skinColorShade.UseVisualStyleBackColor = false;
            this.skinColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorMain
            // 
            this.skinColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(193)))), ((int)(((byte)(121)))));
            this.skinColorMain.ForeColor = System.Drawing.Color.Black;
            this.skinColorMain.Location = new System.Drawing.Point(6, 92);
            this.skinColorMain.Name = "skinColorMain";
            this.skinColorMain.Size = new System.Drawing.Size(48, 24);
            this.skinColorMain.TabIndex = 5;
            this.skinColorMain.UseVisualStyleBackColor = false;
            this.skinColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorShade
            // 
            this.glovesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.glovesColorShade.ForeColor = System.Drawing.Color.Black;
            this.glovesColorShade.Location = new System.Drawing.Point(60, 122);
            this.glovesColorShade.Name = "glovesColorShade";
            this.glovesColorShade.Size = new System.Drawing.Size(48, 24);
            this.glovesColorShade.TabIndex = 8;
            this.glovesColorShade.UseVisualStyleBackColor = false;
            this.glovesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorMain
            // 
            this.glovesColorMain.BackColor = System.Drawing.Color.White;
            this.glovesColorMain.ForeColor = System.Drawing.Color.Black;
            this.glovesColorMain.Location = new System.Drawing.Point(6, 122);
            this.glovesColorMain.Name = "glovesColorMain";
            this.glovesColorMain.Size = new System.Drawing.Size(48, 24);
            this.glovesColorMain.TabIndex = 7;
            this.glovesColorMain.UseVisualStyleBackColor = false;
            this.glovesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorShade
            // 
            this.pantsColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.pantsColorShade.ForeColor = System.Drawing.Color.Black;
            this.pantsColorShade.Location = new System.Drawing.Point(60, 152);
            this.pantsColorShade.Name = "pantsColorShade";
            this.pantsColorShade.Size = new System.Drawing.Size(48, 24);
            this.pantsColorShade.TabIndex = 10;
            this.pantsColorShade.UseVisualStyleBackColor = false;
            this.pantsColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorMain
            // 
            this.pantsColorMain.BackColor = System.Drawing.Color.Blue;
            this.pantsColorMain.ForeColor = System.Drawing.Color.Black;
            this.pantsColorMain.Location = new System.Drawing.Point(6, 152);
            this.pantsColorMain.Name = "pantsColorMain";
            this.pantsColorMain.Size = new System.Drawing.Size(48, 24);
            this.pantsColorMain.TabIndex = 9;
            this.pantsColorMain.UseVisualStyleBackColor = false;
            this.pantsColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorShade
            // 
            this.shoesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(14)))), ((int)(((byte)(7)))));
            this.shoesColorShade.ForeColor = System.Drawing.Color.Black;
            this.shoesColorShade.Location = new System.Drawing.Point(60, 182);
            this.shoesColorShade.Name = "shoesColorShade";
            this.shoesColorShade.Size = new System.Drawing.Size(48, 24);
            this.shoesColorShade.TabIndex = 12;
            this.shoesColorShade.UseVisualStyleBackColor = false;
            this.shoesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorMain
            // 
            this.shoesColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(14)))));
            this.shoesColorMain.ForeColor = System.Drawing.Color.Black;
            this.shoesColorMain.Location = new System.Drawing.Point(6, 182);
            this.shoesColorMain.Name = "shoesColorMain";
            this.shoesColorMain.Size = new System.Drawing.Size(48, 24);
            this.shoesColorMain.TabIndex = 11;
            this.shoesColorMain.UseVisualStyleBackColor = false;
            this.shoesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hat/Clothes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hair";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Skin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Gloves";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Pants";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Shoes";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Main";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(60, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Shading";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 30);
            this.label9.TabIndex = 21;
            this.label9.Text = "IMPORTANT: Make sure to DISABLE all color codes in Project64!\r\nOtherwise, Mario\'s" +
    " colors won\'t match the ones you pick here.";
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
            this.grpColor.Location = new System.Drawing.Point(12, 42);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(240, 270);
            this.grpColor.TabIndex = 22;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "Color Settings:";
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
            this.grpShading.Location = new System.Drawing.Point(12, 318);
            this.grpShading.Name = "grpShading";
            this.grpShading.Size = new System.Drawing.Size(440, 107);
            this.grpShading.TabIndex = 23;
            this.grpShading.TabStop = false;
            this.grpShading.Text = "Shading Settings:";
            // 
            // btnImportCode
            // 
            this.btnImportCode.Location = new System.Drawing.Point(6, 212);
            this.btnImportCode.Name = "btnImportCode";
            this.btnImportCode.Size = new System.Drawing.Size(111, 23);
            this.btnImportCode.TabIndex = 21;
            this.btnImportCode.Text = "Import Color Code";
            this.btnImportCode.UseVisualStyleBackColor = true;
            // 
            // btnExportCode
            // 
            this.btnExportCode.Location = new System.Drawing.Point(123, 212);
            this.btnExportCode.Name = "btnExportCode";
            this.btnExportCode.Size = new System.Drawing.Size(111, 23);
            this.btnExportCode.TabIndex = 22;
            this.btnExportCode.Text = "Export Color Code";
            this.btnExportCode.UseVisualStyleBackColor = true;
            // 
            // btnLoadFromGame
            // 
            this.btnLoadFromGame.Location = new System.Drawing.Point(123, 241);
            this.btnLoadFromGame.Name = "btnLoadFromGame";
            this.btnLoadFromGame.Size = new System.Drawing.Size(111, 23);
            this.btnLoadFromGame.TabIndex = 24;
            this.btnLoadFromGame.Text = "Load From Game";
            this.btnLoadFromGame.UseVisualStyleBackColor = true;
            // 
            // btnResetColors
            // 
            this.btnResetColors.Location = new System.Drawing.Point(6, 241);
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.Size = new System.Drawing.Size(111, 23);
            this.btnResetColors.TabIndex = 23;
            this.btnResetColors.Text = "Reset Colors";
            this.btnResetColors.UseVisualStyleBackColor = true;
            this.btnResetColors.Click += new System.EventHandler(this.resetColors);
            // 
            // tbLeftRight
            // 
            this.tbLeftRight.AutoSize = false;
            this.tbLeftRight.Location = new System.Drawing.Point(59, 19);
            this.tbLeftRight.Name = "tbLeftRight";
            this.tbLeftRight.Size = new System.Drawing.Size(200, 23);
            this.tbLeftRight.TabIndex = 0;
            this.tbLeftRight.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbBottomTop
            // 
            this.tbBottomTop.AutoSize = false;
            this.tbBottomTop.Location = new System.Drawing.Point(59, 48);
            this.tbBottomTop.Name = "tbBottomTop";
            this.tbBottomTop.Size = new System.Drawing.Size(200, 23);
            this.tbBottomTop.TabIndex = 1;
            this.tbBottomTop.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbBackFront
            // 
            this.tbBackFront.AutoSize = false;
            this.tbBackFront.Location = new System.Drawing.Point(59, 77);
            this.tbBackFront.Name = "tbBackFront";
            this.tbBackFront.Size = new System.Drawing.Size(200, 23);
            this.tbBackFront.TabIndex = 2;
            this.tbBackFront.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Left";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Bottom";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Back";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(265, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Front";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(265, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Top";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(265, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Right";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetShading
            // 
            this.btnResetShading.Location = new System.Drawing.Point(318, 19);
            this.btnResetShading.Name = "btnResetShading";
            this.btnResetShading.Size = new System.Drawing.Size(116, 23);
            this.btnResetShading.TabIndex = 22;
            this.btnResetShading.Text = "Reset Shading";
            this.btnResetShading.UseVisualStyleBackColor = true;
            // 
            // btnRandomizeShading
            // 
            this.btnRandomizeShading.Location = new System.Drawing.Point(318, 72);
            this.btnRandomizeShading.Name = "btnRandomizeShading";
            this.btnRandomizeShading.Size = new System.Drawing.Size(116, 23);
            this.btnRandomizeShading.TabIndex = 23;
            this.btnRandomizeShading.Text = "Randomize Shading";
            this.btnRandomizeShading.UseVisualStyleBackColor = true;
            // 
            // ColorCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 437);
            this.Controls.Add(this.grpShading);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.marioSprite);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ColorCodeForm";
            this.Text = "Color Code Studio";
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).EndInit();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.grpShading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBottomTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackFront)).EndInit();
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