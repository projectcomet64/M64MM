using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keyshift.Forms.Controls;
using M64MM.Utils;
using M64MM.Utils.TimelineTools;

namespace M64MM2
{
    public partial class TimelinesForm : Form
    {
        private List<TimelineRenderer> tlR = new List<TimelineRenderer>();
        public TimelinesForm()
        {
            InitializeComponent();
            Core.TimelineCollection.TimelineAdded += AddTimelineRenderer;
        }

        private void AddTimelineRenderer(object sender, KeyValuePair<string, TimelineInfo> kp) {
            TabPage newTp = new TabPage(kp.Value.Name);
            TimelineRenderer newTlR = new TimelineRenderer(kp.Value.Timeline);
            newTp.Controls.Add(newTlR);
            tcTimelines.TabPages.Add(newTp);
            newTlR.Dock = DockStyle.Fill;
            tlR.Add(newTlR);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void TimelinesForm_Load(object sender, EventArgs e)
        {
            foreach (var kp in Core.TimelineCollection.Timelines)
            {
                AddTimelineRenderer(null, kp);
            }
        }

        private void btnAllPlay_Click(object sender, EventArgs e)
        {
            foreach (var kp in Core.TimelineCollection.Timelines)
            {
                kp.Value.Timeline.Playing = true;
            }
        }

        private void btnAllStop_Click(object sender, EventArgs e)
        {
            foreach (var kp in Core.TimelineCollection.Timelines)
            {
                kp.Value.Timeline.Playing = false;
            }
        }
    }
}
