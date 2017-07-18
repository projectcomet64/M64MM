using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M64MM2.MemoryIO;

namespace M64MM2
{
    public partial class MainForm : Form
    {
        private bool changeCamera = false;
        private List<Animation> animList;
        private Dictionary<string, string> animData;
        private int animIndexOld
        {
            get
            {
                foreach (Animation anim in animList)
                {
                    if (anim.Value == cbAnimOld.SelectedText)
                        return anim.Index;
                }
                return 0;
            }
        }
        private int animIndexNew
        {
            get
            {
                foreach (Animation anim in animList)
                {
                    if (anim.Value == cbAnimNew.SelectedText)
                        return anim.Index;
                }
                return 0;
            }
        }


        public MainForm()
        {
            InitializeComponent();
            updateTimer.Start();
            animList = new List<Animation>();
            animData = new Dictionary<string, string>();

            try
            {
                using (StreamReader sr =  new StreamReader("animation_data.txt"))
                {
                    do
                    {
                        string rawLine = sr.ReadLine();
                        string step1 = rawLine.Trim();
                        string step2 = step1.TrimStart('0');
                        string step3 = step2.TrimStart('x');
                        string[] splitLine = step3.Split('|');
                        animData.Add(splitLine[0], splitLine[1]);
                        Animation anim;
                        anim.Value = splitLine[0];
                        anim.Description = splitLine[1];
                        anim.Index = int.Parse(splitLine[2]);
                        animList.Add(anim);
                    }
                    while (sr.Peek() >= 0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                cbAnimOld.Text = "Animation data not loaded!";
                cbAnimNew.Text = "Animation data not loaded!";
                cbAnimOld.Enabled = false;
                cbAnimNew.Enabled = false;
                btnAnimSwap.Enabled = false;
                btnAnimReset.Enabled = false;
                btnAnimResetAll.Enabled = false;
            }

            if (animData.Count > 0)
            {
                cbAnimOld.DataSource = new BindingSource(animData, null);
                cbAnimOld.DisplayMember = "Value";
                cbAnimOld.ValueMember = "Key";

                cbAnimNew.DataSource = new BindingSource(animData, null);
                cbAnimNew.DisplayMember = "Value";
                cbAnimNew.ValueMember = "Key";

                cbAnimOld.SelectedIndex = 0;
                cbAnimNew.SelectedIndex = 0;

                cbAnimOld.Refresh();
                cbAnimNew.Refresh();
            }
        }

        private void Update(object sender, EventArgs e)
        {
            //Early validity checks
            if (!IsEmuOpen)
            {
                lblProgramStatus.Text = "Status: Project64 is not open.";
                FindEmuProcess();
                return;
            }

            FindBaseAddress();
            if (BaseAddress <= 0)
            {
                lblProgramStatus.Text = "Status: Base address not found.";
                return;
            }

            lblProgramStatus.Text = "Status: Base address found at 0x" + BaseAddress.ToString("X");


            //Main program logic starts here
            if (changeCamera)
            {
                WriteUInt(BaseAddress + 0x33C848, 0x80000000);
            }
        }

        private void WriteAnimSwap(object sender, EventArgs e)
        {
            WriteULong(BaseAddress + 0x64040 + ((animIndexOld + 1) * 8), ulong.Parse(((KeyValuePair<string, string>)cbAnimNew.SelectedItem).Key, NumberStyles.HexNumber));
            //WriteUInt(BaseAddress + 0x64044 + ((animIndexOld + 1) * 8), uint.Parse(((string)cbAnimNew.SelectedValue).Substring(0, 8), NumberStyles.HexNumber));
        }

        private void WriteAnimReset(object sender, EventArgs e)
        {
            WriteULong(BaseAddress + 0x64040 + ((animIndexOld + 1) * 8), ulong.Parse(((KeyValuePair<string, string>)cbAnimOld.SelectedItem).Key, NumberStyles.HexNumber));
            //WriteUInt(BaseAddress + 0x64044 + ((animIndexOld + 1) * 8), uint.Parse(((string)cbAnimOld.SelectedValue).Substring(0, 8), NumberStyles.HexNumber));
        }

        private void WriteAnimResetAll(object sender, EventArgs e)
        {
            foreach (Animation anim in animList)
            {
                WriteULong(BaseAddress + 0x64040 + ((animIndexOld + 1) * 8), ulong.Parse(anim.Value, NumberStyles.HexNumber));
                //WriteUInt(BaseAddress + 0x64044 + ((anim.Index + 1) * 8), uint.Parse(anim.Value, NumberStyles.HexNumber));
            }
        }

        private void FreezeCam(object sender, EventArgs e)
        {
            changeCamera = true;
            WriteUInt(BaseAddress + 0x33C848, 0x80000000);
        }

        private void UnfreezeCam(object sender, EventArgs e)
        {
            changeCamera = false;
            WriteUInt(BaseAddress + 0x33C848, 0x00000000);
        }

        private void SoftFreezeCam(object sender, EventArgs e)
        {
            changeCamera = false;
            WriteUInt(BaseAddress + 0x33B204, 0x8001C520);
        }

        private void SoftUnfreezeCam(object sender, EventArgs e)
        {
            changeCamera = false;
            WriteUInt(BaseAddress + 0x33B204, 0x8033C520);
        }
    }

    struct Animation
    {
        public string Value;
        public string Description;
        public int Index;
    }
}
