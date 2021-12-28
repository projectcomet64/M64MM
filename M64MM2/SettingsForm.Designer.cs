namespace M64MM2
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.cbEnableHotkeys = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbCheckUpdates = new System.Windows.Forms.CheckBox();
            this.cbEnablePowercamStartup = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCamStyles = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpHandling = new System.Windows.Forms.TabPage();
            this.tpNetwork = new System.Windows.Forms.TabPage();
            this.tpCamera = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTurbo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpHandling.SuspendLayout();
            this.tpNetwork.SuspendLayout();
            this.tpCamera.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEnableHotkeys
            // 
            resources.ApplyResources(this.cbEnableHotkeys, "cbEnableHotkeys");
            this.cbEnableHotkeys.Name = "cbEnableHotkeys";
            this.cbEnableHotkeys.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbCheckUpdates
            // 
            resources.ApplyResources(this.cbCheckUpdates, "cbCheckUpdates");
            this.cbCheckUpdates.Name = "cbCheckUpdates";
            this.cbCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // cbEnablePowercamStartup
            // 
            resources.ApplyResources(this.cbEnablePowercamStartup, "cbEnablePowercamStartup");
            this.cbEnablePowercamStartup.Name = "cbEnablePowercamStartup";
            this.cbEnablePowercamStartup.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbCamStyles
            // 
            this.cbCamStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamStyles.FormattingEnabled = true;
            resources.ApplyResources(this.cbCamStyles, "cbCamStyles");
            this.cbCamStyles.Name = "cbCamStyles";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpHandling);
            this.tabControl1.Controls.Add(this.tpNetwork);
            this.tabControl1.Controls.Add(this.tpCamera);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpHandling
            // 
            this.tpHandling.Controls.Add(this.label5);
            this.tpHandling.Controls.Add(this.label4);
            this.tpHandling.Controls.Add(this.cbTurbo);
            this.tpHandling.Controls.Add(this.cbEnableHotkeys);
            resources.ApplyResources(this.tpHandling, "tpHandling");
            this.tpHandling.Name = "tpHandling";
            this.tpHandling.UseVisualStyleBackColor = true;
            // 
            // tpNetwork
            // 
            this.tpNetwork.Controls.Add(this.label3);
            this.tpNetwork.Controls.Add(this.cbCheckUpdates);
            resources.ApplyResources(this.tpNetwork, "tpNetwork");
            this.tpNetwork.Name = "tpNetwork";
            this.tpNetwork.UseVisualStyleBackColor = true;
            // 
            // tpCamera
            // 
            this.tpCamera.Controls.Add(this.label2);
            this.tpCamera.Controls.Add(this.cbEnablePowercamStartup);
            this.tpCamera.Controls.Add(this.cbCamStyles);
            this.tpCamera.Controls.Add(this.label1);
            resources.ApplyResources(this.tpCamera, "tpCamera");
            this.tpCamera.Name = "tpCamera";
            this.tpCamera.UseVisualStyleBackColor = true;
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
            // cbTurbo
            // 
            resources.ApplyResources(this.cbTurbo, "cbTurbo");
            this.cbTurbo.Name = "cbTurbo";
            this.cbTurbo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpHandling.ResumeLayout(false);
            this.tpHandling.PerformLayout();
            this.tpNetwork.ResumeLayout(false);
            this.tpNetwork.PerformLayout();
            this.tpCamera.ResumeLayout(false);
            this.tpCamera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEnableHotkeys;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbCheckUpdates;
        private System.Windows.Forms.CheckBox cbEnablePowercamStartup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamStyles;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpHandling;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbTurbo;
        private System.Windows.Forms.TabPage tpNetwork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tpCamera;
        private System.Windows.Forms.Label label2;
    }
}