using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using M64MM2.Properties;
using static M64MM.Utils.Core;
using M64MM.Utils;
using M64MM.Additions;
using static M64MM.Utils.SettingsManager;
using System.Linq;
using System.Net;

namespace M64MM2
{
    public partial class MainForm : Form
    {
        AppearanceForm appearanceForm;
        ExtraControlsForm extraControlsForm;
        SettingsForm settingsForm;
        LatestUpdateDialog ludForm;


        //This handles the "Each ingame frame"
        //ASYNCHRONOUS FOR THE WIN
        //FUNNILY ENOUGH! This takes little to no CPU, actually
        //It's goddamn amazing
        Task updateFunction = Task.Run(() => performUpdate());

        public MainForm()
        {
            InitializeComponent();
            ToolStripMenuItem addons = new ToolStripMenuItem("Addons");
            foreach (Addon add in moduleList)
            {
                List<ToolCommand> toolCommands = GetAddonCommands(add);

                // Add them to the Plugins toolstrip
                foreach (ToolCommand tc in toolCommands)
                {
                    ToolStripMenuItem mod_ = new ToolStripMenuItem(tc.name);
                    mod_.Click += (a, b) => tc.Summon(a, b);
                    addons.DropDownItems.Add(mod_);
                }
            }
            programTimer.Tick += (a, b) => Update(this, null);
            menuStrip.Items.Add(addons);

            if (AddonErrorsBuilder.Length > 0)
            {
                // If there were any errors (String, may make a collection of objects?)
                // Do make a Log struct later on for more than a warning use
                addons.DropDownItems.Add(new ToolStripSeparator());
                addons.DropDownItems.Add(new ToolStripMenuItem("Addon warnings", null, (a, b) => { new AddonErrors().ShowDialog(); }));
            }

            Text = Resources.programName + " " + Application.ProductVersion;
            programTimer.Interval = 1000;
            programTimer.Start();
            defaultAnimation.Value = "0";
            lblCameraStatus.Text = Resources.cameraStateDefault;
            toolsMenuItem.Enabled = false;

            //Load animation data

            if (!Program.validAnimationData)
            {
                MessageBox.Show(Resources.animDataNotLoaded);
                cbAnimOld.Text = cbAnimNew.Text = Resources.animDataNotLoaded;
                cbAnimOld.Enabled = false;
                cbAnimNew.Enabled = false;
                btnAnimSwap.Enabled = false;
                btnAnimReset.Enabled = false;
                btnAnimResetAll.Enabled = false;
                btnAnimReset.Enabled = false;
                chbAutoApply.Enabled = false;
            }
            else
            {
                cbAnimNew.Items.AddRange(GetAnimationNames());
                cbAnimOld.Items.AddRange(GetAnimationNames());
                cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex = 0;
            }

            //Load camera style data
            if (!Program.validCameraData)
            {
                MessageBox.Show(Resources.cameraDataNotLoaded);
                cbCamStyles.Text = Resources.cameraDataNotLoaded;
                cbCamStyles.Enabled = false;
                btnChangeCamStyle.Enabled = false;
            }
            else
            {
                if (camStyles.Count > 0)
                {
                    foreach (CameraStyle style in camStyles)
                    {
                        cbCamStyles.Items.Add(style.Name);
                    }
                    cbCamStyles.SelectedIndex = 0;
                    cbCamStyles.Refresh();
                }
                else
                {
                    cbCamStyles.Text = "NONE";
                    cbCamStyles.Enabled = false;
                }
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
                if (BaseAddress > 0)
                {
                    Task.Run(() => performBaseAddrUpd());
                    BaseAddress = 0;
                }
                modelStatus = ModelStatus.NONE;
                return;
            }

            FindBaseAddress();
            //Finding base address
            if (BaseAddress <= 0)
            {
                Text = Resources.programName + " " + Application.ProductVersion;
                lblProgramStatus.Text = Resources.programStatus2;
                modelStatus = ModelStatus.NONE;
                return;
            }

            //Reading level address (It's meant to be 0x32DDF8 but ENDIANESS:TM:)
            if (CurrentLevelID < 3)
            {
                toolsMenuItem.Enabled = false;
                lblProgramStatus.Text = Resources.programStatusAwaitingLevel + "0x" + BaseAddress.ToString("X8");
                modelStatus = ModelStatus.NONE;
                return;
            }

            //Are we running a moddded model ROM? (Working with Vanilla-styled vs. COMET / [redacted])
            modelStatus = ValidateModel();
            toolsMenuItem.Enabled = true;
            Text = Resources.programName + " " + Application.ProductVersion + " - " + modelStatus.ToString() + " ROM.";

            lblProgramStatus.Text = Resources.programStatus3 + "0x" + BaseAddress.ToString("X8");



            //==============================
            //Main program logic starts here
            //------------------------------


            // When the game is transitioning, the game freezes: we can no longer just trust the
            // in-game timer in that case
            UpdateCoreEntityAddress();

            
            lblCameraCode.Text = "0x" + BitConverter.ToString(CameraState).Replace("-", "");

            // Animation index is -1 when the game is transitioning which is just about perfect
            // Only override camera reset (flag 0x08) when the game is transitioning
            // Works before entering Castle Grounds and literally any level transition
            if (cbPowercam.Checked && AnimationIndex == -1)
            {
                // Glitchy: AVOID CAMERA FROM RESETTING (Flag 0x08)
                WriteBytes(BaseAddress + 0x33C84B, new byte[] { (byte)(CameraState[0] & ~(0x8)) });
            }

            //Don't overwrite the camera state if we're in non-bugged first-person
            if (CameraFrozen && ((CameraState[0] & 0x20) == 0x20))
            {
                // Glitchy: Camera status is actually a flag, which means we just need to take away
                // the first person flag to restore, so it doesn't do a false alarm on newly
                // loaded emulator instances (freezing camera Wayyyyyyyy up in the sky)
                byte[] data = { (byte)(CameraState[0] & ~(0x20)) };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }
            else if (CameraFrozen && ((CameraState[0] & 0x80) != 0x20))
            {
                // Glitchy: Program says camera is frozen but game says otherwise
                // OK, in that case let's just enable the flag back
                byte[] data = { (byte)(CameraState[0] | 0x80) };
                WriteBytes(BaseAddress + 0x33C84B, data);
            }


            //Handle hotkey input based on setting
            if (enableHotkeys)
            {
                if (GetKey(Keys.LControlKey) || GetKey(Keys.RControlKey))
                {
                    if (GetKey(Keys.D1))
                        ToggleFreezeCam(null, null);

                    if (GetKey(Keys.D2))
                        ToggleSoftFreezeCam(null, null);
                }
            }
        }


