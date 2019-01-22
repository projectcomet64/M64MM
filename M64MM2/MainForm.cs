using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using M64MM2.Properties;
using static M64MM2.Utils;


namespace M64MM2
{
    public partial class MainForm : Form
    {
        AppearanceForm appearanceForm;
        ExtraControlsForm extraControlsForm;
        bool cameraFrozen = false;
        bool cameraSoftFrozen = false;
        static ModelStatus modelStatus = ModelStatus.NONE;
        List<Animation> animList;
        List<CamStyle> camStyles;
        Animation defaultAnimation;
        Animation selectedAnimOld => cbAnimOld.SelectedIndex >= 0 ? animList[cbAnimOld.SelectedIndex] : new Animation();
        Animation selectedAnimNew => cbAnimNew.SelectedIndex >= 0 ? animList[cbAnimNew.SelectedIndex] : new Animation();
        static int ingameTimer;
        static int previousFrame;
        //This handles the "Each ingame frame"
        //ASYNCHRONOUS FOR THE WIN
        //FUNNILY ENOUGH! This takes little to no CPU, actually
        //It's goddamn amazing
        Task updateFunction = Task.Factory.StartNew(async () =>{
             while (true)
             {
                //If there's a level loaded EVEN if there's no model
                if (modelStatus != ModelStatus.NONE) { 
                    //Ingame timer update
                ingameTimer = (BitConverter.ToUInt16(SwapEndian(ReadBytes(BaseAddress + 0x33B198, 2), 4), 0));
                if (ingameTimer < previousFrame)
                {
                        //Ingame timer is a variable that decrements every frame in game. In case our previous snapshot of said value is above the timer:
                    foreach(Updatable upd in moduleList)
                    {
                            //Unity 1996
                        upd.Update();
                    }
                }
                //Set new value
                previousFrame = ingameTimer;
                    //If the ingame timer reaches zero then let's just write 255 more to it
                if (ingameTimer == 0){
                    await Task.Run(() => { WriteUInt(BaseAddress + 0x33B198, 255); });
                }
                }
                // zzz
                Thread.Sleep(1);
             }

            });

        public MainForm()
        {
            moduleList.Add(new UpdateCounterEveryFrame());
            InitializeComponent();
            Text = Resources.programName + " " + Application.ProductVersion;
            updateTimer.Interval = 1000;
            updateTimer.Start();
            animList = new List<Animation>();
            camStyles = new List<CamStyle>();
            defaultAnimation.Value = "0";
            lblCameraStatus.Text = Resources.cameraStateDefault;
            toolsMenuItem.Enabled = false;

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
                        try
                        {
                            if (splitLine[3] != null)
                            {
                                defaultAnimation = anim;
                            }
                        } catch (Exception)
                        {

                        }

                        cbAnimOld.Items.Add(splitLine[1]);
                        cbAnimNew.Items.Add(splitLine[1]);

                        cbAnimOld.SelectedIndex = 0;
                        cbAnimNew.SelectedIndex = 0;
                    }

                    btnAnimRestart.Enabled = (defaultAnimation.Value != "0");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                cbAnimOld.Text = cbAnimNew.Text = Resources.animDataNotLoaded;
                cbAnimOld.Enabled = false;
                cbAnimNew.Enabled = false;
                btnAnimSwap.Enabled = false;
                btnAnimReset.Enabled = false;
                btnAnimResetAll.Enabled = false;
                btnAnimReset.Enabled = false;
            }

            
            //Load camera style data
            try
            {
                using (StreamReader sr = new StreamReader("camera_data.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string rawLine = sr.ReadLine().Trim();
                        string[] splitLine = rawLine.Split('|');
                        CamStyle style = new CamStyle
                        {
                            Value = byte.Parse(splitLine[0], NumberStyles.HexNumber),
                            Name = splitLine[1]
                        };
                        camStyles.Add(style);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                cbCamStyles.Text = Resources.cameraDataNotLoaded;
                cbCamStyles.Enabled = false;
                btnChangeCamStyle.Enabled = false;
            }

            if (camStyles.Count > 0)
            {
                foreach (CamStyle style in camStyles)
                {
                    cbCamStyles.Items.Add(style.Name);
                }
                cbCamStyles.SelectedIndex = 0;
                cbCamStyles.Refresh();
            }

        }

        void Update(object sender, EventArgs e)
        {
            //Early validity checks
            if (!IsEmuOpen)
            {
                Text = Resources.programName + " " + Application.ProductVersion;
                lblProgramStatus.Text = Resources.programStatus1;
                FindEmuProcess();
                return;
            }

            FindBaseAddress();
            if (BaseAddress <= 0)
            {
                Text = Resources.programName + " " + Application.ProductVersion;
                lblProgramStatus.Text = Resources.programStatus2;
                foreach (Updatable upd in moduleList)
                {
                    upd.Update();
                }
                return;
            }

            //Reading level address (It's meant to be 0x32DDF8 but ENDIANESS:TM:)
            if (ReadUShort(BaseAddress + 0x32DDFA) < 3)
            {
                toolsMenuItem.Enabled = false;
                lblProgramStatus.Text = Resources.programStatusAwaitingLevel + "0x" + BaseAddress.ToString("X8");
                return;
            }
            
            //Are we running a moddded model ROM? (Working with Vanilla-styled vs. EXMO)
            modelStatus = ValidateModel();
            toolsMenuItem.Enabled = true;
            Text = Resources.programName + " " + Application.ProductVersion + " - " + modelStatus.ToString() + " ROM." + " - " + UpdateCounterEveryFrame.framenumber + " frames since startup."; 

            lblProgramStatus.Text = Resources.programStatus3 + "0x" + BaseAddress.ToString("X8");



            //==============================
            //Main program logic starts here
            //------------------------------
            updateTimer.Interval = 100;

            //Don't overwrite the camera state if we're in non-bugged first-person
            byte[] cameraState = SwapEndian(ReadBytes(BaseAddress + 0x33C848, 4), 4);
            lblCameraCode.Text = "0x" + BitConverter.ToString(cameraState).Replace("-", "");

            if (cameraFrozen && (cameraState[0] == 0xA2 || cameraState[0] < 0x80))
            {
                byte[] data = { 0x80 };
                WriteBytes(BaseAddress + 0x33C84B, data);
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


        void FreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            cameraFrozen = true;
            byte[] data = { 0x80 };
            WriteBytes(BaseAddress + 0x33C84B, data);
            lblCameraStatus.Text = Resources.cameraStateFrozen;
        }

        void UnfreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            cameraFrozen = false;
            byte[] data = { 0x00 };
            WriteBytes(BaseAddress + 0x33C84B, data);

            lblCameraStatus.Text = cameraSoftFrozen ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault;
        }

        void SoftFreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            cameraSoftFrozen = true;
            WriteUInt(BaseAddress + 0x33B204, 0x8001C520);

            lblCameraStatus.Text = cameraFrozen ? Resources.cameraStateFrozen : Resources.cameraStateSoftFrozen;
        }

