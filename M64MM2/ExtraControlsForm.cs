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
        static readonly byte[] threeEmptyWords = new byte[12];
        static readonly byte[] defaultLivesBytes = StringToByteArray("2C0000002A00000025640000");
        static readonly byte[] defaultCoinBytes = StringToByteArray("2B0000002A00000025640000");
        static readonly byte[] defaultStarBytes = StringToByteArray("2D0000002A00000025640000");
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
            // Thank you Shygoo
            byte[] livesBytes = (cbLivesHud.Checked ? defaultLivesBytes : threeEmptyWords);
            byte[] coinBytes = (cbCoins.Checked ? defaultCoinBytes : threeEmptyWords);
            byte[] starBytes = (cbStarsHud.Checked ? defaultStarBytes : threeEmptyWords);
            byte[] powerBytes = (cbPowerMtr.Checked ? StringToByteArray("0100008C") : StringToByteArray("0100FF00"));
            byte[] cameraBytes = (cbLakitu.Checked ? StringToByteArray("0C0B8ECF") : emptyWord);

            WriteBytes(BaseAddress + 0x338380, livesBytes, true);
            WriteBytes(BaseAddress + 0x33838C, coinBytes, true);
            WriteBytes(BaseAddress + 0x338398, starBytes, true);
            WriteBytes(BaseAddress + 0x3325F0, powerBytes, true);
            WriteBytes(BaseAddress + 0x2E3E18, cameraBytes, true);
        }
    }
}