        void ToggleFreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            ToggleCameraFreeze();
            btnFreeze.Text = $"Frozen: {CameraFrozen}";
            lblCameraStatus.Text = (CameraFrozen) ? Resources.cameraStateFrozen : ((CameraSoftFrozen) ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault);
        }

        void UnfreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;
            // TODO: delete.
            // Dropped in favor of a toggling button


            //lblCameraStatus.Text = cameraSoftFrozen ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault;
        }

        void ToggleSoftFreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            ToggleCameraSoftFreeze();
            btnSoftFreeze.Text = $"Soft Frozen: {CameraSoftFrozen}";

            lblCameraStatus.Text = (CameraFrozen) ? Resources.cameraStateFrozen : ((CameraSoftFrozen) ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault);
        }

        void SoftUnfreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            // TODO: delete.
            // Dropped in favor of a toggling button
            //lblCameraStatus.Text = cameraFrozen ? Resources.cameraStateFrozen : Resources.cameraStateDefault;
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
            Animation oldAnim = animList[cbAnimOld.SelectedIndex];
            Animation newAnim = animList[cbAnimNew.SelectedIndex];
            WriteAnimationSwap(oldAnim, newAnim);

        }

        void WriteAnimReset(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            Animation selectedAnimation = animList[((ComboBox)sender).SelectedIndex];
            WriteAnimationReset(selectedAnimation);
            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void WriteAnimResetAll(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            foreach (Animation anim in animList)
            {
                WriteAnimationReset(anim);
            }

            cbAnimNew.SelectedIndex = cbAnimOld.SelectedIndex;
        }

        void cbAnimOld_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;
            Animation selectedAnimation = animList[((ComboBox)sender).SelectedIndex];
            cbAnimNew.SelectedIndex = GetCurrentAnimationIndex(selectedAnimation);
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
                case ModelStatus.COMET:
                    MessageBox.Show(Resources.colorCodeCometRom, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Program.UpdateAvailable)
            {
                ludForm = new LatestUpdateDialog(Program.LatestRelease);
                ludForm.ShowDialog(this);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            foreach (Addon mod in moduleList)
            {
                mod.Module.Close(e);
            }
            base.OnClosed(e);
        }

        private void showRunningPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskman tman = new Taskman(ref moduleList);
            tman.Show();
        }

        private void cbAnimNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbAutoApply.Checked)
            {
                WriteAnimSwap(sender, e);
            }
        }

        private void cbAnimOld_TextChanged(object sender, EventArgs e)
        {
            // Hold up.
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm();
            }
            settingsForm.ShowDialog();
        }

        private async void checkForLatestUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Make neater, remove repetition
            // MOVE TO CORE
            Tuple<HttpStatusCode, GitHubRelease> requestLatest = new Tuple<HttpStatusCode, GitHubRelease>(0, null);
            requestLatest = await Updater.CheckUpdate();
            if (requestLatest.Item1 == HttpStatusCode.OK)
            {
                Program.LatestRelease = requestLatest.Item2;
                VersionTagManager.VersionTag latest = VersionTagManager.GetVersionFromTag(requestLatest.Item2.TagName);
                VersionTagManager.VersionTag current = VersionTagManager.GetVersionFromTag(Application.ProductVersion + Resources.prereleaseString);
                Program.UpdateAvailable = Updater.GotNewVersion(latest, current);
            }
            LatestUpdateDialog ludForm = new LatestUpdateDialog(Program.LatestRelease);
            ludForm.Show();
        }
    }
}