        void SoftUnfreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            cameraSoftFrozen = false;
            WriteUInt(BaseAddress + 0x33B204, 0x8033C520);

            lblCameraStatus.Text = cameraFrozen ? Resources.cameraStateFrozen : Resources.cameraStateDefault;
        }

        void changeCameraStyle(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            byte[] data = { camStyles[cbCamStyles.SelectedIndex].Value };

            WriteBytes(BaseAddress + 0x33C6D6, data);
            WriteBytes(BaseAddress + 0x33C6D7, data);
        }


        void WriteAnimSwap(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            if (selectedAnimOld.Value == "" || selectedAnimNew.Value == "")
            {
                MessageBox.Show(this, String.Format(Resources.invalidAnimSelected, ((Control) sender).Name));
                return;
            }

            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimNew.Value), 4);
            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
        }

        void WriteAnimReset(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            if (selectedAnimOld.Value == "" || selectedAnimNew.Value == "")
            {
                MessageBox.Show(this, String.Format(Resources.invalidAnimSelected, ((Control)sender).Name));
                return;
            }

            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimOld.Value), 4);
            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;

            WriteBytes(address, stuffToWrite);
            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void WriteAnimResetAll(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            foreach (Animation anim in animList)
            {
                byte[] stuffToWrite = SwapEndian(StringToByteArray(anim.Value), 4);
                long address = BaseAddress + 0x64040 + (anim.RealIndex + 1) * 8;

                WriteBytes(address, stuffToWrite);
            }

            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void cbAnimOld_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;
            byte[] currentAnim = SwapEndian(ReadBytes(address, 8), 4);
            string currentAnimValue = BitConverter.ToString(currentAnim).Replace("-", "");

            for (int i = 0; i < animList.Count; i++)
            {
                if (animList[i].Value == currentAnimValue)
                    cbAnimNew.SelectedIndex = i;
            }
        }


        void openAppearanceSettings(object sender, EventArgs e)
        {

            switch (modelStatus)
            {
                case ModelStatus.EMPTY:
                    MessageBox.Show(Resources.colorCodeEmptyRom, "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case ModelStatus.MODDED:
                    MessageBox.Show(Resources.colorCodeModdedRom, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ModelStatus.VANILLA:
                    if (appearanceForm == null || appearanceForm.IsDisposed) appearanceForm = new AppearanceForm();

                    if (!appearanceForm.Visible)
                        appearanceForm.Show();

                    if (appearanceForm.WindowState == FormWindowState.Minimized)
                        appearanceForm.WindowState = FormWindowState.Normal;
                    break;
            }
            
        }

        void openAboutForm(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        void openExtraControls(object sender, EventArgs e)
        {
            if (extraControlsForm == null || extraControlsForm.IsDisposed) extraControlsForm = new ExtraControlsForm();

            if (!extraControlsForm.Visible)
                extraControlsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAnimRestart_Click(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            if (selectedAnimOld.Value == "" || selectedAnimNew.Value == "")
            {
                MessageBox.Show(this, String.Format(Resources.invalidAnimSelected, ((Control)sender).Name));
                return;
            }
            byte[] stuffToWrite = SwapEndian(StringToByteArray(selectedAnimNew.Value), 4);
            byte[] initialAnimation = SwapEndian(StringToByteArray(defaultAnimation.Value), 4);
            long address = BaseAddress + 0x64040 + (selectedAnimOld.RealIndex + 1) * 8;
            WriteUInt(BaseAddress + 0x33B198, 255);
            while ((BitConverter.ToUInt16(SwapEndian(ReadBytes(BaseAddress + 0x33B198, 2), 4), 0) < 255) == false)
            {
                WriteBytes(address, initialAnimation);
                //Stall, for literally just one in-game frame.
            }
            WriteBytes(address, stuffToWrite);
            
        }
    }


    struct Animation
    {
        public string Value;
        public int RealIndex;
    }

    struct CamStyle
    {
        public byte Value;
        public string Name;
    }
}
