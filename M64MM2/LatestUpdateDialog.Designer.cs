namespace M64MM2
{
    partial class LatestUpdateDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LatestUpdateDialog));
            this.rtbUpdateNotes = new System.Windows.Forms.RichTextBox();
            this.lbCurrentVersion = new System.Windows.Forms.Label();
            this.lbLatestVersion = new System.Windows.Forms.Label();
            this.btnOpenRel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbUpdateNotes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbUpdateNotes
            // 
            resources.ApplyResources(this.rtbUpdateNotes, "rtbUpdateNotes");
            this.rtbUpdateNotes.Name = "rtbUpdateNotes";
            this.rtbUpdateNotes.ReadOnly = true;
            // 
            // lbCurrentVersion
            // 
            resources.ApplyResources(this.lbCurrentVersion, "lbCurrentVersion");
            this.lbCurrentVersion.Name = "lbCurrentVersion";
            // 
            // lbLatestVersion
            // 
            resources.ApplyResources(this.lbLatestVersion, "lbLatestVersion");
            this.lbLatestVersion.Name = "lbLatestVersion";
            // 
            // btnOpenRel
            // 
            resources.ApplyResources(this.btnOpenRel, "btnOpenRel");
            this.btnOpenRel.Name = "btnOpenRel";
            this.btnOpenRel.UseVisualStyleBackColor = true;
            this.btnOpenRel.Click += new System.EventHandler(this.btnOpenRel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbUpdateNotes
            // 
            resources.ApplyResources(this.lbUpdateNotes, "lbUpdateNotes");
            this.lbUpdateNotes.Name = "lbUpdateNotes";
            // 
            // LatestUpdateDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbUpdateNotes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOpenRel);
            this.Controls.Add(this.lbLatestVersion);
            this.Controls.Add(this.lbCurrentVersion);
            this.Controls.Add(this.rtbUpdateNotes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LatestUpdateDialog";
            this.Load += new System.EventHandler(this.LatestUpdateDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbUpdateNotes;
        private System.Windows.Forms.Label lbCurrentVersion;
        private System.Windows.Forms.Label lbLatestVersion;
        private System.Windows.Forms.Button btnOpenRel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbUpdateNotes;
    }
}