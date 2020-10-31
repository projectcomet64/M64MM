namespace M64MM2
{
    partial class EmuSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmuSelectorForm));
            this.lbEmu = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBringToFront = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEmu
            // 
            this.lbEmu.FormattingEnabled = true;
            resources.ApplyResources(this.lbEmu, "lbEmu");
            this.lbEmu.Name = "lbEmu";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbOK
            // 
            resources.ApplyResources(this.lbOK, "lbOK");
            this.lbOK.Name = "lbOK";
            this.lbOK.UseVisualStyleBackColor = true;
            this.lbOK.Click += new System.EventHandler(this.lbOK_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBringToFront
            // 
            resources.ApplyResources(this.btnBringToFront, "btnBringToFront");
            this.btnBringToFront.Name = "btnBringToFront";
            this.btnBringToFront.UseVisualStyleBackColor = true;
            this.btnBringToFront.Click += new System.EventHandler(this.btnBringToFront_Click);
            // 
            // EmuSelectorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBringToFront);
            this.Controls.Add(this.lbOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbEmu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmuSelectorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbEmu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lbOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBringToFront;
    }
}