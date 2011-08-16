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
        private string InputFile;
        private string OutputFile;
        private string Video = String.Empty;
        private string Audio = String.Empty;
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
            inputFileDialog.Title = "Select Video File to Convert";
            inputFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            inputFileDialog.FileName = "";
            inputFileDialog.Filter = "MPEG Video (*.mpg;*.mpeg;*.ps;*.ts)|*.mpg;*.mpeg*.ps;*.ts|MPEG-4 Video (*.mp4)|*.mp4|Windows Media Video (*.wmv,*.asf)|*.wmv,*.asf|Microsoft Recorded TV Show (*.dvr-ms)|*.dvr-ms|Windows Video (*.avi)|*.avi|Flash Video (*.flv)|*.flv|DivX (*.divx)|*.divx|XviD (*.xvid)|*.xvid|Real Media (*.rm)|*.rm|Quicktime Video (*.mov)|*.mov|Mobile Video (*.3gp;*.3g2)|*.3gp;*.3g2|Nullsoft Video (*.nsv)|*.nsv|Motion JPEG (*.mjp;*.mjpg)|*.mjp;*.mjpg|Matroska (*.mkv;*.mka;*.mks)|*.mkv;*.mka;*.mks|NUT Video (*.nut)|*.nut|TechnoTrend PVA (*.pva)|*.pva|Mimic MSN/WLM Webcam (*.cam)|*.cam|Electronic Arts Format (*.cmv;*.dct;*.snd;*.tgi;*.tgv;*.tgq;*.wve;*.uv;*.uv2;*.mad;*.vp6)|*.cmv;*.dct;*.snd;*.tgi;*.tgv;*.tgq;*.wve;*.uv;*.uv2;*.mad;*.vp6|4X Technologies (*.4xm)|*.4xm|Playstation STR (*.str)|*.str|Nintendo Gamecube THP (*.thp)|*.thp|Smacker Video (*.smk)|*.vqa|Id RoQ (*.roq)|*.roq|Interplay MVE (*.mve)|*.mve|Sega FILM (*.cpk;*.cak;*.film)|*.cpk;*.cak;*.film|Westwood Studios VQA (*.vqa)|*.vqa|Id Cinematic (*.cin)|*.cin|FLIC Video (*.fli;*.flc)|*.fli;*.flc|Sierra Video and Music Data (*.vmd)|*.vmd|Sierra Online (*.sol)|*.sol|American Laser Games MM (*.mm)|*.mm|AVS Video (*.avs)|*.avs|Tiertex SEQ (*.seq)|*.seq|DXA Video (*.dxa)|*.dxa|Interplay C93 (*.c93)|*.c93|Bethsoft VID (*.vid)|*.vid|Beam SIFF (*.vb;*.son)|*.vb;*.son|RL2 Video (*.rl2)|*.rl2|Interchange File Format (*.8svx;*.16sv;*ilbm;*.anim)|*.8svx;*.16sv;*ilbm;*.anim|General eXchange Format (*.gxf)|*.gxf|Material eXchange Format (*.mxf)|*.mxf|Any file|*.*";
            if (inputFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                InputFile = inputFileDialog.FileName;
                inputTextBox.Text = InputFile;
            }
        }
        #endregion

        #region Format Tab
        private void videoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoComboBox.SelectedItem == "MPEG-1")
                Video = "mpeg1video";
            else if (videoComboBox.SelectedItem == "MPEG-2")
                Video = "mpeg2video";
            else if (videoComboBox.SelectedItem == "MPEG-4")
                Video = "mpeg4";
            else if (videoComboBox.SelectedItem == "Microsoft MPEG-4 Version 1")
                Video = "msmpeg4";
            else if (videoComboBox.SelectedItem == "Microsoft MPEG-4 Version 2")
                Video = "msmpeg4v2";
            else if (videoComboBox.SelectedItem == "Microsoft MPEG-4 Version 3")
                Video = "msmpeg4";
            else if (videoComboBox.SelectedItem == "Windows Media Video 7")
                Video = "wmv1";
            else if (videoComboBox.SelectedItem == "Windows Media Video 8")
                Video = "wmv2";
            else if (videoComboBox.SelectedItem == "H.261")
                Video = "h261";
            else if (videoComboBox.SelectedItem == "H.263")
                Video = "h263";
            else if (videoComboBox.SelectedItem == "H.264")
                Video = "libx264";
            else if (videoComboBox.SelectedItem == "Real Video 1.0")
                Video = "rv10";
            else if (videoComboBox.SelectedItem == "Real Video 2.0")
                Video = "rv20";
            else if (videoComboBox.SelectedItem == "Motion JPEG")
                Video = "mjpeg";
            else if (videoComboBox.SelectedItem == "Motion JPEG (Lossless)")
                Video = "ljpeg";
            else if (videoComboBox.SelectedItem == "JPEG-LS")
                Video = "jpegls";
            else if (videoComboBox.SelectedItem == "DV")
                Video = "dvvideo";
            else if (videoComboBox.SelectedItem == "HuffYUV")
                Video = "huffyuv";
            else if (videoComboBox.SelectedItem == "FFmpeg Video 1")
                Video = "ffv1";
            else if (videoComboBox.SelectedItem == "Snow")
                Video = "snow";
            else if (videoComboBox.SelectedItem == "Asus Version 1")
                Video = "asv1";
            else if (videoComboBox.SelectedItem == "Asus Version 2")
                Video = "asv2";
            else if (videoComboBox.SelectedItem == "Sorenson Video 1")
                Video = "svq1";
            else if (videoComboBox.SelectedItem == "Ogg Theora")
                Video = "libtheora";
            else if (videoComboBox.SelectedItem == "Flash Video")
                Video = "flv";
            else if (videoComboBox.SelectedItem == "Flash Screen Video")
                Video = "flashsv";
            else if (videoComboBox.SelectedItem == "Id RoQ")
                Video = "roqvideo";
            else if (videoComboBox.SelectedItem == "Apple Animation")
                Video = "qtrle";
            else if (videoComboBox.SelectedItem == "ZLIB")
                Video = "zlib";
            else if (videoComboBox.SelectedItem == "ZMBV")
                Video = "zmbv";
            else if (videoComboBox.SelectedItem == "AVID DNxHD")
                Video = "dnxhd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced video encoding options are not available in this version of SmoothTranscode.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void audioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (audioComboBox.SelectedItem == "MP2")
                Audio = "mp2";
            else if (audioComboBox.SelectedItem == "MP3")
                Audio = "libmp3lame";
            else if (audioComboBox.SelectedItem == "AAC")
                Audio = "aac -strict experimental";
            else if (audioComboBox.SelectedItem == "AC3")
                Audio = "ac3";
            else if (audioComboBox.SelectedItem == "Vorbis")
                Audio = "vorbis";
            else if (audioComboBox.SelectedItem == "Windows Media Audio Version 1")
                Audio = "wmav1";
            else if (audioComboBox.SelectedItem == "Windows Media Audio Version 2")
                Audio = "wmav2";
            else if (audioComboBox.SelectedItem == "FLAC Lossless")
                Audio = "flac";
            else if (audioComboBox.SelectedItem == "Sonic")
                Audio = "sonic";
            else if (audioComboBox.SelectedItem == "Microsoft ADPCM")
                Audio = "adpcm_ms";
            else if (audioComboBox.SelectedItem == "Microsoft IMA ADPCM")
                Audio = "adpcm_ima_wav";
            else if (audioComboBox.SelectedItem == "Quicktime IMA ADPCM")
                Audio = "adpcm_ima_qt";
            else if (audioComboBox.SelectedItem == "G.726 ADPCM")
                Audio = "g726";
            else if (audioComboBox.SelectedItem == "CRI ADX PCM")
                Audio = "adpcm_adx";
            else if (audioComboBox.SelectedItem == "Id RoQ DPCM")
                Audio = "roq_dpcm";
        }
        #endregion

        #region Output Setup Tab
        private void outputButton_Click(object sender, EventArgs e)
        {
            outputFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            outputFileDialog.FileName = "";
            outputFileDialog.Filter = "MPEG Video (*.mpg;*.mpeg;*.ps)|*.mpg;*.mpeg;*.ps|MPEG-4 Video (*.mp4)|*.mp4|Windows Media Video (*.wmv,*.asf)|*.wmv,*.asf|WebM (*.webm)|*.webm|Matroska (*.mkv;*.mka;*.mks)|*.mkv;*.mka;*.mks|Windows Video (*.avi)|*.avi|Flash Video (*.flv)|*.flv|DivX (*.divx)|*.divx|XviD (*.xvid)|*.xvid|Real Media (*.rm)|*.rm|Quicktime Video (*.mov)|*.mov|Mobile Video (*.3gp;*.3g2)|*.3gp;*.3g2|Motion JPEG (*.mjp;*.mjpg)|*.mjp;*.mjpg|Any file|*.*";
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
                Arguments += " -ab " + audioTextBox.Text;
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
