using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using M64MM;

namespace M64MM2
{
    public partial class Taskman : Form
    {
        List<Plugin> PluginList;
        public Taskman(ref List<Plugin> pl_)
        {
            InitializeComponent();
            PluginList = pl_;
            RepopulateList(PluginList, true);
        }

        private void RepopulateList(List<Plugin> pl, bool resetList = false)
        {
            if (resetList)
            {
                listView1.View = View.Details;
                listView1.Clear();
                listView1.Columns.Add("Plugin name", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Version", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Is active everyframe", -2, HorizontalAlignment.Center);
            }
            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = 0; i < pl.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = pl[i].Name;
                lvi.Tag = pl[i];
                lvi.SubItems.Add(pl[i].Version);
                lvi.SubItems.Add(pl[i].Active.ToString());
                lvil.Add(lvi);
            }
            listView1.Items.AddRange(lvil.ToArray());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                lb_Desc.Text = "Description: \n" + ((Plugin)listView1.SelectedItems[0].Tag).Description;
                cb_pluginEnabled.Checked = ((Plugin)listView1.SelectedItems[0].Tag).Active;
            }
            else
            {
                lb_Desc.Text = "<Please select an item.>";
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
                ((Plugin)listView1.SelectedItems[0].Tag).Active = cb_pluginEnabled.Checked;
                RepopulateList(PluginList, true);
            }
                
        }
    }
}
