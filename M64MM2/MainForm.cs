using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using M64MM2.Properties;
using static M64MM.Utils.Core;
using static M64MM.Utils.Looks;
using M64MM.Utils;
using M64MM.Additions;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Win32;

namespace M64MM2
{
    public partial class MainForm : Form
    {
        AppearanceForm appearanceForm;
        ExtraControlsForm extraControlsForm;
        SettingsForm settingsForm;
        LatestUpdateDialog ludForm;
        ToolTip hint = new ToolTip();

        private ListBox _lbAnimsNew = new ListBox();
        private ListBox _lbAnimsOld = new ListBox();

        Keys _heldKeys = Keys.None;


        //This handles the "Each ingame frame"
        //ASYNCHRONOUS FOR THE WIN
        //FUNNILY ENOUGH! This takes little to no CPU, actually
        //It's goddamn amazing
        Task updateFunction = Task.Run(() => PerformUpdate());

        private bool _lastProcessWasInaccessible;

        public MainForm()
        {
            InitializeComponent();
            hint.IsBalloon = true;

            // Start Binding Setup (why do i have to do this for just a proper autocomplete god

            _lbAnimsOld.DisplayMember = "Description";
            _lbAnimsNew.DisplayMember = "Description";

            _lbAnimsOld.Click += (sender, e) =>
            {
                SelectAnimationInCombobox(cbAnimOld, (Animation)_lbAnimsOld.SelectedItem);
                cbAnimOld.HideDropDown();
            };

            _lbAnimsNew.Click += (sender, e) =>
            {
                SelectAnimationInCombobox(cbAnimNew, (Animation)_lbAnimsNew.SelectedItem);
                cbAnimNew.HideDropDown();
            };

            _lbAnimsOld.PreviewKeyDown += (sender, e) =>
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (_lbAnimsOld.SelectedItem == null) return;
                    SelectAnimationInCombobox(cbAnimOld, (Animation)_lbAnimsOld.SelectedItem);
                    cbAnimOld.HideDropDown();
                }
            };

