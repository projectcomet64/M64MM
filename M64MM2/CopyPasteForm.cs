using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static M64MM2.Utils;

namespace M64MM2
{
    public partial class CopyPasteForm : Form
    {
        public CopyPasteForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Don't re-parse the color code if we're exporting
            if (tbColorCode.ReadOnly)
            {
                this.Close();
                return;
            }

            string wholeCode = "";
            for (int lineNum = 0; lineNum < tbColorCode.Lines.Length; lineNum++)
            {
                //Remove spaces from each line so they don't mess up the character count
                string line = tbColorCode.Lines[lineNum].Replace(" ", "");

                //If the line is empty, ignore it
                if (string.IsNullOrEmpty(line)) continue;

                //If each line isn't exactly 12 characters long, it's not a valid code
                if (line.Length != 12)
                {
                    string errorMsg = "Invalid color code: line " + (lineNum + 1) + " is too " + (line.Length > 12 ? "long." : "short.");
                    MessageBox.Show(this, errorMsg, "Invalid Color Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //If the code tries to write data outside of where Mario's colors are located, it's not a valid code
                int address = int.Parse(line.Substring(2, 6), NumberStyles.HexNumber);
                if (address < 0x07EC20 || address > 0x07ECA2)
                {
                    string errorMsg = "Invalid color code: line " + (lineNum + 1) + " is trying to edit memory address " + line.Substring(2, 6) + ", " +
                                      "which is not where Mario's color data is located. " + "Make sure you're not using a PAL region color code!";
                    MessageBox.Show(this, errorMsg, "Invalid Color Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                wholeCode += line;
            }

            ((AppearanceForm) this.Owner).ParseColorCode(wholeCode);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
