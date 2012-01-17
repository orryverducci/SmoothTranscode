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
    public partial class X264Window : Form
    {
        private string Arguments = String.Empty;

        public string AdvancedArguments
        {
            get
            {
                return Arguments;
            }
        }

        public X264Window()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont; // Sets UI font to system font
        }

        private void X264Window_Load(object sender, EventArgs e)
        {
            // Default Combo Box Values
            trellisComboBox.SelectedIndex = 1; // Enabled with Macroblock
            pyramidalComboBox.SelectedIndex = 1; // Normal
            adaptiveComboBox.SelectedIndex = 1; // Fast
            directComboBox.SelectedIndex = 1; // Spatial
            meComboBox.SelectedIndex = 1; // Hexagon
            subpixelComboBox.SelectedIndex = 6; // RD in all frames
        }

        // Disable trellis combo box when CABAC is disabled
        private void cabacCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cabacCheckBox.Checked == true)
                trellisComboBox.Enabled = true;
            else
                trellisComboBox.Enabled = false;
        }

        private void aqTrackBar_Scroll(object sender, EventArgs e)
        {
            // Update label with track bar value
            decimal value = decimal.Divide(aqTrackBar.Value, 10); // Divide by 10 to get decimal between 0 and 2
            aqValueLabel.Text = String.Format("{0:0.0}", value); // Format label to have 1 decimal place
        }

        private void psyTrackBar_Scroll(object sender, EventArgs e)
        {
            // Update label with track bar value
            decimal value = decimal.Divide(psyTrackBar.Value, 10); // Divide by 10 to get decimal between 0 and 2
            psyValueLabel.Text = String.Format("{0:0.0}", value); // Format label to have 1 decimal place
        }

        /// <summary>
        /// Returns inputted setting either as inputted or with a ':' prefix depending on whether any settings have been previously set
        /// </summary>
        /// <param name="setting">x264 Setting Parameter</param>
        /// <returns>String to add to options argument</returns>
        private string addString(string setting)
        {
            if (Arguments != String.Empty)
                return setting;
            else
                return ":" + setting;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Set tuning setting
            if (tuningComboBox.SelectedIndex > -1) // Check item is selected
            {
                if (tuningComboBox.SelectedItem.ToString() == "Film")
                    Arguments = "tune=film";
                else if (tuningComboBox.SelectedItem.ToString() == "Animation")
                    Arguments = "tune=animation";
                else if (tuningComboBox.SelectedItem.ToString() == "Grain")
                    Arguments = "tune=grain";
                else if (tuningComboBox.SelectedItem.ToString() == "Still Image")
                    Arguments = "tune=stillimage";
                else if (tuningComboBox.SelectedItem.ToString() == "PSNR")
                    Arguments = "tune=psnr";
                else if (tuningComboBox.SelectedItem.ToString() == "SSIM")
                    Arguments = "tune=ssim";
                else if (tuningComboBox.SelectedItem.ToString() == "Fast Decode")
                    Arguments = "tune=fastdecode";
                else if (tuningComboBox.SelectedItem.ToString() == "Zero Latency")
                    Arguments = "tune=zerolatency";
            }
            // Set CABAC setting
            if (cabacCheckBox.Checked == false)
                Arguments += addString("no-cabac");
            // Set 8x8 transform
            if (dctCheckBox.Checked == false)
                Arguments += addString("no-8x8dct");
            // Set trellis setting
            if (cabacCheckBox.Checked) // If CABAC is enabled, as required for trellis
            {
                if (trellisComboBox.SelectedItem.ToString() == "Off")
                    Arguments += addString("trellis=0");
                else if (trellisComboBox.SelectedItem.ToString() == "Enabled on Macroblock")
                    Arguments += addString("trellis=1");
                else if (trellisComboBox.SelectedItem.ToString() == "Enabled on All Modes")
                    Arguments += addString("trellis=2");
            }
            // Set reference frames
            Arguments += addString("ref=" + refUpDown.Value.ToString());
            // Set maximum b-frames frames
            Arguments += addString("bframes=" + bframesUpDown.Value.ToString());
            // Set weighted p-frames
            if (weightedCheckBox.Checked)
                Arguments += addString("weightp=2");
            else
                Arguments += addString("weightp=0");
            //Set pyramidal b-frames
            if (pyramidalComboBox.SelectedItem.ToString() == "None")
                Arguments += addString("b-pyramid=none");
            else if (pyramidalComboBox.SelectedItem.ToString() == "Normal")
                Arguments += addString("b-pyramid=normal");
            else if (pyramidalComboBox.SelectedItem.ToString() == "Strict")
                Arguments += addString("b-pyramid=strict");
            // Set adaptive b-frames
            if (adaptiveComboBox.SelectedItem.ToString() == "Off")
                Arguments += addString("b-adapt=0");
            else if (adaptiveComboBox.SelectedItem.ToString() == "Fast")
                Arguments += addString("b-adapt=1");
            else if (adaptiveComboBox.SelectedItem.ToString() == "Optimal")
                Arguments += addString("b-adapt=2");
            // Set no dct-decimate
            if (decimateCheckBox.Checked)
                Arguments += addString("no-dct-decimate=1");
            // Set adaptive direct mode
            if (directComboBox.SelectedItem.ToString() == "None")
                Arguments += addString("direct=none");
            else if (directComboBox.SelectedItem.ToString() == "Spatial")
                Arguments += addString("direct=spatial");
            else if (directComboBox.SelectedItem.ToString() == "Temporal")
                Arguments += addString("direct=temporal");
            else if (directComboBox.SelectedItem.ToString() == "Automatic")
                Arguments += addString("direct=auto");
            // Set motion estimation method
            if (meComboBox.SelectedItem.ToString() == "Diamond")
                Arguments += addString("me=dia");
            else if (meComboBox.SelectedItem.ToString() == "Hexagon")
                Arguments += addString("me=hex");
            else if (meComboBox.SelectedItem.ToString() == "Uneven Multi-Hexagon")
                Arguments += addString("me=umh");
            else if (meComboBox.SelectedItem.ToString() == "Exhaustive")
                Arguments += addString("me=esa");
            else if (meComboBox.SelectedItem.ToString() == "Transformed Exhaustive")
                Arguments += addString("me=tesa");
            // Set subpixel me and mode decision
            if (subpixelComboBox.SelectedItem.ToString() == "SAD, no subpel")
                Arguments += addString("subme=0");
            else if (subpixelComboBox.SelectedItem.ToString() == "SAD, qpel")
                Arguments += addString("subme=1");
            else if (subpixelComboBox.SelectedItem.ToString() == "SATD, qpel")
                Arguments += addString("subme=2");
            else if (subpixelComboBox.SelectedItem.ToString() == "SATD, multi-qpel")
                Arguments += addString("subme=3");
            else if (subpixelComboBox.SelectedItem.ToString() == "SATD, qpel on all")
                Arguments += addString("subme=4");
            else if (subpixelComboBox.SelectedItem.ToString() == "SATD, multi-qpel on all")
                Arguments += addString("subme=5");
            else if (subpixelComboBox.SelectedItem.ToString() == "RD in I/P-frames")
                Arguments += addString("subme=6");
            else if (subpixelComboBox.SelectedItem.ToString() == "RD in all frames")
                Arguments += addString("subme=7");
            else if (subpixelComboBox.SelectedItem.ToString() == "RD refinement in I/P-frames")
                Arguments += addString("subme=8");
            else if (subpixelComboBox.SelectedItem.ToString() == "RD refinement in all frames")
                Arguments += addString("subme=9");
            else if (subpixelComboBox.SelectedItem.ToString() == "QPRD in all frames")
                Arguments += addString("subme=10");
            else if (subpixelComboBox.SelectedItem.ToString() == "Full RD in all frames")
                Arguments += addString("subme=11");
            // Set adaptive quantization strength
            Arguments += addString("aq-strength=" + aqTrackBar.Text);
            // Set psychovisual rate distortion
            Arguments += addString("psy-rd=" + psyTrackBar.Text + "0,0.00");
            // Set deblocking
            Arguments += addString("deblock=" + strengthUpDown.Value.ToString() + "," + thresholdUpDown.Value.ToString());
            // Add prefix if neccessary
            if (Arguments != String.Empty)
                Arguments = "-x264opts " + Arguments;
        }
    }
}
