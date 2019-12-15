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
using M64MM2.Properties;

namespace M64MM2
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            lnkDiscord.Text = ("Discord: " + Resources.discordInvite);
            lblWhosInBanner.Text = Resources.picturedInBannerMsg + Resources.picturedInBannerPeople;
            lblVersion.Text = ("Version: " + Application.ProductVersion + Resources.prereleaseString);
        }

        private void lnkDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Resources.discordInvite);
        }

        private void lnkGithubIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://github.com/projectcomet64/M64MM/issues");
        }

        // 2e 54 54 20 2c 62 76 66 20 7a 7a 70 74 20 50
        /*        
                ,---,. 
              ,'  .' | 
            ,---.'   | 
            |   |   .' 
            :   :  :   
            :   |  |-, 
            |   :  ;/| 
            |   |   .' 
            '   :  '   
            |   |  |   
            |   :  \   
            |   | ,'   
            `----'     
                       
        */

    }
}
