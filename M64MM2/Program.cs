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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M64MM2
{
    static class Program
    {

        public static bool validAnimationData;
        public static bool validCameraData;

        public static bool UpdateAvailable;
        public static GitHubRelease LatestRelease;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // SplashForm performs the initial load of everything and sets the variables up there
            Application.Run(new SplashForm());
            Application.Run(new MainForm());
        }
    }
}
