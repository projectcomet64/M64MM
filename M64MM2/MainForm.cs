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
        AppearanceForm appearanceForm;
        bool cameraFrozen = false;
        bool cameraSoftFrozen = false;
        List<Animation> animList;
        Animation selectedAnimOld => animList[cbAnimOld.SelectedIndex];
        Animation selectedAnimNew => animList[cbAnimNew.SelectedIndex];


        public MainForm()
        {
            InitializeComponent();
            updateTimer.Start();
            animList = new List<Animation>();

            //Load animation data
            try
            {
                using (StreamReader sr =  new StreamReader("animation_data.txt"))
                {
                    while (!sr.EndOfStream && sr.Peek() != 0)
                    {
                        string rawLine = sr.ReadLine();
                        string[] splitLine = rawLine.Trim().Split('|');
                        
                        Animation anim;
                        anim.Value = splitLine[0];
                        //anim.Description = splitLine[1];
                        anim.RealIndex = int.Parse(splitLine[2]);
                        animList.Add(anim);

                        cbAnimOld.Items.Add(splitLine[1]);
                        cbAnimNew.Items.Add(splitLine[1]);

                        cbAnimOld.SelectedIndex = 0;
                        cbAnimNew.SelectedIndex = 0;
                    }
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

            lblProgramStatus.Text = "Status: Base address found at 0x" + BaseAddress.ToString("X8");


            //==============================
            //Main program logic starts here
            //------------------------------

            //Don't overwrite the camera state if we're in non-bugged first-person
            byte[] cameraState = SwapEndian(ReadBytes(BaseAddress + 0x33C848, 4), 4);
            lblCameraCode.Text = "0x" + BitConverter.ToString(cameraState).Replace("-", "");

            if (cameraFrozen && (cameraState[0] == 0xA2 || cameraState[0] < 0x80))
            {
                WriteUInt(BaseAddress + 0x33C848, 0x80000000);
            }


            //Handle hotkey input
            if (GetKey(Keys.LControlKey) || GetKey(Keys.RControlKey))
            {
                if (GetKey(Keys.D1))
                    FreezeCam(null, null);

                if (GetKey(Keys.D2))
                    UnfreezeCam(null, null);

                if (GetKey(Keys.D4))
                    SoftFreezeCam(null, null);

                if (GetKey(Keys.D5))
                    SoftUnfreezeCam(null, null);
            }
        }


        void WriteAnimSwap(object sender, EventArgs e)
        {
            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimNew.Value), 4);
            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
        }

        void WriteAnimReset(object sender, EventArgs e)
        {
            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimOld.Value), 4);
            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void WriteAnimResetAll(object sender, EventArgs e)
        {
            foreach (Animation anim in animList)
            {
                byte[] stuffToWrite = SwapEndian(StringToByteArray(anim.Value), 4);
                long address = BaseAddress + 0x64040 + (anim.RealIndex + 1) * 8;

                WriteBytes(address, stuffToWrite);
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


        private void colorCodeStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appearanceForm == null || appearanceForm.IsDisposed) appearanceForm = new AppearanceForm();

            if (!appearanceForm.Visible || appearanceForm.WindowState == FormWindowState.Minimized)
                appearanceForm.Show();
        }
    }

    struct Animation
    {
        public string Value;
        public int RealIndex;
    }
}
