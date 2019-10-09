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
    public partial class ExtraControlsForm : Form
    {
        public ExtraControlsForm()
        {
            InitializeComponent();

            if (!IsEmuOpen || BaseAddress == 0) return;

            tbLevitate.Value = ReadBytes(BaseAddress + 0x33B223, 1)[0];

        }

        void tbLevitate_ValueChanged(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            byte[] data = { (byte)tbLevitate.Value };
            WriteBytes(BaseAddress + 0x33B223, data);
        }

        void btnRemoveHud_Click(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            WriteBatchBytes(new long[] { 0x2E3DB0, 0x2E3DE0, 0x2E3E18, 0x2E3DC8 }, new byte[] { 0,0,0,0 }, true);
            WriteBytes(BaseAddress + 0x3325F4, SwapEndianRet(StringToByteArray("01000000"), 4));
        }

        private void btnBatchWrite_Click(object sender, EventArgs e)
        {
            //TODO: Remake this feature for later uses to use Longs instead of Strings (wtf)

            /*
            //Separate by commas and only commas
            string[] addrs = tbAddresses.Text.Split(',');
            //for (int i = 0; i < addrs.Length; i++)
            //{
            //    addrs[i] = "0x" + addrs[i];
            //}
            byte[] dataTW = StringToByteArray(tbData.Text.ToUpper());
            WriteBatchBytes(addrs, dataTW, true);
            */
        }

        private void btnClearBoxes_Click(object sender, EventArgs e)
        {
            tbAddresses.Text = "";
            tbData.Text = "";
        }
    }
}
