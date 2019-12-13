using System;
using System.Collections.Generic;

namespace M64MM.Additions
{
    /// <summary>
    /// Instanced Addon. This is the active version of IModule which is used in M64MM.
    /// It has the addon's metadata such as name, version, and etc.
    /// </summary>
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

}
