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
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCamStyles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEnablePowercamStartup);
            this.Controls.Add(this.cbCheckUpdates);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbEnableHotkeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEnableHotkeys;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbCheckUpdates;
        private System.Windows.Forms.CheckBox cbEnablePowercamStartup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamStyles;
    }
}