/* 
 *	Copyright (C) 2011 Atomic Wasteland
 *	http://www.atomicwasteland.co.uk/
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
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
        private string OutputFile;
        private string Video = String.Empty;
        private string Audio = String.Empty;
        private string Format = String.Empty;
        private string Arguments;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void FormEnabled(bool Toggle)
        {
            mainTabs.Enabled = Toggle;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.Form1 openHelp = new Help.Form1();
            openHelp.Show();
        }

        #region Input Video Tab
        private void inputButton_Click(object sender, EventArgs e)
        {
            inputFileDialog.Filter = "All Compatible Formats|*.mpg;*.mpeg;*.ps;*.ts;*.mp4;*.m4v;*.mp3;*.aac;*.m4a;*.m4b;*.wmv;*.wma;*.asf;*.webm;*.mkv;*.mka;*.mks;*.ogv;*.oga;*.ogx;*.ogg;*.spx;*.flac;*.dvr-ms;*.wtv;*.avi;*.flv;*.divx;*.xvid;*.rm;*.ra;*.rv;*.ram;*.mov;*.3gp;*.3g2;*.avs;*.nsv;*.mjp;*.mjpg;*.gfx;*.mfx|MPEG Video (*.mpg; *.mpeg; *.ps; *.ts)|*.mpg;*.mpeg;*.ps;*.ts|MPEG-4 Video (*.mp4; *.m4v)|*.mp4;*.m4v|MP3 Audio (*.mp3)|*.mp3|MP4/AAC Audio (*.aac; *.m4a; *.m4b)|*.aac;*.m4a;*.m4b|Windows Media (*.wmv; *.wma; *.asf)|*.wmv;*.wma;*.asf|WebM (*.webm)|*.webm|Matroska (*.mkv; *.mka; *.mks)|*.mkv;*.mka;*.mks|Ogg (*.ogv; *.oga; *.ogx; *.ogg; *.spx)|*.ogv;*.oga;*.ogx;*.ogg;*.spx|Flac Audio (*.flac)|*.flac|Microsoft Recorded TV Show (*.dvr-ms; *.wtv)|*.dvr-ms,*.wtv|Windows Video (*.avi)|*.avi|Flash Video (*.flv)|*.flv|DivX (*.divx)|*.divx|XviD (*.xvid)|*.xvid|Real Media (*.rm; *.ra; *.rv; *.ram)|*.rm;*.ra;*.rv;*.ram|Quicktime Video (*.mov)|*.mov|Mobile Video (*.3gp; *.3g2)|*.3gp;*.3g2|AVISynth (*.avs)|*.avs|Nullsoft Video (*.nsv)|*.nsv|Motion JPEG (*.mjp; *.mjpg)|*.mjp;*.mjpg|General eXchange Format (*.gxf)|*.gxf|Material eXchange Format (*.mxf)|*.mxf|Any file|*.*";
            if (inputFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                inputTextBox.Text = inputFileDialog.FileName;
            }
        }
        #endregion

        #region Format Tab
        private void containerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (containerComboBox.SelectedItem == "MPEG-4")
                Format = "mp4";
            else if (containerComboBox.SelectedItem == "MPEG")
                Format = "mpeg";
            else if (containerComboBox.SelectedItem == "Windows Media")
                Format = "asf";
            else if (containerComboBox.SelectedItem == "Flash Video")
                Format = "flv";
            else if (containerComboBox.SelectedItem == "WebM")
                Format = "webm";
            else if (containerComboBox.SelectedItem == "Matroska")
                Format = "matroska";
            else if (containerComboBox.SelectedItem == "Ogg")
                Format = "ogg";
            else if (containerComboBox.SelectedItem == "AVI")
                Format = "avi";
            else if (containerComboBox.SelectedItem == "Real Media")
                Format = "rm";
            else if (containerComboBox.SelectedItem == "Quicktime Video")
                Format = "mov";
            else if (containerComboBox.SelectedItem == "DVD VOB")
                Format = "dvd";
            else if (containerComboBox.SelectedItem == "DV Video")
                Format = "dv";
            else if (containerComboBox.SelectedItem == "3GP")
                Format = "3gp";
            else if (containerComboBox.SelectedItem == "Motion JPEG")
                Format = "mjpeg";
            else if (containerComboBox.SelectedItem == "Material eXchange Format")
                Format = "mxf";
            else if (containerComboBox.SelectedItem == "MP3")
                Format = "mp3";
            else if (containerComboBox.SelectedItem == "MP2")
                Format = "mp2";
            else if (containerComboBox.SelectedItem == "FLAC")
                Format = "flac";
            else if (containerComboBox.SelectedItem == "WAV")
                Format = "wav";
            else if (containerComboBox.SelectedItem == "AIFF")
                Format = "aiff";
            else if (containerComboBox.SelectedItem == "AMR")
                Format = "amr";
        }

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
            else if (videoComboBox.SelectedItem == "Flash Video")
                Video = "flv";
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced video encoding options are not available in this version of SmoothTranscode.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
        #endregion

        #region Output Setup Tab
        private void outputButton_Click(object sender, EventArgs e)
        {
            outputFileDialog.Filter = "MPEG Video (*.mpg; *.mpeg; *.ps)|*.mpg;*.mpeg;*.ps|MPEG-4 Video (*.mp4; *.m4v)|*.mp4;*.m4v|MP3 Audio (*.mp3)|*.mp3|MP4/AAC Audio (*.aac; *.m4a)|*.aac;*.m4a|Windows Media (*.wmv; *.wma; *.asf)|*.wmv;*.wma;*.asf|WebM (*.webm)|*.webm|Matroska (*.mkv; *.mka; *.mks)|*.mkv;*.mka;*.mks|Ogg (*.ogv; *.oga; *.ogx; *.ogg; *.spx)|*.ogv;*.oga;*.ogx;*.ogg;*.spx|Flac Audio (*.flac)|*.flac|Windows Video (*.avi)|*.avi|Flash Video (*.flv)|*.flv|DivX (*.divx)|*.divx|XviD (*.xvid)|*.xvid|Real Media (*.rm; *.rv; *.ra)|*.rm;*.rv;*.ra|Quicktime Video (*.mov)|*.mov|Mobile Video (*.3gp; *.3g2)|*.3gp;*.3g2|Motion JPEG (*.mjp; *.mjpg)|*.mjp;*.mjpg|Any file|*.*";
            if (outputFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                OutputFile = outputFileDialog.FileName;
                outputTextBox.Text = OutputFile;
            }
        }
        #endregion

        #region Convert Video Button
        private void encodeButton_Click(object sender, EventArgs e)
        {
            // File checks
            if (inputTextBox.Text == String.Empty || outputTextBox.Text == String.Empty)
            {
                MessageBox.Show("Some required fields are missing", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(inputTextBox.Text))
            {
                MessageBox.Show("The input file does not exist.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (System.IO.File.Exists(outputTextBox.Text))
            {
                if (MessageBox.Show("The output file you have specified already exists. Would you like to overwrite it?", "Overwrite File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            }

            ffmpeg.inputFile = inputTextBox.Text;
            if (Format != String.Empty)
                Arguments += "-f " + Format;
            if (Video != String.Empty)
                Arguments += " -vcodec " + Video;
            if (deinterlaceCheckBox.Checked == true)
                Arguments += " -deinterlace";
            if (aspectComboBox.Text != String.Empty)
                Arguments += " -aspect " + aspectComboBox.Text;
            if (videoTextBox.Text != String.Empty)
                Arguments += " -b " + videoTextBox.Text + "k";
            if (widthTextBox.Text != String.Empty && heightTextBox.Text != String.Empty)
                Arguments += " -s " + widthTextBox.Text + "x" + heightTextBox.Text;
            if (Audio != String.Empty)
                Arguments += " -acodec " + Audio;
            if (channelsComboBox.Text != String.Empty)
                Arguments += " -ac " + channelsComboBox.Text;
            if (audioTextBox.Text != String.Empty)
                Arguments += " -ab " + audioTextBox.Text + "000";
            if (sampleComboBox.Text != String.Empty)
                Arguments += " -ar " + sampleComboBox.Text;
            if (croptopUpDown.Value > 0)
                Arguments += " -croptop " + croptopUpDown.Value;
            if (cropleftUpDown.Value > 0)
                Arguments += " -cropleft " + cropleftUpDown.Value;
            if (croprightUpDown.Value > 0)
                Arguments += " -cropright " + croprightUpDown.Value;
            if (cropbottomUpDown.Value > 0)
                Arguments += " -cropbottom " + cropbottomUpDown.Value;
            if (padtopUpDown.Value > 0)
                Arguments += " -padtop " + padtopUpDown.Value;
            if (padleftUpDown.Value > 0)
                Arguments += " -padleft " + padleftUpDown.Value;
            if (padrightUpDown.Value > 0)
                Arguments += " -padright " + padrightUpDown.Value;
            if (padbottomUpDown.Value > 0)
                Arguments += " -padbottom " + padbottomUpDown.Value;
            if (startComboBox.SelectedItem == "Seconds")
                if (startTextBox.Text != String.Empty)
                    Arguments += " -ss " + startTextBox.Text;
            else if (startComboBox.SelectedItem == "Frames")
                if (startTextBox.Text != String.Empty)
                    Arguments += " -ss " + startTextBox.Text;
            if (endComboBox.SelectedItem == "Seconds")
                if (endTextBox.Text != String.Empty)
                    Arguments += " -t " + endTextBox.Text;
            else if (endComboBox.SelectedItem == "Frames")
                if (endTextBox.Text != String.Empty)
                    Arguments += " -vframes " + endTextBox.Text;
            if (titleTextBox.Text != String.Empty)
                Arguments += " -title " + "\"" + titleTextBox.Text + "\"";
            if (authorTextBox.Text != String.Empty)
                Arguments += " -author " + "\"" + authorTextBox.Text + "\"";
            if (copyrightTextBox.Text != String.Empty)
                Arguments += " -copyright " + "\"" + copyrightTextBox.Text + "\"";
            if (commentTextBox.Text != String.Empty)
                Arguments += " -comment " + "\"" + commentTextBox.Text + "\"";
            ffmpeg.outputFile = outputTextBox.Text;

            ffmpeg.procArguments = Arguments;
            ProgressWindow progressWindow = new ProgressWindow();
            progressWindow.ShowDialog();
        }
        #endregion

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                inputTextBox.Text = file;
            }  
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
