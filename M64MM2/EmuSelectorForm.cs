using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M64MM.Utils;
namespace M64MM2
{
    public partial class EmuSelectorForm : Form
    {


        public EmuSelectorForm(Process[] plist)
        {
            InitializeComponent();
            lbEmu.Items.AddRange(plist);
            lbEmu.DisplayMember = "MainWindowTitle";
        }

        private void lbOK_Click(object sender, EventArgs e)
        {
            if (lbEmu.SelectedItem != null)
            {
                Core.SelectEmuProcess((Process)lbEmu.SelectedItem);
                Close();
            }
            else
            {
                lbEmu.Focus();
                ToolTip tt = new ToolTip();
                tt.SetToolTip(lbEmu, "Select an emulator");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Core.StopProcessSearch = false;
            Close();
        }
    
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Core.StopProcessSearch = false;
        }

        private void btnBringToFront_Click(object sender, EventArgs e)
        {
            if (lbEmu.SelectedItem != null)
            {
                Core.SetForegroundWindow(((Process)lbEmu.SelectedItem).MainWindowHandle);
            }
        }
    }
}
