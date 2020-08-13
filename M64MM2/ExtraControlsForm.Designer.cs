namespace M64MM2
{
    partial class ExtraControlsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraControlsForm));
            this.tbLevitate = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCoins = new System.Windows.Forms.CheckBox();
            this.cbPowerMtr = new System.Windows.Forms.CheckBox();
            this.cbLakitu = new System.Windows.Forms.CheckBox();
            this.cbStarsHud = new System.Windows.Forms.CheckBox();
            this.cbLivesHud = new System.Windows.Forms.CheckBox();
            this.btnRemoveHud = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbLevitate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLevitate
            // 
            resources.ApplyResources(this.tbLevitate, "tbLevitate");
            this.tbLevitate.Maximum = 5;
            this.tbLevitate.Name = "tbLevitate";
            this.tbLevitate.ValueChanged += new System.EventHandler(this.tbLevitate_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLevitate);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCoins);
            this.groupBox2.Controls.Add(this.cbPowerMtr);
            this.groupBox2.Controls.Add(this.cbLakitu);
            this.groupBox2.Controls.Add(this.cbStarsHud);
            this.groupBox2.Controls.Add(this.cbLivesHud);
            this.groupBox2.Controls.Add(this.btnRemoveHud);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cbCoins
            // 
            resources.ApplyResources(this.cbCoins, "cbCoins");
            this.cbCoins.Name = "cbCoins";
            this.cbCoins.UseVisualStyleBackColor = true;
            // 
            // cbPowerMtr
            // 
            resources.ApplyResources(this.cbPowerMtr, "cbPowerMtr");
            this.cbPowerMtr.Name = "cbPowerMtr";
            this.cbPowerMtr.UseVisualStyleBackColor = true;
            // 
            // cbLakitu
            // 
            resources.ApplyResources(this.cbLakitu, "cbLakitu");
            this.cbLakitu.Name = "cbLakitu";
            this.cbLakitu.UseVisualStyleBackColor = true;
            // 
            // cbStarsHud
            // 
            resources.ApplyResources(this.cbStarsHud, "cbStarsHud");
            this.cbStarsHud.Name = "cbStarsHud";
            this.cbStarsHud.UseVisualStyleBackColor = true;
            // 
            // cbLivesHud
            // 
            resources.ApplyResources(this.cbLivesHud, "cbLivesHud");
            this.cbLivesHud.Name = "cbLivesHud";
            this.cbLivesHud.UseVisualStyleBackColor = true;
            // 
            // btnRemoveHud
            // 
            resources.ApplyResources(this.btnRemoveHud, "btnRemoveHud");
            this.btnRemoveHud.Name = "btnRemoveHud";
            this.btnRemoveHud.UseVisualStyleBackColor = true;
            this.btnRemoveHud.Click += new System.EventHandler(this.btnRemoveHud_Click);
            // 
            // ExtraControlsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExtraControlsForm";
            ((System.ComponentModel.ISupportInitialize)(this.tbLevitate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tbLevitate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveHud;
        private System.Windows.Forms.CheckBox cbCoins;
        private System.Windows.Forms.CheckBox cbPowerMtr;
        private System.Windows.Forms.CheckBox cbLakitu;
        private System.Windows.Forms.CheckBox cbStarsHud;
        private System.Windows.Forms.CheckBox cbLivesHud;
    }
}