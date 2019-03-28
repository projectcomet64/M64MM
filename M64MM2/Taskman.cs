using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using M64MM;

namespace M64MM2
{
    public partial class Taskman : Form
    {
        public Taskman(ICollection PluginList)
        {
            InitializeComponent();
            List<ListViewItem> lvil = new List<ListViewItem>();
            listView1.View = View.Details;
            listView1.Columns.Add("Plugin name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Version", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Is active everyframe", -2, HorizontalAlignment.Center);
            foreach (Plugin p in PluginList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = p.Name;
                lvi.Tag = p;
                lvi.SubItems.Add(p.Version);
                lvi.SubItems.Add(p.Active.ToString());
                lvil.Add(lvi);
            }
            listView1.Items.AddRange(lvil.ToArray());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                lb_Desc.Text = "Description: \n" + ((Plugin)listView1.SelectedItems[0].Tag).Description;
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
    }
}
