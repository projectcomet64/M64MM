using System;
using System.Collections.Generic;
using System.Text;

namespace M64MM.Additions
{
    /// <summary>
    /// Class that defines a command that is visible in the M64MM UI.
    /// Has a similar structure to VEGAS Pro's.
    /// </summary>
    public class ToolCommand
    {
        public string name;
        public delegate void SummonCommand(object sender, EventArgs e);
        public event SummonCommand Summoned;

        public ToolCommand(string n)
        {
            name = n;
        }

        public void Summon(object sender, EventArgs e)
        {
            Summoned(this, e);
        }
    }
}
