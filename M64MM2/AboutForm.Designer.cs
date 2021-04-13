namespace M64MM2
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblName = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.appIcon = new System.Windows.Forms.PictureBox();
            this.lblBugReport = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lnkDiscord = new System.Windows.Forms.LinkLabel();
            this.lnkGithubIssues = new System.Windows.Forms.LinkLabel();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblWhosInBanner = new System.Windows.Forms.Label();
            this.lblYouCanJoin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.Name = "lblAuthor";
            // 
            // appIcon
            // 
            this.appIcon.Image = global::M64MM2.Properties.Resources.version3_2big;
            resources.ApplyResources(this.appIcon, "appIcon");
            this.appIcon.Name = "appIcon";
            this.appIcon.TabStop = false;
            // 
            // lblBugReport
            // 
            resources.ApplyResources(this.lblBugReport, "lblBugReport");
            this.lblBugReport.Name = "lblBugReport";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lnkDiscord
            // 
            resources.ApplyResources(this.lnkDiscord, "lnkDiscord");
            this.lnkDiscord.Name = "lnkDiscord";
            this.lnkDiscord.TabStop = true;
            this.lnkDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDiscord_LinkClicked);
            // 
            // lnkGithubIssues
            // 
            resources.ApplyResources(this.lnkGithubIssues, "lnkGithubIssues");
            this.lnkGithubIssues.Name = "lnkGithubIssues";
            this.lnkGithubIssues.TabStop = true;
            this.lnkGithubIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGithubIssues_LinkClicked);
            // 
            // pbBanner
            // 
            this.pbBanner.Image = global::M64MM2.Properties.Resources.m64mm3_banner;
            resources.ApplyResources(this.pbBanner, "pbBanner");
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.TabStop = false;
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // lblWhosInBanner
            // 
            resources.ApplyResources(this.lblWhosInBanner, "lblWhosInBanner");
            this.lblWhosInBanner.Name = "lblWhosInBanner";
            // 
            // lblYouCanJoin
            // 
            resources.ApplyResources(this.lblYouCanJoin, "lblYouCanJoin");
            this.lblYouCanJoin.Name = "lblYouCanJoin";
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblYouCanJoin);
            this.Controls.Add(this.lblWhosInBanner);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.lnkGithubIssues);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkDiscord);
            this.Controls.Add(this.lblBugReport);
            this.Controls.Add(this.appIcon);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.PictureBox appIcon;
        private System.Windows.Forms.Label lblBugReport;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel lnkDiscord;
        private System.Windows.Forms.LinkLabel lnkGithubIssues;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblWhosInBanner;
        private System.Windows.Forms.Label lblYouCanJoin;
    }
}