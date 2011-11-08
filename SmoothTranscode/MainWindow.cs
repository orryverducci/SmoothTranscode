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
using Help;

namespace SmoothTranscode
{
    public partial class MainWindow : Form
    {
        private string Video = String.Empty;
        private string Audio = String.Empty;
        private string Format = String.Empty;
        private string Arguments;

        public MainWindow()
        {
            this.Font = SystemFonts.MessageBoxFont; // Sets UI font to system font
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Retrieve arguments and set input file if opened with file argument
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
                inputTextBox.Text = args[1];
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            // Allows files to be dragged onto the window
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            // Places the filename of dropped files into the input text box
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                inputTextBox.Text = file;
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            // Opens the about window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            // Opens the help window
            Help.Form1 helpWindow = new Help.Form1();
            helpWindow.Show();
        }

        #region Input Tab
        private void inputButton_Click(object sender, EventArgs e)
        {
            // If file selected, place filename in the input text box
            if (inputFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                inputTextBox.Text = inputFileDialog.FileName;
            }
        }

        // Sets container to selected option
        private void containerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (containerComboBox.SelectedItem.ToString() == "MPEG-4 Video/MP4 Audio")
            {
                Format = "mp4";
                outputFileDialog.Filter = "MP4 (*.mp4; *.m4v; *.m4a; *.aac)|*.mp4;*.m4v;*.m4a;*.aac|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "MPEG")
            {
                Format = "mpeg";
                outputFileDialog.Filter = "MPEG Video (*.mpg; *.mpeg; *.ps)|*.mpg;*.mpeg;*.ps|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Windows Media")
            {
                Format = "asf";
                outputFileDialog.Filter = "Windows Media (*.wmv; *.wma; *.asf)|*.wmv;*.wma;*.asf|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Flash Video")
            {
                Format = "flv";
                outputFileDialog.Filter = "Flash Video (*.flv)|*.flv|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "WebM")
            {
                Format = "webm";
                outputFileDialog.Filter = "WebM (*.webm)|*.webm|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Matroska")
            {
                Format = "matroska";
                outputFileDialog.Filter = "Matroska (*.mkv; *.mka)|*.mkv;*.mka|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Ogg")
            {
                Format = "ogg";
                outputFileDialog.Filter = "Ogg (*.ogg; *.ogv; *.oga)|*.ogg;*.ogv;*.oga|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "AVI")
            {
                Format = "avi";
                outputFileDialog.Filter = "AVI (*.avi)|*.avi|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Real Media")
            {
                Format = "rm";
                outputFileDialog.Filter = "Real Media (*.rm; *.rv; *.ra)|*.rm;*.rv;*.ra|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Quicktime Video")
            {
                Format = "mov";
                outputFileDialog.Filter = "Quicktime Video (*.mov)|*.mov|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "DVD VOB")
            {
                Format = "dvd";
                outputFileDialog.Filter = "DVD VOB (*.vob)|*.vob|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "DV Video")
            {
                Format = "dv";
                outputFileDialog.Filter = "DV Video (*.dv)|*.dv|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "3GP")
            {
                Format = "3gp";
                outputFileDialog.Filter = "Mobile Video (*.3gp)|*.3gp|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Motion JPEG")
            {
                Format = "mjpeg";
                outputFileDialog.Filter = "Motion JPEG (*.mjpg; *.mjp)|*.mjpg;*.mjp|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "Material eXchange Format")
            {
                Format = "mxf";
                outputFileDialog.Filter = "Material eXchange Format (*.mxf)|*.mxf|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "MP3")
            {
                Format = "mp3";
                outputFileDialog.Filter = "MP3 Audio (*.mp3)|*.mp3|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "MP2")
            {
                Format = "mp2";
                outputFileDialog.Filter = "MP2 Audio (*.mp2)|*.mp2|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "FLAC")
            {
                Format = "flac";
                outputFileDialog.Filter = "FLAC Audio (*.flac)|*.flac|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "WAV")
            {
                Format = "wav";
                outputFileDialog.Filter = "WAV Audio (*.wav)|*.wav|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "AIFF")
            {
                Format = "aiff";
                outputFileDialog.Filter = "AIFF Audio (*.aiff; *.aif)|*.aiff;*.aif|Any file|*.*";
            }
            else if (containerComboBox.SelectedItem.ToString() == "AMR")
            {
                Format = "amr";
                outputFileDialog.Filter = "AMR Audio (*.amr)|*.amr|Any file|*.*";
            }
        }
        #endregion

        #region Video Tab
        private void videoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable options if video enabled
            if (videoCheckBox.Checked)
            {
                codecSeperator.Enabled = true;
                videoCodecLabel.Enabled = true;
                videoComboBox.Enabled = true;
                advancedButton.Enabled = true;
                videoBitratePanel.Enabled = true;
                resolutionSeperator.Enabled = true;
                resolutionLabel.Enabled = true;
                widthTextBox.Enabled = true;
                xLabel.Enabled = true;
                heightTextBox.Enabled = true;
                pixelsLabel.Enabled = true;
                aspectLabel.Enabled = true;
                aspectComboBox.Enabled = true;
                frameRateLabel.Enabled = true;
                frameRateComboBox.Enabled = true;
                deinterlaceCheckBox.Enabled = true;
            }
            // Otherwise disable options if video disabled
            else
            {
                codecSeperator.Enabled = false;
                videoCodecLabel.Enabled = false;
                videoComboBox.Enabled = false;
                advancedButton.Enabled = false;
                videoBitratePanel.Enabled = false;
                resolutionSeperator.Enabled = false;
                resolutionLabel.Enabled = false;
                widthTextBox.Enabled = false;
                xLabel.Enabled = false;
                heightTextBox.Enabled = false;
                pixelsLabel.Enabled = false;
                aspectLabel.Enabled = false;
                aspectComboBox.Enabled = false;
                frameRateLabel.Enabled = false;
                frameRateComboBox.Enabled = false;
                deinterlaceCheckBox.Enabled = false;
            }
        }

        // Disable bitrate options if same quality selected
        private void sameQualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbrTextBox.Enabled = false;
            cbrLabel.Enabled = false;
            vbrTextBox.Enabled = false;
            vbrKbpsLabel.Enabled = false;
            vbrOptionalLabel.Enabled = false;
            vbrMinLabel.Enabled = false;
            vbrMinTextBox.Enabled = false;
            vbrMaxLabel.Enabled = false;
            vbrMaxTextBox.Enabled = false;
            vbrBufferLabel.Enabled = false;
            vbrBufferTextBox.Enabled = false;
        }

        // Enable vbr bitrate options and disable others if average bitrate selected
        private void vbrRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbrTextBox.Enabled = false;
            cbrLabel.Enabled = false;
            vbrTextBox.Enabled = true;
            vbrKbpsLabel.Enabled = true;
            vbrOptionalLabel.Enabled = true;
            vbrMinLabel.Enabled = true;
            vbrMinTextBox.Enabled = true;
            vbrMaxLabel.Enabled = true;
            vbrMaxTextBox.Enabled = true;
            vbrBufferLabel.Enabled = true;
            vbrBufferTextBox.Enabled = true;
        }

        // Enable cbr bitrate options and disable others if constant bitrate selected
        private void cbrRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbrTextBox.Enabled = true;
            cbrLabel.Enabled = true;
            vbrTextBox.Enabled = false;
            vbrKbpsLabel.Enabled = false;
            vbrOptionalLabel.Enabled = false;
            vbrMinLabel.Enabled = false;
            vbrMinTextBox.Enabled = false;
            vbrMaxLabel.Enabled = false;
            vbrMaxTextBox.Enabled = false;
            vbrBufferLabel.Enabled = false;
            vbrBufferTextBox.Enabled = false;
        }

        // Sets video codec to selected option
        private void videoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoComboBox.SelectedItem == "MPEG-4")
                Video = "mpeg4";
            else if (videoComboBox.SelectedItem == "MPEG-2")
                Video = "mpeg2video";
            else if (videoComboBox.SelectedItem == "MPEG-1")
                Video = "mpeg1video";
            else if (videoComboBox.SelectedItem == "H.264")
                Video = "libx264";
            else if (videoComboBox.SelectedItem == "H.263")
                Video = "h263";
            else if (videoComboBox.SelectedItem == "H.261")
                Video = "h261";
            else if (videoComboBox.SelectedItem == "Windows Media Video 8")
                Video = "wmv2";
            else if (videoComboBox.SelectedItem == "Windows Media Video 7")
                Video = "wmv1";
            else if (videoComboBox.SelectedItem == "Flash Video (Sorenson Spark)")
                Video = "flv";
            else if (videoComboBox.SelectedItem == "VP8")
                Video = "libvpx";
            else if (videoComboBox.SelectedItem == "Real Video 2.0")
                Video = "rv20";
            else if (videoComboBox.SelectedItem == "Real Video 1.0")
                Video = "rv10";
            else if (videoComboBox.SelectedItem == "Ogg Theora")
                Video = "libtheora";
            else if (videoComboBox.SelectedItem == "DV")
                Video = "dvvideo";
            else if (videoComboBox.SelectedItem == "XviD")
                Video = "libxvid";
            else if (videoComboBox.SelectedItem == "Dirac")
                Video = "libschroedinger";
            else if (videoComboBox.SelectedItem == "Motion JPEG")
                Video = "mjpeg";
            else if (videoComboBox.SelectedItem == "AVID DNxHD")
                Video = "dnxhd";
        }

        // Show advanced options dialog for the selected codec
        private void advancedButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced video encoding options are not available in this version of SmoothTranscode.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Audio Tab
        private void audioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable options if audio enabled
            if (audioCheckBox.Checked)
            {
                audioCodecLabel.Enabled = true;
                audioComboBox.Enabled = true;
                audioBitratePanel.Enabled = true;
                channelsSeperator.Enabled = true;
                channelsLabel.Enabled = true;
                channelsComboBox.Enabled = true;
                sampleLabel.Enabled = true;
                sampleComboBox.Enabled = true;
            }
            // Otherwise disable options if audio disabled
            else
            {
                audioCodecLabel.Enabled = false;
                audioComboBox.Enabled = false;
                audioBitratePanel.Enabled = false;
                channelsSeperator.Enabled = false;
                channelsLabel.Enabled = false;
                channelsComboBox.Enabled = false;
                sampleLabel.Enabled = false;
                sampleComboBox.Enabled = false;
            }
        }

        //Sets audio codec to selected option
        private void audioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (audioComboBox.SelectedItem == "MP3")
                Audio = "libmp3lame";
            else if (audioComboBox.SelectedItem == "MP2")
                Audio = "mp2";
            else if (audioComboBox.SelectedItem == "AAC")
                Audio = "aac -strict experimental";
            else if (audioComboBox.SelectedItem == "AC3")
                Audio = "ac3";
            else if (audioComboBox.SelectedItem == "E-AC3")
                Audio = "eac3";
            else if (audioComboBox.SelectedItem == "Ogg Vorbis")
                Audio = "vorbis";
            else if (audioComboBox.SelectedItem == "Windows Media Audio Version 2")
                Audio = "wmav2";
            else if (audioComboBox.SelectedItem == "Windows Media Audio Version 1")
                Audio = "wmav1";
            else if (audioComboBox.SelectedItem == "Real Audio Version 1")
                Audio = "real_114";
            else if (audioComboBox.SelectedItem == "FLAC")
                Audio = "flac";
            else if (audioComboBox.SelectedItem == "Apple Lossless Audio Codec")
                Audio = "alac";
            else if (audioComboBox.SelectedItem == "Nellymoser")
                Audio = "nellymoser";
        }

        // Disable set quality option if constant bitrate is selected
        private void audioBitrateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            audioBitrateTextBox.Enabled = true;
            audioQualTextBox.Enabled = false;
        }

        // Disable constant bitrate option if set quality is selected
        private void auidQualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            audioBitrateTextBox.Enabled = false;
            audioQualTextBox.Enabled = true;
        }
        #endregion

        #region Output Tab
        private void outputButton_Click(object sender, EventArgs e)
        {
            if (outputFileDialog.ShowDialog() != DialogResult.Cancel)
                outputTextBox.Text = outputFileDialog.FileName;
        }
        #endregion

        #region Convert Video Button
        private void convertButton_Click(object sender, EventArgs e)
        {
            // Checks input and output files are specified
            if (inputTextBox.Text == String.Empty || outputTextBox.Text == String.Empty)
            {
                MessageBox.Show("You need to set both the input and output file fields.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancel conversion
            }
            // Checks the input file exists
            if (!System.IO.File.Exists(inputTextBox.Text))
            {
                MessageBox.Show("The input file does not exist.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancel conversion
            }
            // Checks bitrate specified when set to vbr
            if (vbrRadioButton.Checked && vbrTextBox.Text == String.Empty)
            {
                MessageBox.Show("You have set to use an average video bitrate but have not specified a bitrate to target.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancel conversion
            }
            // Checks vbr buffer size set when max bitrate is specified
            if (vbrRadioButton.Checked)
                if (vbrMaxTextBox.Text != String.Empty && vbrBufferTextBox.Text == String.Empty)
                {
                    MessageBox.Show("To set a maximum bitrate you need to set a buffer size.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Cancel conversion
                }
            // Checks bitrate specified when set to cbr
            if (cbrRadioButton.Checked && cbrTextBox.Text == String.Empty)
            {
                MessageBox.Show("You have set to use an constant video bitrate but have not specified a bitrate to use.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancel conversion
            }
            // Asks for confirmation to overwrite if the output file already exists
            if (System.IO.File.Exists(outputTextBox.Text))
            {
                if (MessageBox.Show("The output file you have specified already exists. Would you like to overwrite it?", "Overwrite File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return; // Cancel conversion
            }

            // Create arguments for FFmpeg from options set in UI
            // Input tab
            ffmpeg.inputFile = inputTextBox.Text;
            if (Format != String.Empty)
                Arguments += "-f " + Format;
            // Video tab
            if (videoCheckBox.Checked) // If video enabled
            {
                if (Video != String.Empty)
                    Arguments += " -vcodec " + Video;
                if (sameQualRadioButton.Checked)
                    Arguments += " -sameq";
                if (vbrRadioButton.Checked)
                {
                    Arguments += " -b " + vbrTextBox.Text + "k";
                    if (vbrMinTextBox.Text != String.Empty)
                        Arguments += " -minrate" + vbrMinTextBox.Text + "k";
                    if (vbrMaxTextBox.Text != String.Empty)
                        Arguments += " -maxrate " + vbrMaxTextBox.Text + "k";
                    if (vbrBufferTextBox.Text != String.Empty)
                        Arguments += " -bufsize " + vbrBufferTextBox.Text + "k";
                }
                if (cbrRadioButton.Checked)
                {
                    Arguments += " -b " + cbrTextBox.Text + "k";
                    Arguments += " -bufsize 100k";
                    Arguments += " -minrate" + cbrTextBox.Text + "k";
                    Arguments += " -maxrate " + cbrTextBox.Text + "k";
                }
                if (widthTextBox.Text != String.Empty && heightTextBox.Text != String.Empty)
                    Arguments += " -s " + widthTextBox.Text + "x" + heightTextBox.Text;
                if (aspectComboBox.Text != String.Empty)
                    Arguments += " -aspect " + aspectComboBox.Text;
                if (frameRateComboBox.Text != String.Empty)
                    Arguments += " -r " + frameRateComboBox.Text;
                if (deinterlaceCheckBox.Checked == true)
                    Arguments += " -deinterlace";
            }
            else // Else disable video recording
                Arguments += " -vn";
            // Audio Tab
            if (audioCheckBox.Checked) // If audio enabled
            {
                if (Audio != String.Empty)
                    Arguments += " -acodec " + Audio;
                if (channelsComboBox.Text != String.Empty)
                    Arguments += " -ac " + channelsComboBox.Text;
                if (audioBitrateRadioButton.Checked)
                {
                    if (audioBitrateTextBox.Text != String.Empty)
                        Arguments += " -ab " + audioBitrateTextBox.Text + "k";
                }
                if (audioQualRadioButton.Checked)
                {
                    if (audioQualTextBox.Text != String.Empty)
                        Arguments += " -aq " + audioQualTextBox.Text;
                }
                if (sampleComboBox.Text != String.Empty)
                    Arguments += " -ar " + sampleComboBox.Text;
            }
            else // Else disable audio recording
                Arguments += " -an";
            // Crop tab
            if (cropTopUpDown.Value > 0)
                Arguments += " -croptop " + cropTopUpDown.Value;
            if (cropLeftUpDown.Value > 0)
                Arguments += " -cropleft " + cropLeftUpDown.Value;
            if (cropRightUpDown.Value > 0)
                Arguments += " -cropright " + cropRightUpDown.Value;
            if (cropBottomUpDown.Value > 0)
                Arguments += " -cropbottom " + cropBottomUpDown.Value;
            // Pad tab
            if (padTopUpDown.Value > 0)
                Arguments += " -padtop " + padTopUpDown.Value;
            if (padLeftUpDown.Value > 0)
                Arguments += " -padleft " + padLeftUpDown.Value;
            if (padRightUpDown.Value > 0)
                Arguments += " -padright " + padRightUpDown.Value;
            if (padBottomUpDown.Value > 0)
                Arguments += " -padbottom " + padBottomUpDown.Value;
            // Meta data tab
            if (titleTextBox.Text != String.Empty)
                Arguments += " -title " + "\"" + titleTextBox.Text + "\"";
            if (authorTextBox.Text != String.Empty)
                Arguments += " -author " + "\"" + authorTextBox.Text + "\"";
            if (copyrightTextBox.Text != String.Empty)
                Arguments += " -copyright " + "\"" + copyrightTextBox.Text + "\"";
            if (commentTextBox.Text != String.Empty)
                Arguments += " -comment " + "\"" + commentTextBox.Text + "\"";
            //Output tab
            ffmpeg.outputFile = outputTextBox.Text;

            // Pass arguments to FFmpeg
            ffmpeg.procArguments = Arguments;
            // Open progress window to start conversion
            ProgressWindow progressWindow = new ProgressWindow();
            progressWindow.ShowDialog();
        }
        #endregion
    }
}
