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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmoothTranscode
{
    public partial class VP8Window : Form
    {
        private string Arguments = String.Empty;

        public string AdvancedArguments
        {
            get
            {
                return Arguments;
            }
        }

        public VP8Window()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont; // Sets UI font to system font
        }

        private void VP8Window_Load(object sender, EventArgs e)
        {
            // Default Combo Box Values
            qualityComboBox.SelectedIndex = 1; // Good
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Set quality Setting
            if (qualityComboBox.SelectedItem.ToString() == "Real Time")
                Arguments = "-quality realtime";
            else if (qualityComboBox.SelectedItem.ToString() == "Good")
                Arguments = "-quality good";
            else if (qualityComboBox.SelectedItem.ToString() == "Best")
                Arguments = "-quality best";
            // Set CPU Used
            Arguments += " -speed " + cpuUpDown.Value.ToString();
        }
    }
}
