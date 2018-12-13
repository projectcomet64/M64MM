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
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsMenuItem,
            this.aboutMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // toolsMenuItem
            // 
            resources.ApplyResources(this.toolsMenuItem, "toolsMenuItem");
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appearanceSettingsMenuItem,
            this.extraControlsToolStripMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            // 
            // appearanceSettingsMenuItem
            // 
            resources.ApplyResources(this.appearanceSettingsMenuItem, "appearanceSettingsMenuItem");
            this.appearanceSettingsMenuItem.Name = "appearanceSettingsMenuItem";
            this.appearanceSettingsMenuItem.Click += new System.EventHandler(this.openAppearanceSettings);
            // 
            // extraControlsToolStripMenuItem
            // 
            resources.ApplyResources(this.extraControlsToolStripMenuItem, "extraControlsToolStripMenuItem");
            this.extraControlsToolStripMenuItem.Name = "extraControlsToolStripMenuItem";
            this.extraControlsToolStripMenuItem.Click += new System.EventHandler(this.openExtraControls);
            // 
            // aboutMenuItem
            // 
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Click += new System.EventHandler(this.openAboutForm);
            // 
            // grpCamera
            // 
            resources.ApplyResources(this.grpCamera, "grpCamera");
            this.grpCamera.Controls.Add(this.btnSoftUnfreeze);
            this.grpCamera.Controls.Add(this.btnSoftFreeze);
            this.grpCamera.Controls.Add(this.btnUnfreeze);
            this.grpCamera.Controls.Add(this.btnFreeze);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.TabStop = false;
            // 
            // btnSoftUnfreeze
            // 
            resources.ApplyResources(this.btnSoftUnfreeze, "btnSoftUnfreeze");
            this.btnSoftUnfreeze.Name = "btnSoftUnfreeze";
            this.btnSoftUnfreeze.UseVisualStyleBackColor = true;
            this.btnSoftUnfreeze.Click += new System.EventHandler(this.SoftUnfreezeCam);
            // 
            // btnSoftFreeze
            // 
            resources.ApplyResources(this.btnSoftFreeze, "btnSoftFreeze");
            this.btnSoftFreeze.Name = "btnSoftFreeze";
            this.btnSoftFreeze.UseVisualStyleBackColor = true;
            this.btnSoftFreeze.Click += new System.EventHandler(this.SoftFreezeCam);
            // 
            // btnUnfreeze
            // 
            resources.ApplyResources(this.btnUnfreeze, "btnUnfreeze");
            this.btnUnfreeze.Name = "btnUnfreeze";
            this.btnUnfreeze.UseVisualStyleBackColor = true;
            this.btnUnfreeze.Click += new System.EventHandler(this.UnfreezeCam);
            // 
            // btnFreeze
            // 
            resources.ApplyResources(this.btnFreeze, "btnFreeze");
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.UseVisualStyleBackColor = true;
            this.btnFreeze.Click += new System.EventHandler(this.FreezeCam);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgramStatus,
            this.lblCameraStatus,
            this.lblCameraCode});
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // lblProgramStatus
            // 
            resources.ApplyResources(this.lblProgramStatus, "lblProgramStatus");
            this.lblProgramStatus.Name = "lblProgramStatus";
            // 
            // lblCameraStatus
            // 
            resources.ApplyResources(this.lblCameraStatus, "lblCameraStatus");
            this.lblCameraStatus.Name = "lblCameraStatus";
            // 
            // lblCameraCode
            // 
            resources.ApplyResources(this.lblCameraCode, "lblCameraCode");
            this.lblCameraCode.Name = "lblCameraCode";
            // 
            // grpAnimSwap
            // 
            resources.ApplyResources(this.grpAnimSwap, "grpAnimSwap");
            this.grpAnimSwap.Controls.Add(this.btnAnimRestart);
            this.grpAnimSwap.Controls.Add(this.btnAnimResetAll);
            this.grpAnimSwap.Controls.Add(this.btnAnimReset);
            this.grpAnimSwap.Controls.Add(this.btnAnimSwap);
            this.grpAnimSwap.Controls.Add(this.lblAnimNew);
            this.grpAnimSwap.Controls.Add(this.lblAnimOld);
            this.grpAnimSwap.Controls.Add(this.cbAnimNew);
            this.grpAnimSwap.Controls.Add(this.cbAnimOld);
            this.grpAnimSwap.Name = "grpAnimSwap";
            this.grpAnimSwap.TabStop = false;
            // 
            // btnAnimRestart
            // 
            resources.ApplyResources(this.btnAnimRestart, "btnAnimRestart");
            this.btnAnimRestart.Name = "btnAnimRestart";
            this.btnAnimRestart.UseVisualStyleBackColor = true;
            this.btnAnimRestart.Click += new System.EventHandler(this.btnAnimRestart_Click);
            // 
            // btnAnimResetAll
            // 
            resources.ApplyResources(this.btnAnimResetAll, "btnAnimResetAll");
            this.btnAnimResetAll.Name = "btnAnimResetAll";
            this.btnAnimResetAll.UseVisualStyleBackColor = true;
            this.btnAnimResetAll.Click += new System.EventHandler(this.WriteAnimResetAll);
            // 
            // btnAnimReset
            // 
            resources.ApplyResources(this.btnAnimReset, "btnAnimReset");
            this.btnAnimReset.Name = "btnAnimReset";
            this.btnAnimReset.UseVisualStyleBackColor = true;
            this.btnAnimReset.Click += new System.EventHandler(this.WriteAnimReset);
            // 
            // btnAnimSwap
            // 
            resources.ApplyResources(this.btnAnimSwap, "btnAnimSwap");
            this.btnAnimSwap.Name = "btnAnimSwap";
            this.btnAnimSwap.UseVisualStyleBackColor = true;
            this.btnAnimSwap.Click += new System.EventHandler(this.WriteAnimSwap);
            // 
            // lblAnimNew
            // 
            resources.ApplyResources(this.lblAnimNew, "lblAnimNew");
            this.lblAnimNew.Name = "lblAnimNew";
            // 
            // lblAnimOld
            // 
            resources.ApplyResources(this.lblAnimOld, "lblAnimOld");
            this.lblAnimOld.Name = "lblAnimOld";
            // 
            // cbAnimNew
            // 
            resources.ApplyResources(this.cbAnimNew, "cbAnimNew");
            this.cbAnimNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAnimNew.Name = "cbAnimNew";
            // 
            // cbAnimOld
            // 
            resources.ApplyResources(this.cbAnimOld, "cbAnimOld");
            this.cbAnimOld.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimOld.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAnimOld.Name = "cbAnimOld";
            this.cbAnimOld.SelectedIndexChanged += new System.EventHandler(this.cbAnimOld_SelectedIndexChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.Update);
            // 
            // grpCamStyle
            // 
            resources.ApplyResources(this.grpCamStyle, "grpCamStyle");
            this.grpCamStyle.Controls.Add(this.btnChangeCamStyle);
            this.grpCamStyle.Controls.Add(this.cbCamStyles);
            this.grpCamStyle.Name = "grpCamStyle";
            this.grpCamStyle.TabStop = false;
            // 
            // btnChangeCamStyle
            // 
            resources.ApplyResources(this.btnChangeCamStyle, "btnChangeCamStyle");
            this.btnChangeCamStyle.Name = "btnChangeCamStyle";
            this.btnChangeCamStyle.UseVisualStyleBackColor = true;
            this.btnChangeCamStyle.Click += new System.EventHandler(this.changeCameraStyle);
            // 
            // cbCamStyles
            // 
            resources.ApplyResources(this.cbCamStyles, "cbCamStyles");
            this.cbCamStyles.FormattingEnabled = true;
            this.cbCamStyles.Name = "cbCamStyles";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCamStyle);
            this.Controls.Add(this.grpAnimSwap);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
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

