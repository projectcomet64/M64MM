/*  Copyright (C) 2020 Project Comet [GlitchyPSI, James Pelster & contributors]

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using M64MM.Utils;
using M64MM2.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M64MM2
{
    static class Program
    {

        public static bool validAnimationData;
        public static bool validCameraData;

        public static VersionTagManager.VersionTag CurrentVersionTag = VersionTagManager.GetVersionFromTag(Application.ProductVersion + Resources.prereleaseString);
        public static bool HasUpdate;
        public static GitHubRelease LatestRelease;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            int holdon = 0;
            string expath = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    try
                    {
                        switch (args[i])
                        {
                            case "--holdon":
                                {
                                    holdon = int.Parse(args[i + 1]);
                                    break;
                                }
                            case "--moreaddons":
                                {
                                    expath = args[i + 1];
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        #if DEBUG
                        Debug.WriteLine($"Error while parsing arg {args[i]}: {e.Message}");
                        #endif
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // SplashForm performs the initial load of everything and sets the variables up there
            Application.Run(new SplashForm(holdon, expath));
            Application.Run(new MainForm());
        }
    }
}
