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
using M64MM.Utils;
using M64MM2.Properties;


namespace M64MM2 {
    public partial class CopyPasteForm : Form {
        public CopyPasteForm() {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            //Don't re-parse the color code if we're exporting
            if (tbColorCode.ReadOnly) {
                this.Close();
                return;
            }

            string wholeCode = "";

            try {
                wholeCode = Looks.ValidateCC(tbColorCode.Lines);
            }
            catch (ColorCodeInvalidException ex) {
                if (String.IsNullOrWhiteSpace(ex.Address)) {
                    string errorMsg = String.Format(Resources.invalidColorCodeMsg2, ex.Line, ex.Address);
                    MessageBox.Show(this, errorMsg, Resources.invalidColorCodeMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    string errorMsg = String.Format(Resources.invalidColorCodeMsg1, ex.Line, ex.Length > 12 ? Resources.invalidColorCodeMsgLong : Resources.invalidColorCodeMsgShort);
                    MessageBox.Show(this, errorMsg, Resources.invalidColorCodeMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ((AppearanceForm)Owner).ParseColorCode(tbColorCode.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnFile_Click(object sender, EventArgs e) {
            if (tbColorCode.ReadOnly) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Plain text Gameshark (*.txt) | *.txt";
                sfd.AddExtension = true;
                sfd.DefaultExt = ".txt";
                DialogResult dRes = sfd.ShowDialog();
                if (dRes == DialogResult.OK) {
                    try {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName)) {
                            foreach (string line in tbColorCode.Lines) {
                                sw.WriteLine(line);
                            }
                            Close();
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(String.Format(Resources.colorCodeErrorWriting, ex.Message), "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Plain text Gameshark (*.txt) | *.txt";
                ofd.AddExtension = true;
                ofd.DefaultExt = ".txt";
                DialogResult dRes = ofd.ShowDialog();
                if (dRes == DialogResult.OK) {
                    try {
                        using (StreamReader sw = new StreamReader(ofd.FileName)) {
                            tbColorCode.Text = sw.ReadToEnd();
                            btnOK_Click(null, null);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(String.Format(Resources.colorCodeErrorFileReading, ex.Message), "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
