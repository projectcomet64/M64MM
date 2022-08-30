using M64MM.Additions;
using M64MM.Utils;
using M64MM2.Properties;
using System;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.Core;

namespace M64MM2
{
    public partial class SplashForm : Form
    {

        SplashForm splashForm;
        int extraHoldTime = 0;
        string extraAddonPath = "";
        Image[] splashAssortment = new Image[]
        {
            Resources.m64mm_hero,
            Resources.superg_m64mmsplash,
            Resources.webb_m64mmsplash
        };
        Random rand = new Random(DateTime.Now.Millisecond);
        public SplashForm(int holdTime = 0, string moreAddonPath = "")
        {
            InitSettings();
            InitializeComponent();
            if (splashForm == null)
            {
                splashForm = this;
            }
            Load += new EventHandler(OnLoad);
            BackgroundImage = splashAssortment[rand.Next(0, 3)];
            extraHoldTime = holdTime;
            extraAddonPath = moreAddonPath;
            #if DEBUG
            BackgroundImage = Resources.m64mm_hero_devprev;
            #endif
        }

        void OnLoad(object sender, EventArgs args)
        {
            InitMovieMaker();
        }

        public async void InitMovieMaker()
        {
            await Task.Run(() => { UpdateProgress(0, "Checking for updates...\n"); });
            await Task.Run(async () =>
            {
                try
                {
                    if (enableUpdates)
                    {
                        UpdateProgress(10, "Let's go.\n");
                    }
                    else
                    {
                        UpdateProgress(10, "Update checking is disabled. Go to Options -> Settings to enable it.\n");
                        await Task.Delay(1000);
                    }
                }
                catch (Exception)
                {

                    UpdateProgress(10, "Could not check for updates. Check your Internet connection.\n");
                    await Task.Delay(1000);
                }
            });
            rtbLogs.AppendText("Loading addons...\n");
            await Task.Run(() => { LoadAddonsFromFolder(); });
            if (!string.IsNullOrEmpty(extraAddonPath))
            {
                rtbLogs.AppendText("Loading addons from defined folder..\n");
                await Task.Run(() => { LoadAddonsFromFolder(extraAddonPath); });
            }
            if (extraHoldTime > 0)
            {
                rtbLogs.AppendText($"Got it, boss. Waiting {extraHoldTime/1000} seconds before proceeding.\n");
                await Task.Delay(extraHoldTime);
            }
            await Task.Run(() =>
            {
                UpdateProgress(25, "Loading animation data...\n");
            });
            bool validAnimData = await Task.Run(LoadAnimationData);
            await Task.Run(() =>
            {
                UpdateProgress(50, "Loading camera data...\n");
            });
            await Task.Run(LoadColorCodeRepo);
            await Task.Run(() =>
            {
                UpdateProgress(65, "Loading colorcodes...\n");
            });
            bool validCamStyles = await Task.Run(LoadCameraData);
            await Task.Run(() =>
            {
                UpdateProgress(75, "Initializing addons...\n");
            });
            await Task.Run(InitializeModules);
            await Task.Run(() =>
            {
                UpdateProgress(100, null);
            });
            Program.validAnimationData = validAnimData;
            Program.validCameraData = validCamStyles;
            Close();
        }

        void UpdateProgress(int val, string progressText)
        {
            if (splashForm.IsHandleCreated)
            {
                splashForm.BeginInvoke(new MethodInvoker(delegate ()
                                {
                                    pbProgress.Value = val;
                                    if (!string.IsNullOrEmpty(progressText))
                                    {
                                        rtbLogs.AppendText(progressText);
                                    }
                                }));
            }
        }

        void InitializeModules()
        {
            foreach (Addon mod in moduleList)
            {
                mod.Module.Initialize();
            }
        }

        private void SplashForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (e.CloseReason == CloseReason.FormOwnerClosing ||
                e.CloseReason == CloseReason.WindowsShutDown ||
                e.CloseReason == CloseReason.TaskManagerClosing) {
                Application.Exit();
            }
        }
    }
}
