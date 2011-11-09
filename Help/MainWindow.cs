/*
 *  Copyright (C) 2011 Atomic Wasteland
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace Help
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            // Handle browser events indicating if the user can go back and fowards
            helpBrowser.CanGoBackChanged += new EventHandler(helpBrowser_CanGoBackChanged);
            helpBrowser.CanGoForwardChanged += new EventHandler(helpBrowser_CanGoForwardChanged);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Apply toolstrip style
            helpToolStrip.Renderer = new Renderers.AeroRenderer();
            // Open specified page
            helpBrowser.Navigate(Help.Config.url + Help.Config.page);
        }

        // Displays progress bar when loading page
        private void helpBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            helpProgressBar.Visible = true;
            helpProgressBar.Value = 0;
        }

        // Updates progress bar as page loads
        private void helpBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            helpProgressBar.Maximum = Convert.ToInt32(e.MaximumProgress) + 1;
            helpProgressBar.Value = Convert.ToInt32(e.CurrentProgress) + 1; //Adds 1 to prevent error when -1 (complete) is returned

        }

        // Hides progress bar when page loading is complete
        private void helpBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            helpProgressBar.Visible = false;
        }

        // Goes back 1 page
        private void backButton_Click(object sender, EventArgs e)
        {
            helpBrowser.GoBack();
        }

        // Goes forward 1 page
        private void forwardButton_Click(object sender, EventArgs e)
        {
            helpBrowser.GoForward();
        }

        // Open contents page
        private void contentsButton_Click(object sender, EventArgs e)
        {
            helpBrowser.Navigate(Help.Config.url);
        }

        // Enables and disabled the back button as required
        private void helpBrowser_CanGoBackChanged(object sender, EventArgs e)
        {
            backButton.Enabled = helpBrowser.CanGoBack;
        }

        // Enables and disabled the forward button as required
        private void helpBrowser_CanGoForwardChanged(object sender, EventArgs e)
        {
            forwardButton.Enabled = helpBrowser.CanGoForward;
        }
    }
}
