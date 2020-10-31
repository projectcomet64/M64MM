using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using M64MM.Additions;

namespace M64MM2
{
    public partial class Taskman : Form
    {
        List<Addon> PluginList;
        ImageList PluginImageList;
        public Taskman(ref List<Addon> pl_)
        {
            InitializeComponent();
            PluginList = pl_;
            PluginImageList = new ImageList();
            PluginImageList.ColorDepth = ColorDepth.Depth32Bit;
            PluginImageList.ImageSize = new System.Drawing.Size(48  , 48);
            RepopulateList(PluginList, true, true);
            listView1.HideSelection = false;
            listView1.MouseClick += (a, b) => listViewOnRightClick(a, b);
        }

        private void RepopulateList(List<Addon> pl, bool resetList = false, bool resetWidths = false)
        {
            if (resetList)
            {
                listView1.View = View.Details;
                listView1.Items.Clear();
                PluginImageList.Images.Clear();
                listView1.View = View.LargeIcon;
            }
            if (resetWidths)
            {
                listView1.Columns.Add("Addon name", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Version", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Active?", -2, HorizontalAlignment.Center);
            }
            List<ListViewItem> lvil = new List<ListViewItem>();
            foreach (Addon a in pl)
            {
                PluginImageList.Images.Add(a.Icon);
            }
            listView1.LargeImageList = PluginImageList;
            for (int i = 0; i < pl.Count; i++)
            {

                ListViewItem lvi = new ListViewItem
                {
                    Text = pl[i].Name,
                    Tag = pl[i]
                };
                lvi.SubItems.Add(pl[i].Version);
                lvi.SubItems.Add(pl[i].Active ? "Yes" : "No");
                lvi.ImageIndex = i;
                lvil.Add(lvi);
                listView1.Update();
            }
            listView1.Items.AddRange(lvil.ToArray());
            listView1.Select();
        }

        private void listViewOnRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    cmsAddonStuff.Show(Cursor.Position);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                lb_Desc.Text = "Description: \n" + ((Addon)listView1.SelectedItems[0].Tag).Description;
                cb_pluginEnabled.Enabled = true;
                cb_pluginEnabled.Checked = ((Addon)listView1.SelectedItems[0].Tag).Active;
            }
            else
            {
                cb_pluginEnabled.Checked = false;
                lb_Desc.Text = "<Please select an item.>";
                cb_pluginEnabled.Enabled = false;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cb_pluginEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int lastSelIndex = listView1.SelectedIndices[0];
                Addon clickedAddon = ((Addon)listView1.SelectedItems[0].Tag);
                PluginList.Find(x => x == clickedAddon).Active = cb_pluginEnabled.Checked;
                listView1.Refresh();
            }

        }

        private void toggleActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addon clickedAddon = ((Addon)listView1.SelectedItems[0].Tag);
            PluginList.Find(x => x == clickedAddon).Active = !clickedAddon.Active;
            cb_pluginEnabled.Checked = clickedAddon.Active;
            listView1.SelectedItems[0].SubItems[2].Text = clickedAddon.Active ? "Yes" : "No";
            listView1.Refresh();
        }
    }
}
