using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static M64MM2.Utils;


namespace M64MM2
{
    public partial class MainForm : Form
    {
        bool cameraFrozen = false;
        bool cameraSoftFrozen = false;
        List<Animation> animList;
        Dictionary<string, string> animData;
        Animation selectedAnimOld => animList[cbAnimOld.SelectedIndex];
        Animation selectedAnimNew => animList[cbAnimNew.SelectedIndex];


        public MainForm()
        {
            InitializeComponent();
            updateTimer.Start();
            animList = new List<Animation>();
            animData = new Dictionary<string, string>();

            try
            {
                using (StreamReader sr =  new StreamReader("animation_data.txt"))
                {
                    do
                    {
                        string rawLine = sr.ReadLine();
                        string[] splitLine = rawLine.Trim().Split('|');
                        
                        Animation anim;
                        anim.Value = splitLine[0];
                        //anim.Description = splitLine[1];
                        anim.Index = int.Parse(splitLine[2]);
                        animList.Add(anim);
                        animData.Add(splitLine[0], splitLine[1]);
                    }
                    while (sr.Peek() >= 0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                cbAnimOld.Text = "Animation data not loaded!";
                cbAnimNew.Text = "Animation data not loaded!";
                cbAnimOld.Enabled = false;
                cbAnimNew.Enabled = false;
                btnAnimSwap.Enabled = false;
                btnAnimReset.Enabled = false;
                btnAnimResetAll.Enabled = false;
            }

            if (animData.Count > 0)
            {
                cbAnimOld.DataSource = new BindingSource(animData, null);
                cbAnimOld.DisplayMember = "Value";
                cbAnimOld.ValueMember = "Key";

                cbAnimNew.DataSource = new BindingSource(animData, null);
                cbAnimNew.DisplayMember = "Value";
                cbAnimNew.ValueMember = "Key";

                cbAnimOld.SelectedIndex = 0;
                cbAnimNew.SelectedIndex = 0;

                cbAnimOld.Refresh();
                cbAnimNew.Refresh();
            }
        }

        void Update(object sender, EventArgs e)
        {
            //Early validity checks
            if (!IsEmuOpen)
            {
                lblProgramStatus.Text = "Status: Project64 is not open.";
                FindEmuProcess();
                return;
            }

            FindBaseAddress();
            if (BaseAddress <= 0)
            {
                lblProgramStatus.Text = "Status: Base address not found.";
                return;
            }

            lblProgramStatus.Text = "Status: Base address found at 0x" + BaseAddress.ToString("X");


            //Main program logic starts here
            if (cameraFrozen)
            {
                WriteUInt(BaseAddress + 0x33C848, 0x80000000);
            }
        }


        void WriteAnimSwap(object sender, EventArgs e)
        {
            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimNew.Value), 4);
            WriteBytes(BaseAddress + 0x64040 + ((selectedAnimOld.Index + 1) * 8), stuffToWrite);
        }

        void WriteAnimReset(object sender, EventArgs e)
        {
            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimOld.Value), 4);
            WriteBytes(BaseAddress + 0x64040 + ((selectedAnimOld.Index + 1) * 8), stuffToWrite);

            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void WriteAnimResetAll(object sender, EventArgs e)
        {
            foreach (Animation anim in animList)
            {
                byte[] stuffToWrite = SwapEndian(StringToByteArray(anim.Value), 4);
                WriteBytes(BaseAddress + 0x64040 + ((anim.Index + 1) * 8), stuffToWrite);
            }

            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }


        void FreezeCam(object sender, EventArgs e)
        {
            cameraFrozen = true;
            WriteUInt(BaseAddress + 0x33C848, 0x80000000);
            lblCameraStatus.Text = "Camera State: Frozen";
        }

        void UnfreezeCam(object sender, EventArgs e)
        {
            cameraFrozen = false;
            WriteUInt(BaseAddress + 0x33C848, 0x00000000);

            lblCameraStatus.Text = cameraSoftFrozen ? "Camera State: Soft-Frozen" : "Camera State: Default";
        }

        void SoftFreezeCam(object sender, EventArgs e)
        {
            cameraSoftFrozen = true;
            WriteUInt(BaseAddress + 0x33B204, 0x8001C520);

            lblCameraStatus.Text = cameraFrozen ? "Camera State: Frozen" : "Camera State: Soft-Frozen";
        }

        void SoftUnfreezeCam(object sender, EventArgs e)
        {
            cameraSoftFrozen = false;
            WriteUInt(BaseAddress + 0x33B204, 0x8033C520);

            lblCameraStatus.Text = cameraFrozen ? "Camera State: Frozen" : "Camera State: Default";
        }
    }

    struct Animation
    {
        public string Value;
        public int Index;
    }
}
