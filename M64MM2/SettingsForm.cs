using M64MM.Utils;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            if (camStyles.Count > 0)
            {
                foreach (CameraStyle style in camStyles)
                {
                    cbCamStyles.Items.Add(style);
                }
                cbCamStyles.DisplayMember = "Name";
                cbCamStyles.Refresh();
                byte preferredVal = coreSettingsGroup.EnsureSettingValue<byte>("preferredDefaultCamStyle");
                cbCamStyles.SelectedIndex = camStyles.FindIndex(x => x.Value == preferredVal);
            }
            else
            {
                cbCamStyles.Items.Add(new CameraStyle { Name = "- X -", Value = 0x01 });
                cbCamStyles.Enabled = false;
            }
            cbEnableHotkeys.Checked = coreSettingsGroup.EnsureSettingValue<bool>("enableHotkeys");
            cbEnablePowercamStartup.Checked = coreSettingsGroup.EnsureSettingValue<bool>("enableStartupPowercam");
            cbCheckUpdates.Checked = coreSettingsGroup.EnsureSettingValue<bool>("enableUpdateCheck");
            cbTurbo.Checked = coreSettingsGroup.EnsureSettingValue<bool>("turboTicks");
            cbRelBeta.Checked = Core.preferredReleases.Contains("beta");
            cbRelAlpha.Checked = Core.preferredReleases.Contains("alpha");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            coreSettingsGroup.SetSettingValue("enableHotkeys", cbEnableHotkeys.Checked);
            coreSettingsGroup.SetSettingValue("enableUpdateCheck", cbCheckUpdates.Checked);
            coreSettingsGroup.SetSettingValue("enableStartupPowercam", cbEnablePowercamStartup.Checked);
            coreSettingsGroup.SetSettingValue("preferredDefaultCamStyle", ((CameraStyle)cbCamStyles.SelectedItem).Value);
            coreSettingsGroup.SetSettingValue("turboTicks", cbTurbo.Checked);
            
            // the following is very ugly
            List<string> releaseCycles = new List<string>();
            releaseCycles.Add("release");
            if (cbRelBeta.Checked) {
                releaseCycles.Add("beta");
            }
            if (cbRelAlpha.Checked) {
                releaseCycles.Add("alpha");
            }
            coreSettingsGroup.SetSettingValue<string[]>("preferredReleases", releaseCycles.ToArray());
            SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
