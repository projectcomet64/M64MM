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
            this.showRunningPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForLatestUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.cbPowercam = new System.Windows.Forms.CheckBox();
            this.btnSoftFreeze = new System.Windows.Forms.Button();
            this.btnFreeze = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProgramStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpAnimSwap = new System.Windows.Forms.GroupBox();
            this.chbAutoApply = new System.Windows.Forms.CheckBox();
            this.btnAnimResetAll = new System.Windows.Forms.Button();
            this.btnAnimReset = new System.Windows.Forms.Button();
            this.btnAnimSwap = new System.Windows.Forms.Button();
            this.lblAnimNew = new System.Windows.Forms.Label();
            this.lblAnimOld = new System.Windows.Forms.Label();
            this.cbAnimNew = new System.Windows.Forms.ComboBox();
            this.cbAnimOld = new System.Windows.Forms.ComboBox();
            this.grpCamStyle = new System.Windows.Forms.GroupBox();
            this.btnChangeCamStyle = new System.Windows.Forms.Button();
            this.cbCamStyles = new System.Windows.Forms.ComboBox();
            this.ttAutoApplyInfo = new System.Windows.Forms.ToolTip(this.components);
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
            this.aboutMenuItem,
            this.settingsToolStripMenuItem,
            this.checkForLatestUpdateToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appearanceSettingsMenuItem,
            this.extraControlsToolStripMenuItem,
            this.showRunningPluginsToolStripMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            resources.ApplyResources(this.toolsMenuItem, "toolsMenuItem");
            // 
            // appearanceSettingsMenuItem
            // 
            this.appearanceSettingsMenuItem.Name = "appearanceSettingsMenuItem";
            resources.ApplyResources(this.appearanceSettingsMenuItem, "appearanceSettingsMenuItem");
            this.appearanceSettingsMenuItem.Click += new System.EventHandler(this.OpenAppearanceSettings);
            // 
            // extraControlsToolStripMenuItem
            // 
            this.extraControlsToolStripMenuItem.Name = "extraControlsToolStripMenuItem";
            resources.ApplyResources(this.extraControlsToolStripMenuItem, "extraControlsToolStripMenuItem");
            this.extraControlsToolStripMenuItem.Click += new System.EventHandler(this.OpenExtraControls);
            // 
            // showRunningPluginsToolStripMenuItem
            // 
            this.showRunningPluginsToolStripMenuItem.Name = "showRunningPluginsToolStripMenuItem";
            resources.ApplyResources(this.showRunningPluginsToolStripMenuItem, "showRunningPluginsToolStripMenuItem");
            this.showRunningPluginsToolStripMenuItem.Click += new System.EventHandler(this.showRunningPluginsToolStripMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            this.aboutMenuItem.Click += new System.EventHandler(this.OpenAboutForm);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // checkForLatestUpdateToolStripMenuItem
            // 
            this.checkForLatestUpdateToolStripMenuItem.Name = "checkForLatestUpdateToolStripMenuItem";
            resources.ApplyResources(this.checkForLatestUpdateToolStripMenuItem, "checkForLatestUpdateToolStripMenuItem");
            this.checkForLatestUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForLatestUpdateToolStripMenuItem_Click);
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.cbPowercam);
            this.grpCamera.Controls.Add(this.btnSoftFreeze);
            this.grpCamera.Controls.Add(this.btnFreeze);
            resources.ApplyResources(this.grpCamera, "grpCamera");
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.TabStop = false;
            // 
            // cbPowercam
            // 
            resources.ApplyResources(this.cbPowercam, "cbPowercam");
            this.cbPowercam.Name = "cbPowercam";
            this.ttAutoApplyInfo.SetToolTip(this.cbPowercam, resources.GetString("cbPowercam.ToolTip"));
            this.cbPowercam.UseVisualStyleBackColor = true;
            this.cbPowercam.CheckedChanged += new System.EventHandler(this.cbPowercam_CheckedChanged);
            // 
            // btnSoftFreeze
            // 
            resources.ApplyResources(this.btnSoftFreeze, "btnSoftFreeze");
            this.btnSoftFreeze.Name = "btnSoftFreeze";
            this.btnSoftFreeze.UseVisualStyleBackColor = true;
            this.btnSoftFreeze.Click += new System.EventHandler(this.ToggleSoftFreezeCam);
            // 
            // btnFreeze
            // 
            resources.ApplyResources(this.btnFreeze, "btnFreeze");
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.UseVisualStyleBackColor = true;
            this.btnFreeze.Click += new System.EventHandler(this.ToggleFreezeCam);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgramStatus,
            this.lblCameraStatus,
            this.lblCameraCode});
            resources.ApplyResources(this.statusStrip, "statusStrip");
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
            this.lblCameraCode.Name = "lblCameraCode";
            resources.ApplyResources(this.lblCameraCode, "lblCameraCode");
            // 
            // grpAnimSwap
            // 
            this.grpAnimSwap.Controls.Add(this.chbAutoApply);
            this.grpAnimSwap.Controls.Add(this.btnAnimResetAll);
            this.grpAnimSwap.Controls.Add(this.btnAnimReset);
            this.grpAnimSwap.Controls.Add(this.btnAnimSwap);
            this.grpAnimSwap.Controls.Add(this.lblAnimNew);
            this.grpAnimSwap.Controls.Add(this.lblAnimOld);
            this.grpAnimSwap.Controls.Add(this.cbAnimNew);
            this.grpAnimSwap.Controls.Add(this.cbAnimOld);
            resources.ApplyResources(this.grpAnimSwap, "grpAnimSwap");
            this.grpAnimSwap.Name = "grpAnimSwap";
            this.grpAnimSwap.TabStop = false;
            // 
            // chbAutoApply
            // 
            resources.ApplyResources(this.chbAutoApply, "chbAutoApply");
            this.chbAutoApply.Name = "chbAutoApply";
            this.ttAutoApplyInfo.SetToolTip(this.chbAutoApply, resources.GetString("chbAutoApply.ToolTip"));
            this.chbAutoApply.UseVisualStyleBackColor = true;
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
            this.cbAnimNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cbAnimNew, "cbAnimNew");
            this.cbAnimNew.Name = "cbAnimNew";
            this.cbAnimNew.SelectedIndexChanged += new System.EventHandler(this.cbAnimNew_SelectedIndexChanged);
            // 
            // cbAnimOld
            // 
            this.cbAnimOld.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAnimOld.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cbAnimOld, "cbAnimOld");
            this.cbAnimOld.Name = "cbAnimOld";
            this.cbAnimOld.SelectedIndexChanged += new System.EventHandler(this.cbAnimOld_SelectedIndexChanged);
            this.cbAnimOld.TextChanged += new System.EventHandler(this.cbAnimOld_TextChanged);
            // 
            // grpCamStyle
            // 
            this.grpCamStyle.Controls.Add(this.btnChangeCamStyle);
            this.grpCamStyle.Controls.Add(this.cbCamStyles);
            resources.ApplyResources(this.grpCamStyle, "grpCamStyle");
            this.grpCamStyle.Name = "grpCamStyle";
            this.grpCamStyle.TabStop = false;
            // 
            // btnChangeCamStyle
            // 
            resources.ApplyResources(this.btnChangeCamStyle, "btnChangeCamStyle");
            this.btnChangeCamStyle.Name = "btnChangeCamStyle";
            this.btnChangeCamStyle.UseVisualStyleBackColor = true;
            this.btnChangeCamStyle.Click += new System.EventHandler(this.ChangeCameraStyle);
            // 
            // cbCamStyles
            // 
            this.cbCamStyles.FormattingEnabled = true;
            resources.ApplyResources(this.cbCamStyles, "cbCamStyles");
            this.cbCamStyles.Name = "cbCamStyles";
            // 
            // ttAutoApplyInfo
            // 
            this.ttAutoApplyInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
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
            this.grpCamera.PerformLayout();
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
        private System.Windows.Forms.Button btnSoftFreeze;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblProgramStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraStatus;
        private System.Windows.Forms.GroupBox grpAnimSwap;
        private System.Windows.Forms.ComboBox cbAnimNew;
        private System.Windows.Forms.ComboBox cbAnimOld;
        private System.Windows.Forms.Label lblAnimOld;
        private System.Windows.Forms.Label lblAnimNew;
        private System.Windows.Forms.Button btnAnimSwap;
        private System.Windows.Forms.Button btnAnimResetAll;
        private System.Windows.Forms.Button btnAnimReset;
        private System.Windows.Forms.ToolStripMenuItem appearanceSettingsMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraCode;
        private System.Windows.Forms.GroupBox grpCamStyle;
        private System.Windows.Forms.ComboBox cbCamStyles;
        private System.Windows.Forms.Button btnChangeCamStyle;
        private System.Windows.Forms.ToolStripMenuItem extraControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRunningPluginsToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbAutoApply;
        private System.Windows.Forms.ToolTip ttAutoApplyInfo;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForLatestUpdateToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbPowercam;
    }
}

