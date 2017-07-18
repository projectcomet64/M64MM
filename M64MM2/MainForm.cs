using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M64MM2
{
    public partial class MainForm : Form
    {
        //private int animIndexOld = 0;
        //private int animIndexNew = 0;

        public MainForm()
        {
            InitializeComponent();
            updateTimer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            if (!MemoryIO.IsEmuOpen)
            {
                lblProgramStatus.Text = "Status: Project64 is not open.";
                MemoryIO.FindEmuProcess();
                return;
            }

            MemoryIO.FindBaseAddress();
            if (MemoryIO.BaseAddress <= 0)
            {
                lblProgramStatus.Text = "Status: Base address not found.";
                return;
            }

            lblProgramStatus.Text = "Status: Base address found at 0x" + MemoryIO.BaseAddress.ToString("X");
        }

        private void WriteAnimSwap()
        {
            //MemoryIO.WriteInt(MemoryIO.BaseAddress + 0x64040 + ((CB1AnimIndex + 1) * 8), int.Parse(GetChunks(SelectedAnim2, 8)(0), NumberStyles.HexNumber));
            //MemoryIO.WriteInt(MemoryIO.BaseAddress + 0x64044 + ((CB1AnimIndex + 1) * 8), int.Parse(GetChunks(SelectedAnim2, 8)(1), NumberStyles.HexNumber));
        }
    }

    struct Animation
    {
        public string Value;
        public string Description;
        public int Index;
    }
}
