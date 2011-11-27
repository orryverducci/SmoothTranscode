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
            if (tuningComboBox.SelectedIndex > -1)
            {
                if (tuningComboBox.SelectedItem.ToString() == "Film")
                    Arguments += addString("tune=film");
                else if (tuningComboBox.SelectedItem.ToString() == "Animation")
                    Arguments += addString("tune=animation");
                else if (tuningComboBox.SelectedItem.ToString() == "Grain")
                    Arguments += addString("tune=grain");
                else if (tuningComboBox.SelectedItem.ToString() == "Still Image")
                    Arguments += addString("tune=stillimage");
                else if (tuningComboBox.SelectedItem.ToString() == "PSNR")
                    Arguments += addString("tune=psnr");
                else if (tuningComboBox.SelectedItem.ToString() == "SSIM")
                    Arguments += addString("tune=ssim");
                else if (tuningComboBox.SelectedItem.ToString() == "Fast Decode")
                    Arguments += addString("tune=fastdecode");
                else if (tuningComboBox.SelectedItem.ToString() == "Zero Latency")
                    Arguments += addString("tune=zerolatency");
            }
            // Add prefix if neccessary
            if (Arguments != String.Empty)
                Arguments = "-x264opts " + Arguments;
        }
    }
}
