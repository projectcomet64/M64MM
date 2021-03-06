﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace M64MM.Additions
{
    /// <summary>
    /// Base interface for Addons (called Addon Modules internally)
    /// A single addon can have many modules.
    /// In the UI, these will be treated separately, but will all load from a single library.
    /// </summary>
    public interface IModule
    {
        void Initialize();
        void OnBaseAddressFound();
        void OnBaseAddressZero();
        void OnCoreEntAddressChange(uint addr);
        void Update();
        void Reset();
        void Close(EventArgs e);
        string SafeName { get; }
        string Description { get; }
        Image AddonIcon { get; }
        List<ToolCommand> GetCommands();
    }
}
