using M64MM.Additions;
using System;
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
            await Task.Run(() => { UpdateProgress(0, "OK, imagine I'm checking for updates\n"); });
            await Task.Run(() => { Thread.Sleep(2000); });
            rtbLogs.AppendText("Loading addons...\n");
            await Task.Run(() => { LoadAddonsFromFolder(); });
            await Task.Run(() =>
            {
                UpdateProgress(25, "Loading animation data...\n");
            });
            bool validAnimData = await Task.Run(() => LoadAnimationData());
            await Task.Run(() =>
            {
                UpdateProgress(25, "Loading camera data...\n");
            });
            bool validCamStyles = await Task.Run(() => LoadCameraData());
            await Task.Run(() =>
            {
                UpdateProgress(25, "Initializing addons...\n");
            });
            await Task.Run(() => { InitializeModules(); });
            await Task.Run(() =>
            {
                UpdateProgress(25, null);
            });
            Program.validAnimationData = validAnimData;
            Program.validCameraData = validCamStyles;
            Close();
        }

        void UpdateProgress(int add, string progressText)
        {
            if (splashForm.IsHandleCreated)
            {
                splashForm.BeginInvoke(new MethodInvoker(delegate ()
                                {
                                    pbProgress.Value += add;
                                    if (!String.IsNullOrEmpty(progressText))
                                    {
                                        rtbLogs.AppendText(progressText);
                                    }
                                }));
            }
            else
            {
                // Huh?
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
