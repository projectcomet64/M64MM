namespace M64MM2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.btnSoftUnfreeze = new System.Windows.Forms.Button();
            this.btnSoftFreeze = new System.Windows.Forms.Button();
            this.btnUnfreeze = new System.Windows.Forms.Button();
            this.btnFreeze = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProgramStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpAnimSwap = new System.Windows.Forms.GroupBox();
            this.btnAnimRestart = new System.Windows.Forms.Button();
            this.btnAnimResetAll = new System.Windows.Forms.Button();
            this.btnAnimReset = new System.Windows.Forms.Button();
            this.btnAnimSwap = new System.Windows.Forms.Button();
            this.lblAnimNew = new System.Windows.Forms.Label();
            this.lblAnimOld = new System.Windows.Forms.Label();
            this.cbAnimNew = new System.Windows.Forms.ComboBox();
            this.cbAnimOld = new System.Windows.Forms.ComboBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.grpCamStyle = new System.Windows.Forms.GroupBox();
            this.btnChangeCamStyle = new System.Windows.Forms.Button();
            this.cbCamStyles = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.grpCamera.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpAnimSwap.SuspendLayout();
            this.grpCamStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsMenuItem,
            this.aboutMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(524, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appearanceSettingsMenuItem,
            this.extraControlsToolStripMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsMenuItem.Text = "&Tools";
            // 
            // appearanceSettingsMenuItem
            // 
            this.appearanceSettingsMenuItem.Name = "appearanceSettingsMenuItem";
            this.appearanceSettingsMenuItem.Size = new System.Drawing.Size(191, 22);
            this.appearanceSettingsMenuItem.Text = "&Appearance Settings...";
            this.appearanceSettingsMenuItem.Click += new System.EventHandler(this.openAppearanceSettings);
            // 
            // extraControlsToolStripMenuItem
            // 
            this.extraControlsToolStripMenuItem.Name = "extraControlsToolStripMenuItem";
            this.extraControlsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.extraControlsToolStripMenuItem.Text = "&Extra Controls...";
            this.extraControlsToolStripMenuItem.Click += new System.EventHandler(this.openExtraControls);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "&About";
            this.aboutMenuItem.Click += new System.EventHandler(this.openAboutForm);
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.btnSoftUnfreeze);
            this.grpCamera.Controls.Add(this.btnSoftFreeze);
            this.grpCamera.Controls.Add(this.btnUnfreeze);
            this.grpCamera.Controls.Add(this.btnFreeze);
            this.grpCamera.Location = new System.Drawing.Point(12, 27);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(278, 82);
            this.grpCamera.TabIndex = 2;
            this.grpCamera.TabStop = false;
            this.grpCamera.Text = "Camera Controls";
            // 
            // btnSoftUnfreeze
            // 
            this.btnSoftUnfreeze.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSoftUnfreeze.Location = new System.Drawing.Point(142, 50);
            this.btnSoftUnfreeze.Name = "btnSoftUnfreeze";
            this.btnSoftUnfreeze.Size = new System.Drawing.Size(130, 25);
            this.btnSoftUnfreeze.TabIndex = 4;
            this.btnSoftUnfreeze.Text = "Soft-Unfreeze (Ctrl + 5)";
            this.btnSoftUnfreeze.UseVisualStyleBackColor = true;
            this.btnSoftUnfreeze.Click += new System.EventHandler(this.SoftUnfreezeCam);
            // 
            // btnSoftFreeze
            // 
            this.btnSoftFreeze.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSoftFreeze.Location = new System.Drawing.Point(6, 50);
            this.btnSoftFreeze.Name = "btnSoftFreeze";
            this.btnSoftFreeze.Size = new System.Drawing.Size(130, 25);
            this.btnSoftFreeze.TabIndex = 3;
            this.btnSoftFreeze.Text = "Soft-Freeze (Ctrl + 4)";
            this.btnSoftFreeze.UseVisualStyleBackColor = true;
            this.btnSoftFreeze.Click += new System.EventHandler(this.SoftFreezeCam);
            // 
            // btnUnfreeze
            // 
            this.btnUnfreeze.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUnfreeze.Location = new System.Drawing.Point(142, 19);
            this.btnUnfreeze.Name = "btnUnfreeze";
            this.btnUnfreeze.Size = new System.Drawing.Size(130, 25);
            this.btnUnfreeze.TabIndex = 1;
            this.btnUnfreeze.Text = "Unfreeze (Ctrl + 2)";
            this.btnUnfreeze.UseVisualStyleBackColor = true;
            this.btnUnfreeze.Click += new System.EventHandler(this.UnfreezeCam);
            // 
            // btnFreeze
            // 
            this.btnFreeze.Location = new System.Drawing.Point(6, 19);
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.Size = new System.Drawing.Size(130, 25);
            this.btnFreeze.TabIndex = 0;
            this.btnFreeze.Text = "Freeze (Ctrl + 1)";
            this.btnFreeze.UseVisualStyleBackColor = true;
            this.btnFreeze.Click += new System.EventHandler(this.FreezeCam);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgramStatus,
            this.lblCameraStatus,
            this.lblCameraCode});
            this.statusStrip.Location = new System.Drawing.Point(0, 220);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(524, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblProgramStatus
            // 
            this.lblProgramStatus.AutoSize = false;
            this.lblProgramStatus.Name = "lblProgramStatus";
            this.lblProgramStatus.Size = new System.Drawing.Size(260, 17);
            this.lblProgramStatus.Text = "Status: Project64 isn\'t open.";
            this.lblProgramStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCameraStatus
            // 
            this.lblCameraStatus.AutoSize = false;
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(190, 17);
            this.lblCameraStatus.Text = "Camera State: Default";
            this.lblCameraStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCameraCode
            // 
            this.lblCameraCode.Name = "lblCameraCode";
            this.lblCameraCode.Size = new System.Drawing.Size(66, 17);
            this.lblCameraCode.Text = "0x00000000";
            // 
            // grpAnimSwap
            // 
            this.grpAnimSwap.Controls.Add(this.btnAnimRestart);
            this.grpAnimSwap.Controls.Add(this.btnAnimResetAll);
            this.grpAnimSwap.Controls.Add(this.btnAnimReset);
            this.grpAnimSwap.Controls.Add(this.btnAnimSwap);
            this.grpAnimSwap.Controls.Add(this.lblAnimNew);
            this.grpAnimSwap.Controls.Add(this.lblAnimOld);
            this.grpAnimSwap.Controls.Add(this.cbAnimNew);
            this.grpAnimSwap.Controls.Add(this.cbAnimOld);
            this.grpAnimSwap.Location = new System.Drawing.Point(12, 115);
            this.grpAnimSwap.Name = "grpAnimSwap";
            this.grpAnimSwap.Size = new System.Drawing.Size(427, 102);
            this.grpAnimSwap.TabIndex = 3;
            this.grpAnimSwap.TabStop = false;
            this.grpAnimSwap.Text = "Animation Swap Controls";
            // 
            // btnAnimRestart
            // 
            this.btnAnimRestart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAnimRestart.Location = new System.Drawing.Point(321, 73);
            this.btnAnimRestart.Name = "btnAnimRestart";
            this.btnAnimRestart.Size = new System.Drawing.Size(99, 23);
            this.btnAnimRestart.TabIndex = 7;
            this.btnAnimRestart.Text = "Restart Animation";
            this.btnAnimRestart.UseVisualStyleBackColor = true;
            this.btnAnimRestart.Click += new System.EventHandler(this.btnAnimRestart_Click);
            // 
            // btnAnimResetAll
            // 
            this.btnAnimResetAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAnimResetAll.Location = new System.Drawing.Point(216, 73);
            this.btnAnimResetAll.Name = "btnAnimResetAll";
            this.btnAnimResetAll.Size = new System.Drawing.Size(99, 23);
            this.btnAnimResetAll.TabIndex = 6;
            this.btnAnimResetAll.Text = "Reset All";
            this.btnAnimResetAll.UseVisualStyleBackColor = true;
            this.btnAnimResetAll.Click += new System.EventHandler(this.WriteAnimResetAll);
            // 
            // btnAnimReset
            // 
            this.btnAnimReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAnimReset.Location = new System.Drawing.Point(111, 73);
            this.btnAnimReset.Name = "btnAnimReset";
            this.btnAnimReset.Size = new System.Drawing.Size(99, 23);
            this.btnAnimReset.TabIndex = 5;
            this.btnAnimReset.Text = "Reset";
            this.btnAnimReset.UseVisualStyleBackColor = true;
            this.btnAnimReset.Click += new System.EventHandler(this.WriteAnimReset);
            // 
            // btnAnimSwap
            // 
            this.btnAnimSwap.Location = new System.Drawing.Point(6, 73);
            this.btnAnimSwap.Name = "btnAnimSwap";
            this.btnAnimSwap.Size = new System.Drawing.Size(99, 23);
            this.btnAnimSwap.TabIndex = 4;
            this.btnAnimSwap.Text = "Apply";
            this.btnAnimSwap.UseVisualStyleBackColor = true;
            this.btnAnimSwap.Click += new System.EventHandler(this.WriteAnimSwap);
            // 
            // lblAnimNew
            // 
            this.lblAnimNew.AutoSize = true;
            this.lblAnimNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAnimNew.Location = new System.Drawing.Point(6, 49);
            this.lblAnimNew.Name = "lblAnimNew";
            this.lblAnimNew.Size = new System.Drawing.Size(99, 13);
            this.lblAnimNew.TabIndex = 3;
            this.lblAnimNew.Text = "With this animation:";
            // 
            // lblAnimOld
            // 
            this.lblAnimOld.AutoSize = true;
            this.lblAnimOld.Location = new System.Drawing.Point(6, 22);
            this.lblAnimOld.Name = "lblAnimOld";
            this.lblAnimOld.Size = new System.Drawing.Size(117, 13);
            this.lblAnimOld.TabIndex = 2;
            this.lblAnimOld.Text = "Replace this animation:";
            // 
            // cbAnimNew
            // 
            this.cbAnimNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAnimNew.Location = new System.Drawing.Point(148, 46);
            this.cbAnimNew.Name = "cbAnimNew";
            this.cbAnimNew.Size = new System.Drawing.Size(272, 21);
            this.cbAnimNew.TabIndex = 1;
            // 
            // cbAnimOld
            // 
            this.cbAnimOld.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimOld.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAnimOld.Location = new System.Drawing.Point(148, 19);
            this.cbAnimOld.Name = "cbAnimOld";
            this.cbAnimOld.Size = new System.Drawing.Size(272, 21);
            this.cbAnimOld.TabIndex = 0;
            this.cbAnimOld.SelectedIndexChanged += new System.EventHandler(this.cbAnimOld_SelectedIndexChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.Update);
            // 
            // grpCamStyle
            // 
            this.grpCamStyle.Controls.Add(this.btnChangeCamStyle);
            this.grpCamStyle.Controls.Add(this.cbCamStyles);
            this.grpCamStyle.Location = new System.Drawing.Point(296, 27);
            this.grpCamStyle.Name = "grpCamStyle";
            this.grpCamStyle.Size = new System.Drawing.Size(216, 82);
            this.grpCamStyle.TabIndex = 10;
            this.grpCamStyle.TabStop = false;
            this.grpCamStyle.Text = "Change Camera Style";
            // 
            // btnChangeCamStyle
            // 
            this.btnChangeCamStyle.Location = new System.Drawing.Point(43, 51);
            this.btnChangeCamStyle.Name = "btnChangeCamStyle";
            this.btnChangeCamStyle.Size = new System.Drawing.Size(130, 23);
            this.btnChangeCamStyle.TabIndex = 2;
            this.btnChangeCamStyle.Text = "Apply";
            this.btnChangeCamStyle.UseVisualStyleBackColor = true;
            this.btnChangeCamStyle.Click += new System.EventHandler(this.changeCameraStyle);
            // 
            // cbCamStyles
            // 
            this.cbCamStyles.FormattingEnabled = true;
            this.cbCamStyles.Location = new System.Drawing.Point(6, 23);
            this.cbCamStyles.Name = "cbCamStyles";
            this.cbCamStyles.Size = new System.Drawing.Size(204, 21);
            this.cbCamStyles.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 242);
            this.Controls.Add(this.grpCamStyle);
            this.Controls.Add(this.grpAnimSwap);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mario 64 Movie Maker 2.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpCamera.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpAnimSwap.ResumeLayout(false);
            this.grpAnimSwap.PerformLayout();
            this.grpCamStyle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.Button btnFreeze;
        private System.Windows.Forms.Button btnUnfreeze;
        private System.Windows.Forms.Button btnSoftFreeze;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblProgramStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraStatus;
        private System.Windows.Forms.Button btnSoftUnfreeze;
        private System.Windows.Forms.GroupBox grpAnimSwap;
        private System.Windows.Forms.ComboBox cbAnimNew;
        private System.Windows.Forms.ComboBox cbAnimOld;
        private System.Windows.Forms.Label lblAnimOld;
        private System.Windows.Forms.Label lblAnimNew;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button btnAnimSwap;
        private System.Windows.Forms.Button btnAnimResetAll;
        private System.Windows.Forms.Button btnAnimReset;
        private System.Windows.Forms.ToolStripMenuItem appearanceSettingsMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraCode;
        private System.Windows.Forms.GroupBox grpCamStyle;
        private System.Windows.Forms.ComboBox cbCamStyles;
        private System.Windows.Forms.Button btnChangeCamStyle;
        private System.Windows.Forms.ToolStripMenuItem extraControlsToolStripMenuItem;
        private System.Windows.Forms.Button btnAnimRestart;
    }
}

