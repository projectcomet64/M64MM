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
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // marioSprite
            // 
            this.marioSprite.Image = global::M64MM2.Properties.Resources.CC_Mario_big;
            this.marioSprite.Location = new System.Drawing.Point(200, 85);
            this.marioSprite.Name = "marioSprite";
            this.marioSprite.Size = new System.Drawing.Size(256, 256);
            this.marioSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.marioSprite.TabIndex = 0;
            this.marioSprite.TabStop = false;
            this.marioSprite.Paint += new System.Windows.Forms.PaintEventHandler(this.marioSprite_Paint);
            // 
            // hatColorMain
            // 
            this.hatColorMain.BackColor = System.Drawing.Color.Red;
            this.hatColorMain.ForeColor = System.Drawing.Color.Black;
            this.hatColorMain.Location = new System.Drawing.Point(12, 110);
            this.hatColorMain.Name = "hatColorMain";
            this.hatColorMain.Size = new System.Drawing.Size(24, 24);
            this.hatColorMain.TabIndex = 1;
            this.hatColorMain.UseVisualStyleBackColor = false;
            this.hatColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hatColorShade
            // 
            this.hatColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hatColorShade.ForeColor = System.Drawing.Color.Black;
            this.hatColorShade.Location = new System.Drawing.Point(42, 110);
            this.hatColorShade.Name = "hatColorShade";
            this.hatColorShade.Size = new System.Drawing.Size(24, 24);
            this.hatColorShade.TabIndex = 2;
            this.hatColorShade.UseVisualStyleBackColor = false;
            this.hatColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorShade
            // 
            this.hairColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(3)))), ((int)(((byte)(0)))));
            this.hairColorShade.ForeColor = System.Drawing.Color.Black;
            this.hairColorShade.Location = new System.Drawing.Point(42, 140);
            this.hairColorShade.Name = "hairColorShade";
            this.hairColorShade.Size = new System.Drawing.Size(24, 24);
            this.hairColorShade.TabIndex = 4;
            this.hairColorShade.UseVisualStyleBackColor = false;
            this.hairColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // hairColorMain
            // 
            this.hairColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(6)))), ((int)(((byte)(0)))));
            this.hairColorMain.ForeColor = System.Drawing.Color.Black;
            this.hairColorMain.Location = new System.Drawing.Point(12, 140);
            this.hairColorMain.Name = "hairColorMain";
            this.hairColorMain.Size = new System.Drawing.Size(24, 24);
            this.hairColorMain.TabIndex = 3;
            this.hairColorMain.UseVisualStyleBackColor = false;
            this.hairColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorShade
            // 
            this.skinColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(60)))));
            this.skinColorShade.ForeColor = System.Drawing.Color.Black;
            this.skinColorShade.Location = new System.Drawing.Point(42, 170);
            this.skinColorShade.Name = "skinColorShade";
            this.skinColorShade.Size = new System.Drawing.Size(24, 24);
            this.skinColorShade.TabIndex = 6;
            this.skinColorShade.UseVisualStyleBackColor = false;
            this.skinColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // skinColorMain
            // 
            this.skinColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(193)))), ((int)(((byte)(121)))));
            this.skinColorMain.ForeColor = System.Drawing.Color.Black;
            this.skinColorMain.Location = new System.Drawing.Point(12, 170);
            this.skinColorMain.Name = "skinColorMain";
            this.skinColorMain.Size = new System.Drawing.Size(24, 24);
            this.skinColorMain.TabIndex = 5;
            this.skinColorMain.UseVisualStyleBackColor = false;
            this.skinColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorShade
            // 
            this.glovesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.glovesColorShade.ForeColor = System.Drawing.Color.Black;
            this.glovesColorShade.Location = new System.Drawing.Point(42, 200);
            this.glovesColorShade.Name = "glovesColorShade";
            this.glovesColorShade.Size = new System.Drawing.Size(24, 24);
            this.glovesColorShade.TabIndex = 8;
            this.glovesColorShade.UseVisualStyleBackColor = false;
            this.glovesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // glovesColorMain
            // 
            this.glovesColorMain.BackColor = System.Drawing.Color.White;
            this.glovesColorMain.ForeColor = System.Drawing.Color.Black;
            this.glovesColorMain.Location = new System.Drawing.Point(12, 200);
            this.glovesColorMain.Name = "glovesColorMain";
            this.glovesColorMain.Size = new System.Drawing.Size(24, 24);
            this.glovesColorMain.TabIndex = 7;
            this.glovesColorMain.UseVisualStyleBackColor = false;
            this.glovesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorShade
            // 
            this.pantsColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.pantsColorShade.ForeColor = System.Drawing.Color.Black;
            this.pantsColorShade.Location = new System.Drawing.Point(42, 230);
            this.pantsColorShade.Name = "pantsColorShade";
            this.pantsColorShade.Size = new System.Drawing.Size(24, 24);
            this.pantsColorShade.TabIndex = 10;
            this.pantsColorShade.UseVisualStyleBackColor = false;
            this.pantsColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pantsColorMain
            // 
            this.pantsColorMain.BackColor = System.Drawing.Color.Blue;
            this.pantsColorMain.ForeColor = System.Drawing.Color.Black;
            this.pantsColorMain.Location = new System.Drawing.Point(12, 230);
            this.pantsColorMain.Name = "pantsColorMain";
            this.pantsColorMain.Size = new System.Drawing.Size(24, 24);
            this.pantsColorMain.TabIndex = 9;
            this.pantsColorMain.UseVisualStyleBackColor = false;
            this.pantsColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorShade
            // 
            this.shoesColorShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(14)))), ((int)(((byte)(7)))));
            this.shoesColorShade.ForeColor = System.Drawing.Color.Black;
            this.shoesColorShade.Location = new System.Drawing.Point(42, 260);
            this.shoesColorShade.Name = "shoesColorShade";
            this.shoesColorShade.Size = new System.Drawing.Size(24, 24);
            this.shoesColorShade.TabIndex = 12;
            this.shoesColorShade.UseVisualStyleBackColor = false;
            this.shoesColorShade.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // shoesColorMain
            // 
            this.shoesColorMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(28)))), ((int)(((byte)(14)))));
            this.shoesColorMain.ForeColor = System.Drawing.Color.Black;
            this.shoesColorMain.Location = new System.Drawing.Point(12, 260);
            this.shoesColorMain.Name = "shoesColorMain";
            this.shoesColorMain.Size = new System.Drawing.Size(24, 24);
            this.shoesColorMain.TabIndex = 11;
            this.shoesColorMain.UseVisualStyleBackColor = false;
            this.shoesColorMain.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hat/Clothes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hair";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Skin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Gloves";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Pants";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 266);
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
            // ColorCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 491);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shoesColorShade);
            this.Controls.Add(this.shoesColorMain);
            this.Controls.Add(this.pantsColorShade);
            this.Controls.Add(this.pantsColorMain);
            this.Controls.Add(this.glovesColorShade);
            this.Controls.Add(this.glovesColorMain);
            this.Controls.Add(this.skinColorShade);
            this.Controls.Add(this.skinColorMain);
            this.Controls.Add(this.hairColorShade);
            this.Controls.Add(this.hairColorMain);
            this.Controls.Add(this.hatColorShade);
            this.Controls.Add(this.hatColorMain);
            this.Controls.Add(this.marioSprite);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ColorCodeForm";
            this.Text = "Color Code Studio";
            ((System.ComponentModel.ISupportInitialize)(this.marioSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}