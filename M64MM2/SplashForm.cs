using M64MM.Additions;
using M64MM.Utils;
using M64MM2.Properties;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.Core;

namespace M64MM2
{
    public partial class SplashForm : Form
    {

        SplashForm splashForm;

        public SplashForm()
        {
            InitSettings();
            InitializeComponent();
            if (splashForm == null)
            {
                splashForm = this;
            }
            Load += new EventHandler(OnLoad);
        }

        void OnLoad(object sender, EventArgs args)
        {
            InitMovieMaker();
        }

        public async void InitMovieMaker()
        {
            await Task.Run(() => { UpdateProgress(0, "Checking for updates...\n"); });
            await Task.Run(() =>
            {
                try
                {
                    if (enableUpdates)
                    {
                        CheckUpdates();
                        UpdateProgress(10, "Let's go.\n");
                    }
                    else
                    {
                        UpdateProgress(10, "Update checking is disabled. Go to Options -> Settings to enable it.");
                        Task.Delay(500);
                    }
                }
                catch (Exception)
                {

                    UpdateProgress(10, "Could not check for updates. Check your Internet connection.");
                    Task.Delay(1000);
                }
            });
            rtbLogs.AppendText("Loading addons...\n");
            await Task.Run(() => { LoadAddonsFromFolder(); });
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

        async void CheckUpdates()
        {
            Tuple<HttpStatusCode, GitHubRelease> requestLatest = new Tuple<HttpStatusCode, GitHubRelease>(0, null);
            requestLatest = await Updater.CheckUpdate();
            if (requestLatest.Item1 == HttpStatusCode.OK)
            {
                Program.LatestRelease = requestLatest.Item2;
                VersionTagManager.VersionTag latest = VersionTagManager.GetVersionFromTag(requestLatest.Item2.TagName);
                VersionTagManager.VersionTag current = VersionTagManager.GetVersionFromTag(Application.ProductVersion + Resources.prereleaseString);
                Program.UpdateAvailable = Updater.GotNewVersion(latest, current);
            }
        }

        void UpdateProgress(int val, string progressText)
        {
            // TODO: Rather than relying on percentages, make it by "Tasks Completed"
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
    }
}
