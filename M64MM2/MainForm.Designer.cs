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
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.btnSoftUnfreeze = new System.Windows.Forms.Button();
            this.btnSoftFreeze = new System.Windows.Forms.Button();
            this.btnUnfreeze = new System.Windows.Forms.Button();
            this.btnFreeze = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProgramStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpAnimSwap = new System.Windows.Forms.GroupBox();
            this.btnAnimResetAll = new System.Windows.Forms.Button();
            this.btnAnimReset = new System.Windows.Forms.Button();
            this.btnAnimSwap = new System.Windows.Forms.Button();
            this.lblAnimNew = new System.Windows.Forms.Label();
            this.lblAnimOld = new System.Windows.Forms.Label();
            this.cbAnimNew = new System.Windows.Forms.ComboBox();
            this.cbAnimOld = new System.Windows.Forms.ComboBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.grpCamera.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpAnimSwap.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.toolsMenuItem,
            this.aboutMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            resources.ApplyResources(this.settingsMenuItem, "settingsMenuItem");
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.Name = "toolsMenuItem";
            resources.ApplyResources(this.toolsMenuItem, "toolsMenuItem");
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.btnSoftUnfreeze);
            this.grpCamera.Controls.Add(this.btnSoftFreeze);
            this.grpCamera.Controls.Add(this.btnUnfreeze);
            this.grpCamera.Controls.Add(this.btnFreeze);
            resources.ApplyResources(this.grpCamera, "grpCamera");
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
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgramStatus,
            this.lblCameraStatus});
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
            // grpAnimSwap
            // 
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
            this.cbAnimNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimNew.FormattingEnabled = true;
            resources.ApplyResources(this.cbAnimNew, "cbAnimNew");
            this.cbAnimNew.Name = "cbAnimNew";
            // 
            // cbAnimOld
            // 
            this.cbAnimOld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbAnimOld, "cbAnimOld");
            this.cbAnimOld.Name = "cbAnimOld";
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.Update);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpAnimSwap);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpCamera.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpAnimSwap.ResumeLayout(false);
            this.grpAnimSwap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
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
    }
}

