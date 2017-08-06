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
            this.lblSpecialThanks = new System.Windows.Forms.Label();
            this.lblBugReport = new System.Windows.Forms.Label();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblLicenseInfo = new System.Windows.Forms.Label();
            this.lnkDiscord = new System.Windows.Forms.LinkLabel();
            this.lnkGithubIssues = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
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
            this.appIcon.Image = global::M64MM2.Properties.Resources.M64MM2_New_Icon_2;
            resources.ApplyResources(this.appIcon, "appIcon");
            this.appIcon.Name = "appIcon";
            this.appIcon.TabStop = false;
            // 
            // lblSpecialThanks
            // 
            resources.ApplyResources(this.lblSpecialThanks, "lblSpecialThanks");
            this.lblSpecialThanks.Name = "lblSpecialThanks";
            // 
            // lblBugReport
            // 
            resources.ApplyResources(this.lblBugReport, "lblBugReport");
            this.lblBugReport.Name = "lblBugReport";
            // 
            // lnkEmail
            // 
            resources.ApplyResources(this.lnkEmail, "lnkEmail");
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.TabStop = true;
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblBuildDate
            // 
            resources.ApplyResources(this.lblBuildDate, "lblBuildDate");
            this.lblBuildDate.Name = "lblBuildDate";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblLicenseInfo
            // 
            resources.ApplyResources(this.lblLicenseInfo, "lblLicenseInfo");
            this.lblLicenseInfo.Name = "lblLicenseInfo";
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
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkGithubIssues);
            this.Controls.Add(this.lblLicenseInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblBuildDate);
            this.Controls.Add(this.lnkDiscord);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lblBugReport);
            this.Controls.Add(this.lblSpecialThanks);
            this.Controls.Add(this.appIcon);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.PictureBox appIcon;
        private System.Windows.Forms.Label lblSpecialThanks;
        private System.Windows.Forms.Label lblBugReport;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.Label lblBuildDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblLicenseInfo;
        private System.Windows.Forms.LinkLabel lnkDiscord;
        private System.Windows.Forms.LinkLabel lnkGithubIssues;
    }
}