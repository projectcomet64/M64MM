using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.Core;

namespace M64MM2
{
    public partial class AddonErrors : Form
    {
        public AddonErrors()
        {
            InitializeComponent();

            rtb_Details.Text = AddonErrorsBuilder.ToString();
        }

        private void AddonErrors_Load(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            AddonErrorsBuilder.Clear();
            rtb_Details.Text = AddonErrorsBuilder.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