            _lbAnimsNew.PreviewKeyDown += (sender, e) =>
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (_lbAnimsNew.SelectedItem == null) return;
                    SelectAnimationInCombobox(cbAnimNew, (Animation)_lbAnimsNew.SelectedItem);
                    cbAnimNew.HideDropDown();
                }
            };

            cbAnimNew.DropDownControl = _lbAnimsNew;
            cbAnimOld.DropDownControl = _lbAnimsOld;

            // End Binding Setup

            Core.EmulatorSelected += EmulatorSelected;
            MoreThanOneEmuFound += MoreThanOneEmu;
            EmulatorInaccessible += InaccessibleEmu;
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

            Text = Resources.programName + " " + Application.ProductVersion + Resources.prereleaseString;
            programTimer.Interval = 1000;
            programTimer.Start();
            defaultAnimation.Value = "0";
            lblCameraStatus.Text = Resources.cameraStateDefault;

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
                        cbCamStyles.Items.Add(style);
                    }
                    cbCamStyles.SelectedIndex = camStyles.FindIndex(x => x.Value == preferredCameraStyle);
                    cbCamStyles.DisplayMember = "Name";
                    cbCamStyles.Refresh();
                }
                else
                {
                    cbCamStyles.Text = "NONE";
                    cbCamStyles.Enabled = false;
                }
            }

            cbPowercam.Checked = prePowercam;
        }

        void Update(object sender, EventArgs e)
        {
            //Early validity checks
            if (!IsEmuOpen && !StopProcessSearch)
            {
                StopProcessSearch = true;
                Text = Resources.programName + " " + Application.ProductVersion + Resources.prereleaseString;
                if (_lastProcessWasInaccessible)
                {
                    lblProgramStatus.Text = Resources.programStatusInaccessible;
                }
                else
                {
                    lblProgramStatus.Text = Resources.programStatus1;
                }
                FindEmuProcess();
                PowerCamStyleStage = PowerCameraStyleStage.UNSET;
                return;
            }

            if (StopProcessSearch)
                return;

            FindBaseAddress();
            //Finding base address
            if (BaseAddress <= 0)
            {
                _lastProcessWasInaccessible = false;
                Text = Resources.programName + " " + Application.ProductVersion + Resources.prereleaseString;
                lblProgramStatus.Text = Resources.programStatus2;
                return;
            }

            //Reading level address (It's meant to be 0x32DDF8 but ENDIANESS:TM:)
            if (CurrentLevelID < 3)
            {
                lblProgramStatus.Text = Resources.programStatusAwaitingLevel + "0x" + BaseAddress.ToString("X8");
                if (Core.CameraStyle[0] == 0x00 && PowerCamStyleStage == PowerCameraStyleStage.UNSET)
                {
                    PowerCamStyleStage = PowerCameraStyleStage.CLEAN;
                }
                return;
            }

            //Are we running a moddded model ROM? (Working with Vanilla-styled vs. COMET / [redacted])
            modelStatus = AnalyzeHeader();
            Text = Resources.programName + " " + Application.ProductVersion + Resources.prereleaseString + " - " + modelStatus.ToString() + " ROM.";

            lblProgramStatus.Text = Resources.programStatus3 + "0x" + BaseAddress.ToString("X8");



            //==============================
            //Main program logic starts here
            //------------------------------


            // When the game is transitioning, the game freezes: we can no longer just trust the
            // in-game timer in that case
            UpdateCoreEntityAddress();

            if (CoreEntityAddress > 0 &&
                Core.CameraStyle[0] != 0x00 &&
                PowerCamStyleStage == PowerCameraStyleStage.UNSET)
            {
                PowerCamStyleStage = PowerCameraStyleStage.DIRTY;
                if (CoreEntityAddress > 0 &&
                WillLevelZoomOut(CurrentLevelID) &&
                cbPowercam.Checked)
                {
                    ShowPowercamTooltip(false);
                    cbPowercam.Checked = false;
                }

            }


            lblCameraCode.Text = "0x" + BitConverter.ToString(CameraState).Replace("-", "");
            lblCameraStyle.Text = "0x" + BitConverter.ToString(Core.CameraStyle).Replace("-", "");

            // Execute camera fixes (bugged first person hack) and Powercam
            PowercamHack();

            //Handle hotkey input based on setting
            if (enableHotkeys)
            {
                if (!GetKey(Keys.D1))
                {
                    _heldKeys &= ~Keys.D1;
                }

                if (!GetKey(Keys.D2))
                {
                    _heldKeys &= ~Keys.D2;
                }
                if (GetKey(Keys.LControlKey) || GetKey(Keys.RControlKey))
                {

                    // Keeps record of held keys and only executes if they're not
                    // held at the moment
                    // Debating whether I should just use WinAPI's messages
                    // or keep this implementation.

                    // Implementing WinAPI's messages is painful
                    // but if this kills performance I'll have to look
                    // deeper into it (ugh)

                    if (GetKey(Keys.D1) && ((_heldKeys & Keys.D1) == Keys.None))
                    {
                        _heldKeys ^= Keys.D1;
                        ToggleFreezeCam(null, null);
                    }


                    if (GetKey(Keys.D2) && ((_heldKeys & Keys.D2) == Keys.None))
                    {
                        _heldKeys ^= Keys.D2;
                        ToggleSoftFreezeCam(null, null);
                    }

                }
            }
        }

        void MoreThanOneEmu(object sender, EmuFoundEventArgs proc)
        {
            Process[] n_plist = proc.ProcessList.Where(x => !string.IsNullOrEmpty(x.MainWindowTitle)).ToArray();
            EmuSelectorForm es = new EmuSelectorForm(n_plist);
            if (n_plist.Length > 1)
            {
                es.ShowDialog();
            }
            else
            {
                StopProcessSearch = false;
            }

        }

        void InaccessibleEmu(object sender, EventArgs e)
        {
            if (_lastProcessWasInaccessible) return;
            MessageBox.Show(Resources.inaccessibleEmuMsg, ":/", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _lastProcessWasInaccessible = true;
        }

        void EmulatorSelected(object sender, EventArgs e)
        {
            if (BaseAddress > 0)
            {
                Task.Run(() => PerformBaseAddrUpd());
                BaseAddress = 0;
            }
            modelStatus = AnalyzeHeader();
        }

        void ToggleFreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            ToggleCameraFreeze();
            btnFreeze.Text = $"{Resources.cameraToggleFrozen}{(CameraFrozen ? Resources.yes : Resources.no)}";
            lblCameraStatus.Text = (CameraFrozen) ? Resources.cameraStateFrozen : ((CameraSoftFrozen) ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault);
        }

        void ToggleSoftFreezeCam(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            ToggleCameraSoftFreeze();
            btnSoftFreeze.Text = $"{Resources.cameraToggleSoftFrozen}{(CameraSoftFrozen ? Resources.yes : Resources.no)}";

            lblCameraStatus.Text = (CameraFrozen) ? Resources.cameraStateFrozen : ((CameraSoftFrozen) ? Resources.cameraStateSoftFrozen : Resources.cameraStateDefault);
        }

        void ChangeCameraStyle(object sender, EventArgs e)
        {
            if (!IsEmuOpen || BaseAddress == 0) return;

            byte[] data = { camStyles[cbCamStyles.SelectedIndex].Value };

            WriteCameraData(data);
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

            Animation selectedAnimation = animList[cbAnimOld.SelectedIndex];
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

        void OpenAppearanceSettings(object sender, EventArgs e)
        {
            switch (modelStatus)
            {
                case ModelHeaderType.EMPTY:
                    MessageBox.Show(Resources.colorCodeEmptyRom, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case ModelHeaderType.MOD:
                    MessageBox.Show(Resources.colorCodeModdedRom, "...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case ModelHeaderType.UNSET:
                    return;
            }

            if (appearanceForm == null || appearanceForm.IsDisposed) appearanceForm = new AppearanceForm();

            if (!appearanceForm.Visible)
                appearanceForm.Show();

            if (appearanceForm.WindowState == FormWindowState.Minimized)
                appearanceForm.WindowState = FormWindowState.Normal;
        }

        void ShowPowercamTooltip(bool inlevel)
        {
            hint.Hide(this);
            BringToFront();
            if (inlevel)
            {
                hint.ToolTipTitle = Resources.powercamIngameDirtyTitle;
                hint.ToolTipIcon = ToolTipIcon.Info;
                hint.Show(string.Empty, cbPowercam, 8, 8);
                hint.Show(Resources.powercamIngameDirtyMsg, cbPowercam, 8, 8, 10000);
            }
            else
            {
                hint.ToolTipTitle = Resources.powercamPregameDirtyTitle;
                hint.ToolTipIcon = ToolTipIcon.Warning;
                hint.Show(string.Empty, cbPowercam, 8, 8);
                hint.Show(Resources.powercamPregameDirtyMsg, cbPowercam, 8, 8, 10000);
            }

        }

        void OpenAboutForm(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        void OpenExtraControls(object sender, EventArgs e)
        {
            if (extraControlsForm == null || extraControlsForm.IsDisposed) extraControlsForm = new ExtraControlsForm();

            if (!extraControlsForm.Visible)
                extraControlsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () =>
                {
                    Program.LatestRelease = await Updater.FindNewUpdate(Program.CurrentVersionTag, Core.preferredReleases);
                    Program.HasUpdate = Updater.CheckVersion(Program.LatestRelease.VersionTag, Program.CurrentVersionTag);
                });
            }
            catch (Exception exc)
            {
                Program.HasUpdate = false;
            }


            if (Program.HasUpdate)
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
            try
            {
                GitHubRelease latestRel = await Updater.FindNewUpdate(Program.CurrentVersionTag, preferredReleases);
                LatestUpdateDialog ludForm = new LatestUpdateDialog(latestRel);
                ludForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.updateNetworkError + $"\n {ex.Message}");
            }
        }

        private void cbPowercam_CheckedChanged(object sender, EventArgs e)
        {
            if (CoreEntityAddress > 0 &&
                WillLevelZoomOut(CurrentLevelID) &&
                ((CheckBox)sender).Checked)
            {
                ShowPowercamTooltip(true);
                ((CheckBox)sender).Checked = false;
                return;
            }

            PowerCamEnabled = cbPowercam.Checked;
        }

        private void scanForEmulatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetEmuProcess();
        }
        private void issuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/projectcomet64/M64MM/issues/new/choose");
        }

        private void cbAnimOld_DropDown(object sender, EventArgs e)
        {
            _lbAnimsOld.Items.Clear();
            _lbAnimsOld.Items.AddRange(GetQueriedAnimations(cbAnimOld.Text).Cast<object>().ToArray());
        }

        private void SelectAnimationInCombobox(ComboBox cb, Animation anim)
        {
            cb.SelectedIndex = animList.FindIndex(x => x == anim);
        }

        private void cbAnimOld_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                cbAnimOld.ShowDropDown();
            }
        }

        private void cbAnimNew_DropDown(object sender, EventArgs e)
        {
            _lbAnimsNew.Items.Clear();
            _lbAnimsNew.Items.AddRange(GetQueriedAnimations(cbAnimNew.Text).Cast<object>().ToArray());
        }

        private void cbAnimNew_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                cbAnimNew.ShowDropDown();
            }
        }

    }
}
