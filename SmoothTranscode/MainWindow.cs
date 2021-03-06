﻿/*
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
using Help;

namespace SmoothTranscode
{
    public partial class MainWindow : Form
    {
        private string Video = String.Empty;
        private string Audio = String.Empty;
        private string Format = String.Empty;
        private string Advanced = String.Empty;
        private string VideoFilters = String.Empty;
        private string Arguments;
        private string fps;
        private bool videoPresent;
        private bool resolutionChanged = false;
        private decimal aspectRatio;
        X264Window advancedX264Window = new X264Window();
        VP8Window advancedVP8Window = new VP8Window();
        ffprobe ffmpegInfo = new ffprobe();

        #region Form Open Events
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
            // Default Combo Box Values
            deinterlacingComboBox.SelectedIndex = 0; // Off
            scalingComboBox.SelectedIndex = 1; // Fast Bilinear
            denoiseComboBox.SelectedIndex = 0; // Off
            deblockingComboBox.SelectedIndex = 0; //Off
            // Set bold fonts
            videoInfoLabel.Font = new Font(videoInfoLabel.Font.FontFamily, videoInfoLabel.Font.Size, FontStyle.Bold);
            audioInfoLabel.Font = new Font(audioInfoLabel.Font.FontFamily, audioInfoLabel.Font.Size, FontStyle.Bold);
            // Set info event handlers
            ffmpegInfo.infoRetrieved += new ffprobe.InfoEventHandler(UpdateInfo);
        }
        #endregion

        #region Drag Events
        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            // Allows files to be dragged onto the window
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
                DropTargetHelper.DragEnter(this, e.Data, Cursor.Position, e.Effect, "Open with %1", "SmoothTranscode");
            }
            else
            {
                e.Effect = DragDropEffects.None;
                DropTargetHelper.DragEnter(this, e.Data, Cursor.Position, e.Effect);
            }
        }

        private void MainWindow_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            DropTargetHelper.DragOver(Cursor.Position, e.Effect);
        }

        private void MainWindow_DragLeave(object sender, EventArgs e)
        {
            DropTargetHelper.DragLeave();
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            DropTargetHelper.Drop(e.Data, Cursor.Position, e.Effect);

            if (e.Effect == DragDropEffects.Copy)
            {
                // Places the filename of dropped files into the input text box
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                inputTextBox.Text = files[0];
                ffmpeg.inputFile = inputTextBox.Text;
                ffmpegInfo.GetInfo(inputTextBox.Text);
            }
        }
        #endregion

        #region Button Clicks
        private void aboutButton_Click(object sender, EventArgs e)
        {
            // Opens the about window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            // Sets contents URL for the help window
            Help.Config.url = "http://www.atomicwasteland.co.uk/support/smoothtranscode/";
            // Opens the help window
            Help.MainWindow helpWindow = new Help.MainWindow();
            helpWindow.Show();
        }
        #endregion

        #region Input Tab
        private void inputButton_Click(object sender, EventArgs e)
        {
            // If file selected, place filename in the input text box
            if (inputFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                
                inputTextBox.Text = inputFileDialog.FileName;
                ffmpeg.inputFile = inputTextBox.Text;
                ffmpegInfo.GetInfo(inputTextBox.Text);
            }
        }

        private void UpdateInfo(object sender, ffprobe.InfoEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                formatInfoLabel.Text = "Format: " + e.format();
                if (e.frameRate() != "90000") // If not album art
                {
                    videoCodecInfoLabel.Text = "Codec: " + e.videoCodec();
                    if (e.videoCodec() != String.Empty)
                    {
                        videoPresent = true;
                        containerComboBox.SelectedIndex = 0; // Default to MPEG4
                    }
                    else
                    {
                        videoPresent = false;
                        containerComboBox.SelectedIndex = 15; // Default to MP3
                    }
                    if (e.width() != String.Empty)
                        resInfoLabel.Text = "Resolution: " + e.width() + "x" + e.height();
                    else
                        resInfoLabel.Text = "Resolution:";
                    resolutionChanged = true;
                    widthTextBox.Text = e.width();
                    heightTextBox.Text = e.height();
                    resolutionChanged = false;
                    aspectInfoLabel.Text = "Aspect Ratio: " + e.aspectRatio();
                    aspectComboBox.Text = e.aspectRatio();
                    if (e.frameRate() != "0")
                    {
                        fpsInfoLabel.Text = "Frame Rate: " + e.frameRate() + " frames per second";
                        frameRateComboBox.Text = e.frameRate();
                    }
                    else
                    {
                        fpsInfoLabel.Text = "Frame Rate:";
                        frameRateComboBox.Text = String.Empty;
                    }
                    fps = e.frameRate();
                }
                else
                {
                    videoPresent = false;
                    containerComboBox.SelectedIndex = 15; // Default to MP3
                    videoCodecInfoLabel.Text = "Codec: ";
                    resInfoLabel.Text = "Resolution: ";
                    resolutionChanged = true;
                    widthTextBox.Text = String.Empty;
                    heightTextBox.Text = String.Empty;
                    resolutionChanged = false;
                    aspectInfoLabel.Text = "Aspect Ratio: ";
                    aspectComboBox.Text = String.Empty;
                    fpsInfoLabel.Text = "Frame Rate:";
                    frameRateComboBox.Text = String.Empty;
                }
                audioCodecInfoLabel.Text = "Codec: " + e.audioCodec();
                if (e.audioCodec() != String.Empty)
                    audioCheckBox.Enabled = true;
                else
                    audioCheckBox.Enabled = false;
                channelsInfoLabel.Text = "Channels: " + e.channels();
                channelsComboBox.Text = e.channels();
                if (e.sampleRate() != String.Empty)
                    sampleInfoLabel.Text = "Sample Rate: " + e.sampleRate() + " Hz";
                else
                    sampleInfoLabel.Text = "Sample Rate: ";
                sampleComboBox.Text = e.sampleRate();
                titleTextBox.Text = e.metadataTitle();
                authorTextBox.Text = e.metadataArtist();
                albumTextBox.Text = e.metadataAlbum();
                copyrightTextBox.Text = e.metadataCopyright();
                commentTextBox.Text = e.metadataComment();
            });
        }

        // Sets container to selected option and updates codec lists to valid options
        private void containerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            advancedButton.Enabled = false; // Disable advanced button if enabled
            if (containerComboBox.SelectedItem.ToString() == "MPEG-4")
            {
                Format = "mp4";
                outputFileDialog.Filter = "MP4 Video (*.mp4; *.m4v)|*.mp4;*.m4v|Any file|*.*";
                videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264", "MPEG-4", "MPEG-2", "Dirac" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "AAC", "AC3", "E-AC3", "Apple Lossless Audio Codec" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "MPEG")
            {
                Format = "mpeg";
                outputFileDialog.Filter = "MPEG Video (*.mpg; *.mpeg; *.ps)|*.mpg;*.mpeg;*.ps|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "MPEG-2", "MPEG-1" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "MP2" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Windows Media")
            {
                Format = "asf";
                outputFileDialog.Filter = "Windows Media (*.wmv; *.wma; *.asf)|*.wmv;*.wma;*.asf|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "Windows Media Video 8", "Windows Media Video 7", "MPEG-2" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "Windows Media Audio Version 2", "Windows Media Audio Version 1", "MP3" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Flash Video")
            {
                Format = "flv";
                outputFileDialog.Filter = "Flash Video (*.flv)|*.flv|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264", "Flash Video (Sorenson Spark)" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "AAC", "Nellymoser" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "WebM")
            {
                Format = "webm";
                outputFileDialog.Filter = "WebM (*.webm)|*.webm|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "VP8" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "Ogg Vorbis" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Matroska")
            {
                Format = "matroska";
                outputFileDialog.Filter = "Matroska (*.mkv; *.mka)|*.mkv;*.mka|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264", "MPEG-4", "MPEG-2", "XviD", "VP8", "Ogg Theora", "Dirac" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "MP2", "AAC", "AC3", "E-AC3", "Ogg Vorbis", "FLAC" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Ogg")
            {
                Format = "ogg";
                outputFileDialog.Filter = "Ogg (*.ogg; *.ogv; *.oga)|*.ogg;*.ogv;*.oga|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "Ogg Theora", "Dirac" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "Ogg Vorbis", "FLAC" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "AVI")
            {
                Format = "avi";
                outputFileDialog.Filter = "AVI (*.avi)|*.avi|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "XviD", "H.264", "MPEG-4", "MPEG-2", "Dirac" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "MP2", "AAC", "AC3", "E-AC3" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Real Media")
            {
                Format = "rm";
                outputFileDialog.Filter = "Real Media (*.rm; *.rv; *.ra)|*.rm;*.rv;*.ra|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "Real Video 2.0", "Real Video 1.0" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "Real Audio Version 1", "AAC", "Ogg Vorbis" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Quicktime Video")
            {
                Format = "mov";
                outputFileDialog.Filter = "Quicktime Video (*.mov)|*.mov|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3", "AAC", "Apple Lossless Audio Codec" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "DVD VOB")
            {
                Format = "dvd";
                outputFileDialog.Filter = "DVD VOB (*.vob)|*.vob|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "MPEG-2" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP2", "AC3", "E-AC3" });
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = false;
                commentTextBox.Enabled = false;
            }
            else if (containerComboBox.SelectedItem.ToString() == "DV Video")
            {
                Format = "dv";
                outputFileDialog.Filter = "DV Video (*.dv)|*.dv|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "DV Video" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP2" });
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = false;
                commentTextBox.Enabled = false;
            }
            else if (containerComboBox.SelectedItem.ToString() == "3GP")
            {
                Format = "3gp";
                outputFileDialog.Filter = "Mobile Video (*.3gp)|*.3gp|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264", "H.263" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "AAC" });
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = false;
                commentTextBox.Enabled = false;
            }
            else if (containerComboBox.SelectedItem.ToString() == "Material eXchange Format")
            {
                Format = "mxf";
                outputFileDialog.Filter = "Material eXchange Format (*.mxf)|*.mxf|Any file|*.*";
                if (videoPresent)
                    videoCheckBox.Enabled = true;
                videoComboBox.Items.Clear();
                videoComboBox.Items.AddRange(new string[] { "H.264", "MPEG-4", "MPEG-2", "DV Video", "Dirac", "AVID DNxHD" });
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP2", "AAC", "AC3", "E-AC3", "MP3" });
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = false;
                commentTextBox.Enabled = false;
            }
            else if (containerComboBox.SelectedItem.ToString() == "MP3")
            {
                Format = "mp3";
                outputFileDialog.Filter = "MP3 Audio (*.mp3)|*.mp3|Any file|*.*";
                videoCheckBox.Enabled = false;
                videoComboBox.Items.Clear();
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP3" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = true;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "MP2")
            {
                Format = "mp2";
                outputFileDialog.Filter = "MP2 Audio (*.mp2)|*.mp2|Any file|*.*";
                videoCheckBox.Enabled = false;
                videoComboBox.Items.Clear();
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "MP2" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = true;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "AAC")
            {
                Format = "mp3";
                outputFileDialog.Filter = "AAC Audio (*.m4a; *.aac)|*.m4a;*.aac|Any file|*.*";
                videoCheckBox.Enabled = false;
                videoComboBox.Items.Clear();
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "AAC" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = true;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "FLAC")
            {
                Format = "flac";
                outputFileDialog.Filter = "FLAC Audio (*.flac)|*.flac|Any file|*.*";
                videoCheckBox.Enabled = false;
                videoComboBox.Items.Clear();
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "FLAC" });
                titleTextBox.Enabled = true;
                authorTextBox.Enabled = true;
                albumTextBox.Enabled = true;
                copyrightTextBox.Enabled = true;
                commentTextBox.Enabled = true;
            }
            else if (containerComboBox.SelectedItem.ToString() == "WAV")
            {
                Format = "wav";
                outputFileDialog.Filter = "WAV Audio (*.wav)|*.wav|Any file|*.*";
                videoCheckBox.Enabled = false;
                videoComboBox.Items.Clear();
                audioComboBox.Items.Clear();
                audioComboBox.Items.AddRange(new string[] { "PCM 16bit", "PCM 24bit", "PCM 32bit" });
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                albumTextBox.Enabled = false;
                copyrightTextBox.Enabled = false;
                commentTextBox.Enabled = false;
            }
            if (videoComboBox.Items.Count > 0)
                videoComboBox.SelectedIndex = 0;
            audioComboBox.SelectedIndex = 0;
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
                if (videoComboBox.SelectedIndex != -1 && (videoComboBox.SelectedItem.ToString() == "H.264" || videoComboBox.SelectedItem.ToString() == "VP8"))
                    advancedButton.Enabled = true;
                videoBitratePanel.Enabled = true;
                resolutionSeperator.Enabled = true;
                resolutionLabel.Enabled = true;
                widthTextBox.Enabled = true;
                xLabel.Enabled = true;
                heightTextBox.Enabled = true;
                pixelsLabel.Enabled = true;
                maintainAspectCheckBox.Enabled = true;
                aspectLabel.Enabled = true;
                aspectComboBox.Enabled = true;
                frameRateLabel.Enabled = true;
                frameRateComboBox.Enabled = true;
                interlaceCheckBox.Enabled = true;
                if (vbrRadioButton.Checked || cbrRadioButton.Checked)
                    twoPassCheckBox.Enabled = true;
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
                maintainAspectCheckBox.Enabled = false;
                aspectLabel.Enabled = false;
                aspectComboBox.Enabled = false;
                frameRateLabel.Enabled = false;
                frameRateComboBox.Enabled = false;
                interlaceCheckBox.Enabled = false;
                twoPassCheckBox.Enabled = false;
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
            twoPassCheckBox.Enabled = false;
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
            twoPassCheckBox.Enabled = true;
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
            twoPassCheckBox.Enabled = true;
        }

        // Sets video codec to selected option and enables or disables advanced options
        private void videoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoComboBox.SelectedItem.ToString() == "MPEG-4")
            {
                Video = "mpeg4";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "MPEG-2")
            {
                Video = "mpeg2video";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "MPEG-1")
            {
                Video = "mpeg1video";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "H.264")
            {
                Video = "libx264";
                advancedButton.Enabled = true;
            }
            else if (videoComboBox.SelectedItem.ToString() == "H.263")
            {
                Video = "h263";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Windows Media Video 8")
            {
                Video = "wmv2";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Windows Media Video 7")
            {
                Video = "wmv1";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Flash Video (Sorenson Spark)")
            {
                Video = "flv";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "VP8")
            {
                Video = "libvpx";
                advancedButton.Enabled = true;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Real Video 2.0")
            {
                Video = "rv20";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Real Video 1.0")
            {
                Video = "rv10";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Ogg Theora")
            {
                Video = "libtheora";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "DV")
            {
                Video = "dvvideo";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "XviD")
            {
                Video = "libxvid";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "Dirac")
            {
                Video = "libschroedinger";
                advancedButton.Enabled = false;
            }
            else if (videoComboBox.SelectedItem.ToString() == "AVID DNxHD")
            {
                Video = "dnxhd";
                advancedButton.Enabled = false;
            }
        }

        // Show advanced options dialog for the selected codec
        private void advancedButton_Click(object sender, EventArgs e)
        {
            if (videoComboBox.SelectedItem.ToString() == "H.264")
            {
                if (advancedX264Window.ShowDialog() == DialogResult.OK)
                    Advanced = advancedX264Window.AdvancedArguments;
            }
            else if (videoComboBox.SelectedItem.ToString() == "VP8")
                if (advancedVP8Window.ShowDialog() == DialogResult.OK)
                    Advanced = advancedVP8Window.AdvancedArguments;
        }

        private void resolutionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maintainAspectCheckBox.Checked && !resolutionChanged)
            {
                resolutionChanged = true;
                if (widthTextBox.Text != String.Empty)
                    heightTextBox.Text = Convert.ToInt32(Convert.ToDecimal(widthTextBox.Text) / aspectRatio).ToString();
                else
                    heightTextBox.Text = "0";
                resolutionChanged = false;
            }
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maintainAspectCheckBox.Checked && !resolutionChanged)
            {
                resolutionChanged = true;
                if (heightTextBox.Text != String.Empty)
                    widthTextBox.Text = Convert.ToInt32(Convert.ToDecimal(heightTextBox.Text) * aspectRatio).ToString();
                else
                    widthTextBox.Text = "0";
                resolutionChanged = false;
            }
        }

        private void maintainAspectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maintainAspectCheckBox.Checked)
            {
                if ((widthTextBox.Text != String.Empty && widthTextBox.Text != "0") || (heightTextBox.Text != String.Empty && heightTextBox.Text != "0"))
                    aspectRatio = Convert.ToDecimal(widthTextBox.Text) / Convert.ToDecimal(heightTextBox.Text);
                else
                    aspectRatio = 1;
            }
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
            if (audioComboBox.SelectedItem.ToString() == "MP3")
            {
                Audio = "libmp3lame";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "MP2")
            {
                Audio = "mp2";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "AAC")
            {
                Audio = "aac -strict experimental";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "AC3")
            {
                Audio = "ac3";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "E-AC3")
            {
                Audio = "eac3";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Ogg Vorbis")
            {
                Audio = "vorbis";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Windows Media Audio Version 2")
            {
                Audio = "wmav2";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Windows Media Audio Version 1")
            {
                Audio = "wmav1";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Real Audio Version 1")
            {
                Audio = "real_114";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "FLAC")
            {
                Audio = "flac";
                audioBitratePanel.Enabled = false;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Apple Lossless Audio Codec")
            {
                Audio = "alac";
                audioBitratePanel.Enabled = false;
            }
            else if (audioComboBox.SelectedItem.ToString() == "Nellymoser")
            {
                Audio = "nellymoser";
                audioBitratePanel.Enabled = true;
            }
            else if (audioComboBox.SelectedItem.ToString() == "PCM 16bit")
            {
                Audio = "pcm_s16le";
                audioBitratePanel.Enabled = false;
            }
            else if (audioComboBox.SelectedItem.ToString() == "PCM 24bit")
            {
                Audio = "pcm_s24le";
                audioBitratePanel.Enabled = false;
            }
            else if (audioComboBox.SelectedItem.ToString() == "PCM 32bit")
            {
                Audio = "pcm_s32le";
                audioBitratePanel.Enabled = false;
            }
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

        #region Convert Button
        private void addVideoFilter(string vf)
        {
            if (VideoFilters == String.Empty)
                VideoFilters = vf;
            else
                VideoFilters += "," + vf;
        }
        
        private void convertButton_Click(object sender, EventArgs e)
        {
            // Checks input and output files are specified
            if (inputTextBox.Text == String.Empty || outputTextBox.Text == String.Empty)
            {
                MessageBox.Show("You need to set both the input and output file fields.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancel conversion
            }
            // Checks at least one output is selected
            if ((!audioCheckBox.Checked || !audioCheckBox.Enabled) && (!videoCheckBox.Checked || !videoCheckBox.Enabled))
            {
                MessageBox.Show("Both audio and video are disabled. Please select at least one output.", "Unable to Convert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Clear any existing arguments
            Arguments = "";
            VideoFilters = String.Empty;
            if (Format != String.Empty)
                Arguments += "-f " + Format;
            // Video tab
            if (videoCheckBox.Enabled && videoCheckBox.Checked) // If video enabled
            {
                if (Video != String.Empty)
                    Arguments += " -vcodec " + Video;
                if (sameQualRadioButton.Checked)
                    Arguments += " -same_quant";
                if (vbrRadioButton.Checked)
                {
                    Arguments += " -b:v " + vbrTextBox.Text + "k";
                    if (vbrMinTextBox.Text != String.Empty)
                        Arguments += " -minrate " + vbrMinTextBox.Text + "k";
                    if (vbrMaxTextBox.Text != String.Empty)
                        Arguments += " -maxrate " + vbrMaxTextBox.Text + "k";
                    if (vbrBufferTextBox.Text != String.Empty)
                        Arguments += " -bufsize " + vbrBufferTextBox.Text + "k";
                }
                if (cbrRadioButton.Checked)
                {
                    Arguments += " -b:v " + cbrTextBox.Text + "k";
                    Arguments += " -bufsize " + (Convert.ToInt16(cbrTextBox.Text) / 4) + "k";
                    Arguments += " -minrate " + cbrTextBox.Text + "k";
                    Arguments += " -maxrate " + cbrTextBox.Text + "k";
                }
                if (aspectComboBox.Text != String.Empty)
                    Arguments += " -aspect " + aspectComboBox.Text;
                if (frameRateComboBox.Text != String.Empty)
                    Arguments += " -r " + frameRateComboBox.Text;
                if (interlaceCheckBox.Checked)
                    Arguments += " -flags +ilme+ildct";
                if (Advanced != String.Empty)
                    Arguments += " " + Advanced;
            }
            else // Else disable video recording
                Arguments += " -vn";
            // Post Processing Tab
            if (deinterlacingComboBox.SelectedItem.ToString() == "Yadif")
                addVideoFilter("yadif=0:-1:0");
            else if (deinterlacingComboBox.SelectedItem.ToString() == "Yadif (Double Framerate)")
                addVideoFilter("yadif=1:-1:0");
            else if (deinterlacingComboBox.SelectedItem.ToString() == "MCDeint (Double Framerate)")
                addVideoFilter("yadif=1:-1:0,mp=mcdeint=2:1:10");
            if (scalingComboBox.SelectedItem.ToString() == "Nearest Neighbor")
                Arguments += " -sws_flags neighbor";
            else if (scalingComboBox.SelectedItem.ToString() == "Bilinear")
                Arguments += " -sws_flags bilinear";
            else if (scalingComboBox.SelectedItem.ToString() == "Bicubic")
                Arguments += " -sws_flags bicubic";
            else if (scalingComboBox.SelectedItem.ToString() == "Sinc")
                Arguments += " -sws_flags sinc";
            else if (scalingComboBox.SelectedItem.ToString() == "Lanczos")
                Arguments += " -sws_flags lanczos";
            else if (scalingComboBox.SelectedItem.ToString() == "Spline")
                Arguments += " -sws_flags spline";
            if (denoiseComboBox.SelectedItem.ToString() == "Weak")
                addVideoFilter("hqdn3d=2:1:2:3");
            else if (denoiseComboBox.SelectedItem.ToString() == "Medium")
                addVideoFilter("hqdn3d=3:2:2:3");
            else if (denoiseComboBox.SelectedItem.ToString() == "Strong")
                addVideoFilter("hqdn3d=7:7:5:5");
            if (deblockingComboBox.SelectedItem.ToString() == "On")
                addVideoFilter("mp=pp7");
            // Audio Tab
            if (audioCheckBox.Enabled && audioCheckBox.Checked) // If audio enabled
            {
                if (Audio != String.Empty)
                    Arguments += " -acodec " + Audio;
                if (channelsComboBox.Text != String.Empty)
                    Arguments += " -ac " + channelsComboBox.Text;
                if (audioBitrateRadioButton.Checked && audioBitratePanel.Enabled)
                {
                    if (audioBitrateTextBox.Text != String.Empty)
                        Arguments += " -b:a " + audioBitrateTextBox.Text + "k";
                }
                if (audioQualRadioButton.Checked && audioBitratePanel.Enabled)
                {
                    if (audioQualTextBox.Text != String.Empty)
                        Arguments += " -aq " + audioQualTextBox.Text;
                }
                if (sampleComboBox.Text != String.Empty)
                    Arguments += " -ar " + sampleComboBox.Text;
            }
            else // Else disable audio recording
                Arguments += " -an";
            // Crop and Pad tab
            if (cropTopUpDown.Value > 0 || cropLeftUpDown.Value > 0 || cropRightUpDown.Value > 0 || cropBottomUpDown.Value > 0)
                addVideoFilter("crop=in_w-" + (cropLeftUpDown.Value + cropRightUpDown.Value).ToString() + ":in_h-" + (cropTopUpDown.Value + cropBottomUpDown.Value).ToString() + ":" + cropLeftUpDown.Value.ToString() + ":" + cropTopUpDown.Value.ToString());
            if (padTopUpDown.Value > 0 || padLeftUpDown.Value > 0 || padRightUpDown.Value > 0 || padBottomUpDown.Value > 0)
                addVideoFilter("pad=in_w+" + (padLeftUpDown.Value + padRightUpDown.Value).ToString() + ":in_h+" + (padTopUpDown.Value + padBottomUpDown.Value).ToString() + ":" + padLeftUpDown.Value.ToString() + ":" + padTopUpDown.Value.ToString() + ":0x" + padColourComboBox.SelectedColor.R.ToString("X2") + padColourComboBox.SelectedColor.G.ToString("X2") + padColourComboBox.SelectedColor.B.ToString("X2"));
            // Add Video Filters from Video, Post Processing, Pad and Crop
            if (widthTextBox.Text != String.Empty && heightTextBox.Text != String.Empty)
                addVideoFilter("scale=" + widthTextBox.Text + ":" + heightTextBox.Text + ":interl=-1");
            if (fps != "" && frameRateComboBox.Text != String.Empty)
                if ((Convert.ToSingle(frameRateComboBox.Text) == (Convert.ToSingle(fps) / 2)) && interlaceCheckBox.Checked)
                    addVideoFilter("tinterlace=4");
            if (VideoFilters != String.Empty && videoPresent)
                Arguments += " -vf \"" + VideoFilters + "\"";
            // Trim tab
            if (trimStartTextBox.Text != String.Empty)
            {
                Arguments += " -ss " + trimStartTextBox.Text;
                ffmpeg.trimStart = new TimeSpan(0, 0, Convert.ToInt16(trimStartTextBox.Text));
            }
            if (trimEndTextBox.Text != String.Empty)
            {
                Arguments += " -t " + trimEndTextBox.Text;
                ffmpeg.trimLength = new TimeSpan(0, 0, Convert.ToInt16(trimEndTextBox.Text));
            }
            // Meta data tab
            if (titleTextBox.Text != String.Empty && titleTextBox.Enabled)
                Arguments += " -metadata title=\"" + titleTextBox.Text + "\"";
            if (authorTextBox.Text != String.Empty && authorTextBox.Enabled)
                Arguments += " -metadata artist=\"" + authorTextBox.Text + "\"";
            if (authorTextBox.Text != String.Empty && authorTextBox.Enabled)
                Arguments += " -metadata album=\"" + albumTextBox.Text + "\"";
            if (copyrightTextBox.Text != String.Empty && copyrightTextBox.Enabled)
                Arguments += " -metadata copyright=\"" + copyrightTextBox.Text + "\"";
            if (commentTextBox.Text != String.Empty && commentTextBox.Enabled)
                Arguments += " -metadata comment=\"" + commentTextBox.Text + "\"";
            //Output tab
            ffmpeg.outputFile = outputTextBox.Text;
            if (twoPassCheckBox.Enabled && twoPassCheckBox.Checked)
                ffmpeg.twoPass = true;
            else
                ffmpeg.twoPass = false;

            // Pass arguments to FFmpeg
            ffmpeg.procArguments = Arguments;
            // Open progress window to start conversion
            ProgressWindow progressWindow = new ProgressWindow();
            progressWindow.ShowDialog();
        }
        #endregion
    }
}