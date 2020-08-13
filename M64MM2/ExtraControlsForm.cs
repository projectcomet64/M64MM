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
            byte[] livesBytes = (cbLivesHud.Checked ? StringToByteArray("0C0B8DD1") : emptyWord);
            byte[] powerBytes = (cbPowerMtr.Checked ? StringToByteArray("0C0B8D95") : emptyWord);
            byte[] coinBytes = (cbCoins.Checked ? StringToByteArray("0C0B8DEA") : emptyWord);
            byte[] starBytes = (cbStarsHud.Checked ? StringToByteArray("0C0B8E03") : emptyWord);
            byte[] cameraBytes = (cbLakitu.Checked ? StringToByteArray("0C0B8ECF") : emptyWord);

            WriteBytes(BaseAddress + 0x2E3DB0, livesBytes, true);
            WriteBytes(BaseAddress + 0x2E3E10, powerBytes, true);
            WriteBytes(BaseAddress + 0x2E3E18, coinBytes, true);
            WriteBytes(BaseAddress + 0x2E3DC8, starBytes, true);
            WriteBytes(BaseAddress + 0x2E3DE0, cameraBytes, true);

            //TODO: Move this to Update
            //WriteBytes(BaseAddress + 0x3325F4,StringToByteArray("FF000000"), true);
        }

        private void btnBatchWrite_Click(object sender, EventArgs e)
        {
            //TODO: Delete
        }

        private void btnClearBoxes_Click(object sender, EventArgs e)
        {
            //TODO: Delete
        }
    }
}
