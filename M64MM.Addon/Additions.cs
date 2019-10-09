using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Additions
{
    public class Addon
    {
        public IModule Module { get; }
        public bool Active { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public Addon(IModule mod, string nm, string vr, string dc)
        {
            Module = mod;
            Name = nm;
            Version = vr;
            Description = dc;
            Active = true;
        }
        public override string ToString()
        {
            return Name;
        }

    }

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

    public interface IModule
    {
        void Initialize();
        void Update();
        void Reset();
        void Close(EventArgs e);
        string SafeName { get; }
        string Description { get; }
        List<ToolCommand> GetCommands();
    }
}
