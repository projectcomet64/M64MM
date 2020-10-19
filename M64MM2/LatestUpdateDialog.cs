using M64MM.Utils;
using M64MM2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM.Utils.MarkdownRegex;

namespace M64MM2
{
    public partial class LatestUpdateDialog : Form
    {
        GitHubRelease release;
        bool updateAvailable;
        public LatestUpdateDialog(GitHubRelease rel)
        {
            InitializeComponent();
            release = rel;
            updateAvailable = Updater.CheckVersion(rel.VersionTag, Program.CurrentVersionTag);
        }

        private void LatestUpdateDialog_Load(object sender, EventArgs e)
        {
            lbLatestVersion.Text = $"{Resources.updateLatestVersion}{release.TagName} ({release.ReleaseName})";
            lbCurrentVersion.Text = $"{Resources.updateCurrentVersion}{Program.CurrentVersionTag.ToString()} {(updateAvailable ? Resources.updateUpdateNow: Resources.updateUpToDate)}";
            string rtf = MarkdownToRtf(release.Body);
            rtbUpdateNotes.Rtf = @"{\rtf\ansi\deff0{\fonttbl{\f0\fnil Arial;}{\f1\fmodern Courier New;}}\fs18" + rtf;
        }

        private void btnOpenRel_Click(object sender, EventArgs e)
        {
            Process.Start(release.ReleaseLink);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
