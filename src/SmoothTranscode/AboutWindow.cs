/*
 *  Copyright (C) 2012 Atomic Wasteland
 *  http://www.atomicwasteland.co.uk/
 *
 *  This Program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SmoothTranscode
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            this.Font = SystemFonts.MessageBoxFont; // Sets UI font to system font
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); //Closes form
        }

        private void linkLabel21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.atomicwasteland.co.uk/"); // Opens Atomic Wasteland website
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            aboutPanelMenu.Renderer = new MenuRenderer(); // Changes toolstrip renderer to system with a bottom border bug fix
            // Updates version label with assembly version and formatted text
            versionLabel.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(3);
            versionLabel.Font = new Font(versionLabel.Font, FontStyle.Bold);
            // Display GPL license on the license tab web browser
            licenseBrowser.Navigate(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\gpl-3.0-standalone.html");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            hiddenTabsControl.SelectedTab = aboutPage;
            creditsButton.Checked = false;
            licenseButton.Checked = false;
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            hiddenTabsControl.SelectedTab = creditsPage;
            aboutButton.Checked = false;
            licenseButton.Checked = false;
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            hiddenTabsControl.SelectedTab = licensePage;
            aboutButton.Checked = false;
            creditsButton.Checked = false;
        }
    }
}
