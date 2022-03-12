namespace M64MM2
{
    partial class Taskman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Taskman));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lb_Desc = new System.Windows.Forms.Label();
            this.cb_pluginEnabled = new System.Windows.Forms.CheckBox();
            this.cmsAddonStuff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toggleActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAddonStuff.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btn_OK
            // 
            resources.ApplyResources(this.btn_OK, "btn_OK");
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lb_Desc
            // 
            resources.ApplyResources(this.lb_Desc, "lb_Desc");
            this.lb_Desc.Name = "lb_Desc";
            // 
            // cb_pluginEnabled
            // 
            resources.ApplyResources(this.cb_pluginEnabled, "cb_pluginEnabled");
            this.cb_pluginEnabled.Name = "cb_pluginEnabled";
            this.cb_pluginEnabled.UseVisualStyleBackColor = true;
            this.cb_pluginEnabled.CheckedChanged += new System.EventHandler(this.cb_pluginEnabled_CheckedChanged);
            // 
            // cmsAddonStuff
            // 
            resources.ApplyResources(this.cmsAddonStuff, "cmsAddonStuff");
            this.cmsAddonStuff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleActiveToolStripMenuItem});
            this.cmsAddonStuff.Name = "cmsAddonStuff";
            // 
            // toggleActiveToolStripMenuItem
            // 
            resources.ApplyResources(this.toggleActiveToolStripMenuItem, "toggleActiveToolStripMenuItem");
            this.toggleActiveToolStripMenuItem.Name = "toggleActiveToolStripMenuItem";
            this.toggleActiveToolStripMenuItem.Click += new System.EventHandler(this.toggleActiveToolStripMenuItem_Click);
            // 
            // Taskman
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_pluginEnabled);
            this.Controls.Add(this.lb_Desc);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Taskman";
            this.cmsAddonStuff.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lb_Desc;
        private System.Windows.Forms.CheckBox cb_pluginEnabled;
        private System.Windows.Forms.ContextMenuStrip cmsAddonStuff;
        private System.Windows.Forms.ToolStripMenuItem toggleActiveToolStripMenuItem;
    }
}