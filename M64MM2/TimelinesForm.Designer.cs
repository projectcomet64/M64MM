namespace M64MM2
{
    partial class TimelinesForm
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
            this.tcTimelines = new System.Windows.Forms.TabControl();
            this.btnAllPlay = new System.Windows.Forms.Button();
            this.btnAllStop = new System.Windows.Forms.Button();
            this.scSplit = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.scSplit)).BeginInit();
            this.scSplit.Panel1.SuspendLayout();
            this.scSplit.Panel2.SuspendLayout();
            this.scSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTimelines
            // 
            this.tcTimelines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTimelines.Location = new System.Drawing.Point(0, 0);
            this.tcTimelines.Name = "tcTimelines";
            this.tcTimelines.SelectedIndex = 0;
            this.tcTimelines.Size = new System.Drawing.Size(1057, 321);
            this.tcTimelines.TabIndex = 0;
            // 
            // btnAllPlay
            // 
            this.btnAllPlay.Location = new System.Drawing.Point(12, 11);
            this.btnAllPlay.Name = "btnAllPlay";
            this.btnAllPlay.Size = new System.Drawing.Size(128, 23);
            this.btnAllPlay.TabIndex = 1;
            this.btnAllPlay.Text = "Set all timelines to Play";
            this.btnAllPlay.UseVisualStyleBackColor = true;
            this.btnAllPlay.Click += new System.EventHandler(this.btnAllPlay_Click);
            // 
            // btnAllStop
            // 
            this.btnAllStop.Location = new System.Drawing.Point(146, 11);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(160, 23);
            this.btnAllStop.TabIndex = 1;
            this.btnAllStop.Text = "Set all timelines to Pause";
            this.btnAllStop.UseVisualStyleBackColor = true;
            this.btnAllStop.Click += new System.EventHandler(this.btnAllStop_Click);
            // 
            // scSplit
            // 
            this.scSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scSplit.Location = new System.Drawing.Point(0, 0);
            this.scSplit.Name = "scSplit";
            this.scSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSplit.Panel1
            // 
            this.scSplit.Panel1.Controls.Add(this.tcTimelines);
            // 
            // scSplit.Panel2
            // 
            this.scSplit.Panel2.Controls.Add(this.btnAllPlay);
            this.scSplit.Panel2.Controls.Add(this.btnAllStop);
            this.scSplit.Size = new System.Drawing.Size(1057, 371);
            this.scSplit.SplitterDistance = 321;
            this.scSplit.TabIndex = 2;
            // 
            // TimelinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 371);
            this.Controls.Add(this.scSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1073, 410);
            this.Name = "TimelinesForm";
            this.Text = "Timelines";
            this.Load += new System.EventHandler(this.TimelinesForm_Load);
            this.scSplit.Panel1.ResumeLayout(false);
            this.scSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSplit)).EndInit();
            this.scSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTimelines;
        private System.Windows.Forms.Button btnAllPlay;
        private System.Windows.Forms.Button btnAllStop;
        private System.Windows.Forms.SplitContainer scSplit;
    }
}