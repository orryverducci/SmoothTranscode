namespace SmoothTranscode
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.convertButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.inputTab = new System.Windows.Forms.TabPage();
            this.containerComboBox = new System.Windows.Forms.ComboBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.videoTab = new System.Windows.Forms.TabPage();
            this.frameRateComboBox = new System.Windows.Forms.ComboBox();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.deinterlaceCheckBox = new System.Windows.Forms.CheckBox();
            this.aspectComboBox = new System.Windows.Forms.ComboBox();
            this.pixelsLabel = new System.Windows.Forms.Label();
            this.aspectLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.videoBitratePanel = new System.Windows.Forms.Panel();
            this.vbrBufferTextBox = new System.Windows.Forms.TextBox();
            this.vbrBufferLabel = new System.Windows.Forms.Label();
            this.vbrMaxTextBox = new System.Windows.Forms.TextBox();
            this.vbrMaxLabel = new System.Windows.Forms.Label();
            this.vbrMinLabel = new System.Windows.Forms.Label();
            this.vbrMinTextBox = new System.Windows.Forms.TextBox();
            this.vbrOptionalLabel = new System.Windows.Forms.Label();
            this.vbrTextBox = new System.Windows.Forms.TextBox();
            this.vbrKbpsLabel = new System.Windows.Forms.Label();
            this.vbrRadioButton = new System.Windows.Forms.RadioButton();
            this.cbrRadioButton = new System.Windows.Forms.RadioButton();
            this.sameQualRadioButton = new System.Windows.Forms.RadioButton();
            this.cbrTextBox = new System.Windows.Forms.TextBox();
            this.cbrLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.videoComboBox = new System.Windows.Forms.ComboBox();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.videoCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedButton = new System.Windows.Forms.Button();
            this.videoCodecLabel = new System.Windows.Forms.Label();
            this.audioTab = new System.Windows.Forms.TabPage();
            this.sampleComboBox = new System.Windows.Forms.ComboBox();
            this.sampleLabel = new System.Windows.Forms.Label();
            this.channelsComboBox = new System.Windows.Forms.ComboBox();
            this.audioBitratePanel = new System.Windows.Forms.Panel();
            this.audioQualTextBox = new System.Windows.Forms.TextBox();
            this.audioQualRadioButton = new System.Windows.Forms.RadioButton();
            this.audioBitrateTextBox = new System.Windows.Forms.TextBox();
            this.audioBitrateRadioButton = new System.Windows.Forms.RadioButton();
            this.audioKbpsLabel = new System.Windows.Forms.Label();
            this.audioCheckBox = new System.Windows.Forms.CheckBox();
            this.channelsLabel = new System.Windows.Forms.Label();
            this.audioCodecLabel = new System.Windows.Forms.Label();
            this.audioComboBox = new System.Windows.Forms.ComboBox();
            this.cropTab = new System.Windows.Forms.TabPage();
            this.cropLeftGroupBox = new System.Windows.Forms.GroupBox();
            this.cropLeftUpDown = new System.Windows.Forms.NumericUpDown();
            this.cropRightGroupBox = new System.Windows.Forms.GroupBox();
            this.cropRightUpDown = new System.Windows.Forms.NumericUpDown();
            this.cropBottomGroupBox = new System.Windows.Forms.GroupBox();
            this.cropBottomUpDown = new System.Windows.Forms.NumericUpDown();
            this.cropTopGroupBox = new System.Windows.Forms.GroupBox();
            this.cropTopUpDown = new System.Windows.Forms.NumericUpDown();
            this.padTab = new System.Windows.Forms.TabPage();
            this.padBottomGroupBox = new System.Windows.Forms.GroupBox();
            this.padBottomUpDown = new System.Windows.Forms.NumericUpDown();
            this.padRightGroupBox = new System.Windows.Forms.GroupBox();
            this.padRightUpDown = new System.Windows.Forms.NumericUpDown();
            this.padLeftGroupBox = new System.Windows.Forms.GroupBox();
            this.padLeftUpDown = new System.Windows.Forms.NumericUpDown();
            this.padTopGroupBox = new System.Windows.Forms.GroupBox();
            this.padTopUpDown = new System.Windows.Forms.NumericUpDown();
            this.metadataTab = new System.Windows.Forms.TabPage();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.copyrightTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.outputButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.helpButton = new System.Windows.Forms.Button();
            this.outputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.formatSeperator = new SmoothTranscode.Seperator();
            this.resolutionSeperator = new SmoothTranscode.Seperator();
            this.codecSeperator = new SmoothTranscode.Seperator();
            this.channelsSeperator = new SmoothTranscode.Seperator();
            this.commentSeperator = new SmoothTranscode.Seperator();
            this.copyrightSeperator = new SmoothTranscode.Seperator();
            this.authorSeperator = new SmoothTranscode.Seperator();
            this.titleSeperator = new SmoothTranscode.Seperator();
            this.processingTab = new System.Windows.Forms.TabPage();
            this.deinterlacingLabel = new System.Windows.Forms.Label();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.denoiseLabel = new System.Windows.Forms.Label();
            this.deinterlacingComboBox = new System.Windows.Forms.ComboBox();
            this.scalingComboBox = new System.Windows.Forms.ComboBox();
            this.denoiseComboBox = new System.Windows.Forms.ComboBox();
            this.mainTabs.SuspendLayout();
            this.inputTab.SuspendLayout();
            this.videoTab.SuspendLayout();
            this.videoBitratePanel.SuspendLayout();
            this.audioTab.SuspendLayout();
            this.audioBitratePanel.SuspendLayout();
            this.cropTab.SuspendLayout();
            this.cropLeftGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cropLeftUpDown)).BeginInit();
            this.cropRightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cropRightUpDown)).BeginInit();
            this.cropBottomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cropBottomUpDown)).BeginInit();
            this.cropTopGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cropTopUpDown)).BeginInit();
            this.padTab.SuspendLayout();
            this.padBottomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.padBottomUpDown)).BeginInit();
            this.padRightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.padRightUpDown)).BeginInit();
            this.padLeftGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.padLeftUpDown)).BeginInit();
            this.padTopGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.padTopUpDown)).BeginInit();
            this.metadataTab.SuspendLayout();
            this.outputTab.SuspendLayout();
            this.processingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // convertButton
            // 
            this.convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.convertButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.convertButton.Location = new System.Drawing.Point(496, 410);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(88, 25);
            this.convertButton.TabIndex = 1;
            this.convertButton.Text = "&Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.aboutButton.Location = new System.Drawing.Point(8, 410);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(88, 25);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "&About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // mainTabs
            // 
            this.mainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabs.Controls.Add(this.inputTab);
            this.mainTabs.Controls.Add(this.videoTab);
            this.mainTabs.Controls.Add(this.processingTab);
            this.mainTabs.Controls.Add(this.audioTab);
            this.mainTabs.Controls.Add(this.cropTab);
            this.mainTabs.Controls.Add(this.padTab);
            this.mainTabs.Controls.Add(this.metadataTab);
            this.mainTabs.Controls.Add(this.outputTab);
            this.mainTabs.Location = new System.Drawing.Point(9, 12);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(576, 388);
            this.mainTabs.TabIndex = 0;
            // 
            // inputTab
            // 
            this.inputTab.Controls.Add(this.containerComboBox);
            this.inputTab.Controls.Add(this.formatSeperator);
            this.inputTab.Controls.Add(this.inputButton);
            this.inputTab.Controls.Add(this.inputTextBox);
            this.inputTab.Location = new System.Drawing.Point(4, 22);
            this.inputTab.Name = "inputTab";
            this.inputTab.Padding = new System.Windows.Forms.Padding(3);
            this.inputTab.Size = new System.Drawing.Size(568, 362);
            this.inputTab.TabIndex = 0;
            this.inputTab.Text = "Input";
            this.inputTab.UseVisualStyleBackColor = true;
            // 
            // containerComboBox
            // 
            this.containerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.containerComboBox.FormattingEnabled = true;
            this.containerComboBox.Items.AddRange(new object[] {
            "MPEG-4 Video/MP4 Audio",
            "MPEG",
            "Windows Media",
            "Flash Video",
            "WebM",
            "Matroska",
            "Ogg",
            "AVI",
            "Real Media",
            "Quicktime Video",
            "DVD VOB",
            "DV Video",
            "3GP",
            "Motion JPEG",
            "Material eXchange Format",
            "MP3",
            "MP2",
            "FLAC",
            "WAV",
            "AIFF",
            "AMR"});
            this.containerComboBox.Location = new System.Drawing.Point(9, 71);
            this.containerComboBox.Name = "containerComboBox";
            this.containerComboBox.Size = new System.Drawing.Size(550, 21);
            this.containerComboBox.TabIndex = 4;
            this.containerComboBox.SelectedIndexChanged += new System.EventHandler(this.containerComboBox_SelectedIndexChanged);
            // 
            // inputButton
            // 
            this.inputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inputButton.Location = new System.Drawing.Point(472, 11);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(88, 25);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "Browse";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(9, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(455, 20);
            this.inputTextBox.TabIndex = 0;
            // 
            // videoTab
            // 
            this.videoTab.Controls.Add(this.frameRateComboBox);
            this.videoTab.Controls.Add(this.frameRateLabel);
            this.videoTab.Controls.Add(this.deinterlaceCheckBox);
            this.videoTab.Controls.Add(this.aspectComboBox);
            this.videoTab.Controls.Add(this.pixelsLabel);
            this.videoTab.Controls.Add(this.aspectLabel);
            this.videoTab.Controls.Add(this.heightTextBox);
            this.videoTab.Controls.Add(this.xLabel);
            this.videoTab.Controls.Add(this.videoBitratePanel);
            this.videoTab.Controls.Add(this.widthTextBox);
            this.videoTab.Controls.Add(this.videoComboBox);
            this.videoTab.Controls.Add(this.resolutionLabel);
            this.videoTab.Controls.Add(this.videoCheckBox);
            this.videoTab.Controls.Add(this.advancedButton);
            this.videoTab.Controls.Add(this.videoCodecLabel);
            this.videoTab.Controls.Add(this.resolutionSeperator);
            this.videoTab.Controls.Add(this.codecSeperator);
            this.videoTab.Location = new System.Drawing.Point(4, 22);
            this.videoTab.Name = "videoTab";
            this.videoTab.Padding = new System.Windows.Forms.Padding(3);
            this.videoTab.Size = new System.Drawing.Size(568, 362);
            this.videoTab.TabIndex = 1;
            this.videoTab.Text = "Video";
            this.videoTab.UseVisualStyleBackColor = true;
            // 
            // frameRateComboBox
            // 
            this.frameRateComboBox.FormattingEnabled = true;
            this.frameRateComboBox.Items.AddRange(new object[] {
            "24",
            "25",
            "29.97",
            "30",
            "50",
            "59.94",
            "60"});
            this.frameRateComboBox.Location = new System.Drawing.Point(80, 331);
            this.frameRateComboBox.Name = "frameRateComboBox";
            this.frameRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.frameRateComboBox.TabIndex = 17;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(7, 334);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(65, 13);
            this.frameRateLabel.TabIndex = 16;
            this.frameRateLabel.Text = "Frame Rate:";
            // 
            // deinterlaceCheckBox
            // 
            this.deinterlaceCheckBox.AutoSize = true;
            this.deinterlaceCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.deinterlaceCheckBox.Location = new System.Drawing.Point(210, 332);
            this.deinterlaceCheckBox.Name = "deinterlaceCheckBox";
            this.deinterlaceCheckBox.Size = new System.Drawing.Size(86, 18);
            this.deinterlaceCheckBox.TabIndex = 3;
            this.deinterlaceCheckBox.Text = "Deinterlace";
            this.deinterlaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // aspectComboBox
            // 
            this.aspectComboBox.FormattingEnabled = true;
            this.aspectComboBox.Items.AddRange(new object[] {
            "4:3",
            "16:9",
            "16:10",
            "5:4",
            "221:100",
            "1:1"});
            this.aspectComboBox.Location = new System.Drawing.Point(87, 296);
            this.aspectComboBox.Name = "aspectComboBox";
            this.aspectComboBox.Size = new System.Drawing.Size(121, 21);
            this.aspectComboBox.TabIndex = 4;
            // 
            // pixelsLabel
            // 
            this.pixelsLabel.AutoSize = true;
            this.pixelsLabel.Location = new System.Drawing.Point(204, 264);
            this.pixelsLabel.Name = "pixelsLabel";
            this.pixelsLabel.Size = new System.Drawing.Size(33, 13);
            this.pixelsLabel.TabIndex = 13;
            this.pixelsLabel.Text = "pixels";
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Location = new System.Drawing.Point(7, 299);
            this.aspectLabel.Name = "aspectLabel";
            this.aspectLabel.Size = new System.Drawing.Size(71, 13);
            this.aspectLabel.TabIndex = 2;
            this.aspectLabel.Text = "Aspect Ratio:";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(149, 261);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(50, 20);
            this.heightTextBox.TabIndex = 12;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(132, 264);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 11;
            this.xLabel.Text = "x";
            // 
            // videoBitratePanel
            // 
            this.videoBitratePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoBitratePanel.Controls.Add(this.vbrBufferTextBox);
            this.videoBitratePanel.Controls.Add(this.vbrBufferLabel);
            this.videoBitratePanel.Controls.Add(this.vbrMaxTextBox);
            this.videoBitratePanel.Controls.Add(this.vbrMaxLabel);
            this.videoBitratePanel.Controls.Add(this.vbrMinLabel);
            this.videoBitratePanel.Controls.Add(this.vbrMinTextBox);
            this.videoBitratePanel.Controls.Add(this.vbrOptionalLabel);
            this.videoBitratePanel.Controls.Add(this.vbrTextBox);
            this.videoBitratePanel.Controls.Add(this.vbrKbpsLabel);
            this.videoBitratePanel.Controls.Add(this.vbrRadioButton);
            this.videoBitratePanel.Controls.Add(this.cbrRadioButton);
            this.videoBitratePanel.Controls.Add(this.sameQualRadioButton);
            this.videoBitratePanel.Controls.Add(this.cbrTextBox);
            this.videoBitratePanel.Controls.Add(this.cbrLabel);
            this.videoBitratePanel.Location = new System.Drawing.Point(10, 93);
            this.videoBitratePanel.Name = "videoBitratePanel";
            this.videoBitratePanel.Size = new System.Drawing.Size(549, 135);
            this.videoBitratePanel.TabIndex = 14;
            // 
            // vbrBufferTextBox
            // 
            this.vbrBufferTextBox.Enabled = false;
            this.vbrBufferTextBox.Location = new System.Drawing.Point(451, 77);
            this.vbrBufferTextBox.Name = "vbrBufferTextBox";
            this.vbrBufferTextBox.Size = new System.Drawing.Size(80, 20);
            this.vbrBufferTextBox.TabIndex = 24;
            // 
            // vbrBufferLabel
            // 
            this.vbrBufferLabel.AutoSize = true;
            this.vbrBufferLabel.Enabled = false;
            this.vbrBufferLabel.Location = new System.Drawing.Point(382, 80);
            this.vbrBufferLabel.Name = "vbrBufferLabel";
            this.vbrBufferLabel.Size = new System.Drawing.Size(61, 13);
            this.vbrBufferLabel.TabIndex = 23;
            this.vbrBufferLabel.Text = "Buffer Size:";
            // 
            // vbrMaxTextBox
            // 
            this.vbrMaxTextBox.Enabled = false;
            this.vbrMaxTextBox.Location = new System.Drawing.Point(298, 77);
            this.vbrMaxTextBox.Name = "vbrMaxTextBox";
            this.vbrMaxTextBox.Size = new System.Drawing.Size(80, 20);
            this.vbrMaxTextBox.TabIndex = 22;
            // 
            // vbrMaxLabel
            // 
            this.vbrMaxLabel.AutoSize = true;
            this.vbrMaxLabel.Enabled = false;
            this.vbrMaxLabel.Location = new System.Drawing.Point(263, 80);
            this.vbrMaxLabel.Name = "vbrMaxLabel";
            this.vbrMaxLabel.Size = new System.Drawing.Size(30, 13);
            this.vbrMaxLabel.TabIndex = 21;
            this.vbrMaxLabel.Text = "Max:";
            // 
            // vbrMinLabel
            // 
            this.vbrMinLabel.AutoSize = true;
            this.vbrMinLabel.Enabled = false;
            this.vbrMinLabel.Location = new System.Drawing.Point(143, 80);
            this.vbrMinLabel.Name = "vbrMinLabel";
            this.vbrMinLabel.Size = new System.Drawing.Size(27, 13);
            this.vbrMinLabel.TabIndex = 20;
            this.vbrMinLabel.Text = "Min:";
            // 
            // vbrMinTextBox
            // 
            this.vbrMinTextBox.Enabled = false;
            this.vbrMinTextBox.Location = new System.Drawing.Point(178, 77);
            this.vbrMinTextBox.Name = "vbrMinTextBox";
            this.vbrMinTextBox.Size = new System.Drawing.Size(80, 20);
            this.vbrMinTextBox.TabIndex = 18;
            // 
            // vbrOptionalLabel
            // 
            this.vbrOptionalLabel.AutoSize = true;
            this.vbrOptionalLabel.Enabled = false;
            this.vbrOptionalLabel.Location = new System.Drawing.Point(143, 53);
            this.vbrOptionalLabel.Name = "vbrOptionalLabel";
            this.vbrOptionalLabel.Size = new System.Drawing.Size(161, 13);
            this.vbrOptionalLabel.TabIndex = 17;
            this.vbrOptionalLabel.Text = "Optional Average Bitrate Options";
            // 
            // vbrTextBox
            // 
            this.vbrTextBox.Enabled = false;
            this.vbrTextBox.Location = new System.Drawing.Point(147, 24);
            this.vbrTextBox.Name = "vbrTextBox";
            this.vbrTextBox.Size = new System.Drawing.Size(80, 20);
            this.vbrTextBox.TabIndex = 14;
            // 
            // vbrKbpsLabel
            // 
            this.vbrKbpsLabel.AutoSize = true;
            this.vbrKbpsLabel.Enabled = false;
            this.vbrKbpsLabel.Location = new System.Drawing.Point(233, 27);
            this.vbrKbpsLabel.Name = "vbrKbpsLabel";
            this.vbrKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.vbrKbpsLabel.TabIndex = 15;
            this.vbrKbpsLabel.Text = "Kbps";
            // 
            // vbrRadioButton
            // 
            this.vbrRadioButton.AutoSize = true;
            this.vbrRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vbrRadioButton.Location = new System.Drawing.Point(0, 25);
            this.vbrRadioButton.Name = "vbrRadioButton";
            this.vbrRadioButton.Size = new System.Drawing.Size(104, 18);
            this.vbrRadioButton.TabIndex = 10;
            this.vbrRadioButton.Text = "Average Bitrate";
            this.vbrRadioButton.UseVisualStyleBackColor = true;
            this.vbrRadioButton.CheckedChanged += new System.EventHandler(this.vbrRadioButton_CheckedChanged);
            // 
            // cbrRadioButton
            // 
            this.cbrRadioButton.AutoSize = true;
            this.cbrRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbrRadioButton.Location = new System.Drawing.Point(0, 113);
            this.cbrRadioButton.Name = "cbrRadioButton";
            this.cbrRadioButton.Size = new System.Drawing.Size(106, 18);
            this.cbrRadioButton.TabIndex = 9;
            this.cbrRadioButton.Text = "Constant Bitrate";
            this.cbrRadioButton.UseVisualStyleBackColor = true;
            this.cbrRadioButton.CheckedChanged += new System.EventHandler(this.cbrRadioButton_CheckedChanged);
            // 
            // sameQualRadioButton
            // 
            this.sameQualRadioButton.AutoSize = true;
            this.sameQualRadioButton.Checked = true;
            this.sameQualRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sameQualRadioButton.Location = new System.Drawing.Point(0, -3);
            this.sameQualRadioButton.Name = "sameQualRadioButton";
            this.sameQualRadioButton.Size = new System.Drawing.Size(144, 18);
            this.sameQualRadioButton.TabIndex = 13;
            this.sameQualRadioButton.TabStop = true;
            this.sameQualRadioButton.Text = "Same Quality as Source";
            this.sameQualRadioButton.UseVisualStyleBackColor = true;
            this.sameQualRadioButton.CheckedChanged += new System.EventHandler(this.sameQualRadioButton_CheckedChanged);
            // 
            // cbrTextBox
            // 
            this.cbrTextBox.Enabled = false;
            this.cbrTextBox.Location = new System.Drawing.Point(147, 112);
            this.cbrTextBox.Name = "cbrTextBox";
            this.cbrTextBox.Size = new System.Drawing.Size(80, 20);
            this.cbrTextBox.TabIndex = 6;
            // 
            // cbrLabel
            // 
            this.cbrLabel.AutoSize = true;
            this.cbrLabel.Enabled = false;
            this.cbrLabel.Location = new System.Drawing.Point(233, 115);
            this.cbrLabel.Name = "cbrLabel";
            this.cbrLabel.Size = new System.Drawing.Size(31, 13);
            this.cbrLabel.TabIndex = 7;
            this.cbrLabel.Text = "Kbps";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(76, 261);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(50, 20);
            this.widthTextBox.TabIndex = 10;
            // 
            // videoComboBox
            // 
            this.videoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoComboBox.FormattingEnabled = true;
            this.videoComboBox.Location = new System.Drawing.Point(51, 60);
            this.videoComboBox.Name = "videoComboBox";
            this.videoComboBox.Size = new System.Drawing.Size(381, 21);
            this.videoComboBox.TabIndex = 1;
            this.videoComboBox.SelectedIndexChanged += new System.EventHandler(this.videoComboBox_SelectedIndexChanged);
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(6, 264);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(60, 13);
            this.resolutionLabel.TabIndex = 9;
            this.resolutionLabel.Text = "Resolution:";
            // 
            // videoCheckBox
            // 
            this.videoCheckBox.AutoSize = true;
            this.videoCheckBox.Checked = true;
            this.videoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.videoCheckBox.Location = new System.Drawing.Point(10, 9);
            this.videoCheckBox.Name = "videoCheckBox";
            this.videoCheckBox.Size = new System.Drawing.Size(97, 18);
            this.videoCheckBox.TabIndex = 3;
            this.videoCheckBox.Text = "Include Video";
            this.videoCheckBox.UseVisualStyleBackColor = true;
            this.videoCheckBox.CheckedChanged += new System.EventHandler(this.videoCheckBox_CheckedChanged);
            // 
            // advancedButton
            // 
            this.advancedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedButton.Enabled = false;
            this.advancedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.advancedButton.Location = new System.Drawing.Point(440, 59);
            this.advancedButton.Name = "advancedButton";
            this.advancedButton.Size = new System.Drawing.Size(120, 25);
            this.advancedButton.TabIndex = 8;
            this.advancedButton.Text = "Advanced Options";
            this.advancedButton.UseVisualStyleBackColor = true;
            this.advancedButton.Click += new System.EventHandler(this.advancedButton_Click);
            // 
            // videoCodecLabel
            // 
            this.videoCodecLabel.AutoSize = true;
            this.videoCodecLabel.Location = new System.Drawing.Point(6, 64);
            this.videoCodecLabel.Name = "videoCodecLabel";
            this.videoCodecLabel.Size = new System.Drawing.Size(41, 13);
            this.videoCodecLabel.TabIndex = 0;
            this.videoCodecLabel.Text = "Codec:";
            // 
            // audioTab
            // 
            this.audioTab.Controls.Add(this.sampleComboBox);
            this.audioTab.Controls.Add(this.sampleLabel);
            this.audioTab.Controls.Add(this.channelsComboBox);
            this.audioTab.Controls.Add(this.audioBitratePanel);
            this.audioTab.Controls.Add(this.audioCheckBox);
            this.audioTab.Controls.Add(this.channelsLabel);
            this.audioTab.Controls.Add(this.audioCodecLabel);
            this.audioTab.Controls.Add(this.audioComboBox);
            this.audioTab.Controls.Add(this.channelsSeperator);
            this.audioTab.Location = new System.Drawing.Point(4, 22);
            this.audioTab.Name = "audioTab";
            this.audioTab.Padding = new System.Windows.Forms.Padding(3);
            this.audioTab.Size = new System.Drawing.Size(568, 362);
            this.audioTab.TabIndex = 7;
            this.audioTab.Text = "Audio";
            this.audioTab.UseVisualStyleBackColor = true;
            // 
            // sampleComboBox
            // 
            this.sampleComboBox.FormattingEnabled = true;
            this.sampleComboBox.Items.AddRange(new object[] {
            "8000",
            "16000",
            "22050",
            "44100",
            "48000",
            "96000"});
            this.sampleComboBox.Location = new System.Drawing.Point(88, 197);
            this.sampleComboBox.Name = "sampleComboBox";
            this.sampleComboBox.Size = new System.Drawing.Size(121, 21);
            this.sampleComboBox.TabIndex = 7;
            // 
            // sampleLabel
            // 
            this.sampleLabel.AutoSize = true;
            this.sampleLabel.Location = new System.Drawing.Point(6, 200);
            this.sampleLabel.Name = "sampleLabel";
            this.sampleLabel.Size = new System.Drawing.Size(71, 13);
            this.sampleLabel.TabIndex = 3;
            this.sampleLabel.Text = "Sample Rate:";
            // 
            // channelsComboBox
            // 
            this.channelsComboBox.FormattingEnabled = true;
            this.channelsComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.channelsComboBox.Location = new System.Drawing.Point(72, 162);
            this.channelsComboBox.Name = "channelsComboBox";
            this.channelsComboBox.Size = new System.Drawing.Size(121, 21);
            this.channelsComboBox.TabIndex = 6;
            // 
            // audioBitratePanel
            // 
            this.audioBitratePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioBitratePanel.Controls.Add(this.audioQualTextBox);
            this.audioBitratePanel.Controls.Add(this.audioQualRadioButton);
            this.audioBitratePanel.Controls.Add(this.audioBitrateTextBox);
            this.audioBitratePanel.Controls.Add(this.audioBitrateRadioButton);
            this.audioBitratePanel.Controls.Add(this.audioKbpsLabel);
            this.audioBitratePanel.Location = new System.Drawing.Point(10, 71);
            this.audioBitratePanel.Name = "audioBitratePanel";
            this.audioBitratePanel.Size = new System.Drawing.Size(549, 58);
            this.audioBitratePanel.TabIndex = 5;
            // 
            // audioQualTextBox
            // 
            this.audioQualTextBox.Enabled = false;
            this.audioQualTextBox.Location = new System.Drawing.Point(113, 35);
            this.audioQualTextBox.Name = "audioQualTextBox";
            this.audioQualTextBox.Size = new System.Drawing.Size(80, 20);
            this.audioQualTextBox.TabIndex = 10;
            // 
            // audioQualRadioButton
            // 
            this.audioQualRadioButton.AutoSize = true;
            this.audioQualRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.audioQualRadioButton.Location = new System.Drawing.Point(0, 36);
            this.audioQualRadioButton.Name = "audioQualRadioButton";
            this.audioQualRadioButton.Size = new System.Drawing.Size(82, 18);
            this.audioQualRadioButton.TabIndex = 9;
            this.audioQualRadioButton.Text = "Set Quality";
            this.audioQualRadioButton.UseVisualStyleBackColor = true;
            this.audioQualRadioButton.CheckedChanged += new System.EventHandler(this.auidQualRadioButton_CheckedChanged);
            // 
            // audioBitrateTextBox
            // 
            this.audioBitrateTextBox.Location = new System.Drawing.Point(113, 0);
            this.audioBitrateTextBox.Name = "audioBitrateTextBox";
            this.audioBitrateTextBox.Size = new System.Drawing.Size(80, 20);
            this.audioBitrateTextBox.TabIndex = 8;
            // 
            // audioBitrateRadioButton
            // 
            this.audioBitrateRadioButton.AutoSize = true;
            this.audioBitrateRadioButton.Checked = true;
            this.audioBitrateRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.audioBitrateRadioButton.Location = new System.Drawing.Point(0, 1);
            this.audioBitrateRadioButton.Name = "audioBitrateRadioButton";
            this.audioBitrateRadioButton.Size = new System.Drawing.Size(106, 18);
            this.audioBitrateRadioButton.TabIndex = 0;
            this.audioBitrateRadioButton.TabStop = true;
            this.audioBitrateRadioButton.Text = "Constant Bitrate";
            this.audioBitrateRadioButton.UseVisualStyleBackColor = true;
            this.audioBitrateRadioButton.CheckedChanged += new System.EventHandler(this.audioBitrateRadioButton_CheckedChanged);
            // 
            // audioKbpsLabel
            // 
            this.audioKbpsLabel.AutoSize = true;
            this.audioKbpsLabel.Location = new System.Drawing.Point(201, 3);
            this.audioKbpsLabel.Name = "audioKbpsLabel";
            this.audioKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.audioKbpsLabel.TabIndex = 5;
            this.audioKbpsLabel.Text = "Kbps";
            // 
            // audioCheckBox
            // 
            this.audioCheckBox.AutoSize = true;
            this.audioCheckBox.Checked = true;
            this.audioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.audioCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.audioCheckBox.Location = new System.Drawing.Point(10, 9);
            this.audioCheckBox.Name = "audioCheckBox";
            this.audioCheckBox.Size = new System.Drawing.Size(97, 18);
            this.audioCheckBox.TabIndex = 4;
            this.audioCheckBox.Text = "Include Audio";
            this.audioCheckBox.UseVisualStyleBackColor = true;
            this.audioCheckBox.CheckedChanged += new System.EventHandler(this.audioCheckBox_CheckedChanged);
            // 
            // channelsLabel
            // 
            this.channelsLabel.AutoSize = true;
            this.channelsLabel.Location = new System.Drawing.Point(6, 165);
            this.channelsLabel.Name = "channelsLabel";
            this.channelsLabel.Size = new System.Drawing.Size(54, 13);
            this.channelsLabel.TabIndex = 2;
            this.channelsLabel.Text = "Channels:";
            // 
            // audioCodecLabel
            // 
            this.audioCodecLabel.AutoSize = true;
            this.audioCodecLabel.Location = new System.Drawing.Point(6, 41);
            this.audioCodecLabel.Name = "audioCodecLabel";
            this.audioCodecLabel.Size = new System.Drawing.Size(41, 13);
            this.audioCodecLabel.TabIndex = 0;
            this.audioCodecLabel.Text = "Codec:";
            // 
            // audioComboBox
            // 
            this.audioComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioComboBox.FormattingEnabled = true;
            this.audioComboBox.Location = new System.Drawing.Point(51, 37);
            this.audioComboBox.Name = "audioComboBox";
            this.audioComboBox.Size = new System.Drawing.Size(508, 21);
            this.audioComboBox.TabIndex = 1;
            // 
            // cropTab
            // 
            this.cropTab.Controls.Add(this.cropLeftGroupBox);
            this.cropTab.Controls.Add(this.cropRightGroupBox);
            this.cropTab.Controls.Add(this.cropBottomGroupBox);
            this.cropTab.Controls.Add(this.cropTopGroupBox);
            this.cropTab.Location = new System.Drawing.Point(4, 22);
            this.cropTab.Name = "cropTab";
            this.cropTab.Padding = new System.Windows.Forms.Padding(3);
            this.cropTab.Size = new System.Drawing.Size(568, 362);
            this.cropTab.TabIndex = 2;
            this.cropTab.Text = "Crop Video";
            this.cropTab.UseVisualStyleBackColor = true;
            // 
            // cropLeftGroupBox
            // 
            this.cropLeftGroupBox.Controls.Add(this.cropLeftUpDown);
            this.cropLeftGroupBox.Location = new System.Drawing.Point(6, 112);
            this.cropLeftGroupBox.Name = "cropLeftGroupBox";
            this.cropLeftGroupBox.Size = new System.Drawing.Size(200, 100);
            this.cropLeftGroupBox.TabIndex = 3;
            this.cropLeftGroupBox.TabStop = false;
            this.cropLeftGroupBox.Text = "Left";
            // 
            // cropLeftUpDown
            // 
            this.cropLeftUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropLeftUpDown.Location = new System.Drawing.Point(37, 41);
            this.cropLeftUpDown.Name = "cropLeftUpDown";
            this.cropLeftUpDown.Size = new System.Drawing.Size(120, 20);
            this.cropLeftUpDown.TabIndex = 0;
            // 
            // cropRightGroupBox
            // 
            this.cropRightGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cropRightGroupBox.Controls.Add(this.cropRightUpDown);
            this.cropRightGroupBox.Location = new System.Drawing.Point(362, 112);
            this.cropRightGroupBox.Name = "cropRightGroupBox";
            this.cropRightGroupBox.Size = new System.Drawing.Size(200, 100);
            this.cropRightGroupBox.TabIndex = 2;
            this.cropRightGroupBox.TabStop = false;
            this.cropRightGroupBox.Text = "Right";
            // 
            // cropRightUpDown
            // 
            this.cropRightUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropRightUpDown.Location = new System.Drawing.Point(44, 41);
            this.cropRightUpDown.Name = "cropRightUpDown";
            this.cropRightUpDown.Size = new System.Drawing.Size(120, 20);
            this.cropRightUpDown.TabIndex = 0;
            // 
            // cropBottomGroupBox
            // 
            this.cropBottomGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropBottomGroupBox.Controls.Add(this.cropBottomUpDown);
            this.cropBottomGroupBox.Location = new System.Drawing.Point(183, 222);
            this.cropBottomGroupBox.Name = "cropBottomGroupBox";
            this.cropBottomGroupBox.Size = new System.Drawing.Size(200, 100);
            this.cropBottomGroupBox.TabIndex = 1;
            this.cropBottomGroupBox.TabStop = false;
            this.cropBottomGroupBox.Text = "Bottom";
            // 
            // cropBottomUpDown
            // 
            this.cropBottomUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropBottomUpDown.Location = new System.Drawing.Point(37, 43);
            this.cropBottomUpDown.Name = "cropBottomUpDown";
            this.cropBottomUpDown.Size = new System.Drawing.Size(120, 20);
            this.cropBottomUpDown.TabIndex = 0;
            // 
            // cropTopGroupBox
            // 
            this.cropTopGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropTopGroupBox.Controls.Add(this.cropTopUpDown);
            this.cropTopGroupBox.Location = new System.Drawing.Point(183, 6);
            this.cropTopGroupBox.Name = "cropTopGroupBox";
            this.cropTopGroupBox.Size = new System.Drawing.Size(200, 100);
            this.cropTopGroupBox.TabIndex = 0;
            this.cropTopGroupBox.TabStop = false;
            this.cropTopGroupBox.Text = "Top";
            // 
            // cropTopUpDown
            // 
            this.cropTopUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropTopUpDown.Location = new System.Drawing.Point(37, 40);
            this.cropTopUpDown.Name = "cropTopUpDown";
            this.cropTopUpDown.Size = new System.Drawing.Size(120, 20);
            this.cropTopUpDown.TabIndex = 0;
            // 
            // padTab
            // 
            this.padTab.Controls.Add(this.padBottomGroupBox);
            this.padTab.Controls.Add(this.padRightGroupBox);
            this.padTab.Controls.Add(this.padLeftGroupBox);
            this.padTab.Controls.Add(this.padTopGroupBox);
            this.padTab.Location = new System.Drawing.Point(4, 22);
            this.padTab.Name = "padTab";
            this.padTab.Padding = new System.Windows.Forms.Padding(3);
            this.padTab.Size = new System.Drawing.Size(568, 362);
            this.padTab.TabIndex = 3;
            this.padTab.Text = "Pad Video";
            this.padTab.UseVisualStyleBackColor = true;
            // 
            // padBottomGroupBox
            // 
            this.padBottomGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padBottomGroupBox.Controls.Add(this.padBottomUpDown);
            this.padBottomGroupBox.Location = new System.Drawing.Point(183, 222);
            this.padBottomGroupBox.Name = "padBottomGroupBox";
            this.padBottomGroupBox.Size = new System.Drawing.Size(200, 100);
            this.padBottomGroupBox.TabIndex = 3;
            this.padBottomGroupBox.TabStop = false;
            this.padBottomGroupBox.Text = "Bottom";
            // 
            // padBottomUpDown
            // 
            this.padBottomUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padBottomUpDown.Location = new System.Drawing.Point(37, 43);
            this.padBottomUpDown.Name = "padBottomUpDown";
            this.padBottomUpDown.Size = new System.Drawing.Size(120, 20);
            this.padBottomUpDown.TabIndex = 0;
            // 
            // padRightGroupBox
            // 
            this.padRightGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.padRightGroupBox.Controls.Add(this.padRightUpDown);
            this.padRightGroupBox.Location = new System.Drawing.Point(362, 112);
            this.padRightGroupBox.Name = "padRightGroupBox";
            this.padRightGroupBox.Size = new System.Drawing.Size(200, 100);
            this.padRightGroupBox.TabIndex = 2;
            this.padRightGroupBox.TabStop = false;
            this.padRightGroupBox.Text = "Right";
            // 
            // padRightUpDown
            // 
            this.padRightUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padRightUpDown.Location = new System.Drawing.Point(44, 41);
            this.padRightUpDown.Name = "padRightUpDown";
            this.padRightUpDown.Size = new System.Drawing.Size(120, 20);
            this.padRightUpDown.TabIndex = 0;
            // 
            // padLeftGroupBox
            // 
            this.padLeftGroupBox.Controls.Add(this.padLeftUpDown);
            this.padLeftGroupBox.Location = new System.Drawing.Point(6, 112);
            this.padLeftGroupBox.Name = "padLeftGroupBox";
            this.padLeftGroupBox.Size = new System.Drawing.Size(200, 100);
            this.padLeftGroupBox.TabIndex = 1;
            this.padLeftGroupBox.TabStop = false;
            this.padLeftGroupBox.Text = "Left";
            // 
            // padLeftUpDown
            // 
            this.padLeftUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padLeftUpDown.Location = new System.Drawing.Point(37, 41);
            this.padLeftUpDown.Name = "padLeftUpDown";
            this.padLeftUpDown.Size = new System.Drawing.Size(120, 20);
            this.padLeftUpDown.TabIndex = 0;
            // 
            // padTopGroupBox
            // 
            this.padTopGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padTopGroupBox.Controls.Add(this.padTopUpDown);
            this.padTopGroupBox.Location = new System.Drawing.Point(183, 6);
            this.padTopGroupBox.Name = "padTopGroupBox";
            this.padTopGroupBox.Size = new System.Drawing.Size(200, 100);
            this.padTopGroupBox.TabIndex = 0;
            this.padTopGroupBox.TabStop = false;
            this.padTopGroupBox.Text = "Top";
            // 
            // padTopUpDown
            // 
            this.padTopUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.padTopUpDown.Location = new System.Drawing.Point(37, 40);
            this.padTopUpDown.Name = "padTopUpDown";
            this.padTopUpDown.Size = new System.Drawing.Size(120, 20);
            this.padTopUpDown.TabIndex = 0;
            // 
            // metadataTab
            // 
            this.metadataTab.Controls.Add(this.commentSeperator);
            this.metadataTab.Controls.Add(this.commentTextBox);
            this.metadataTab.Controls.Add(this.copyrightTextBox);
            this.metadataTab.Controls.Add(this.authorTextBox);
            this.metadataTab.Controls.Add(this.titleTextBox);
            this.metadataTab.Controls.Add(this.copyrightSeperator);
            this.metadataTab.Controls.Add(this.authorSeperator);
            this.metadataTab.Controls.Add(this.titleSeperator);
            this.metadataTab.Location = new System.Drawing.Point(4, 22);
            this.metadataTab.Name = "metadataTab";
            this.metadataTab.Padding = new System.Windows.Forms.Padding(3);
            this.metadataTab.Size = new System.Drawing.Size(568, 362);
            this.metadataTab.TabIndex = 5;
            this.metadataTab.Text = "Meta Data";
            this.metadataTab.UseVisualStyleBackColor = true;
            // 
            // commentTextBox
            // 
            this.commentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentTextBox.Location = new System.Drawing.Point(9, 201);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(550, 20);
            this.commentTextBox.TabIndex = 0;
            // 
            // copyrightTextBox
            // 
            this.copyrightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightTextBox.Location = new System.Drawing.Point(9, 145);
            this.copyrightTextBox.Name = "copyrightTextBox";
            this.copyrightTextBox.Size = new System.Drawing.Size(550, 20);
            this.copyrightTextBox.TabIndex = 0;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(9, 89);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(550, 20);
            this.authorTextBox.TabIndex = 0;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(9, 33);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(550, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // outputTab
            // 
            this.outputTab.Controls.Add(this.outputButton);
            this.outputTab.Controls.Add(this.outputTextBox);
            this.outputTab.Location = new System.Drawing.Point(4, 22);
            this.outputTab.Name = "outputTab";
            this.outputTab.Padding = new System.Windows.Forms.Padding(3);
            this.outputTab.Size = new System.Drawing.Size(568, 362);
            this.outputTab.TabIndex = 6;
            this.outputTab.Text = "Output";
            this.outputTab.UseVisualStyleBackColor = true;
            // 
            // outputButton
            // 
            this.outputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputButton.Location = new System.Drawing.Point(472, 11);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(88, 25);
            this.outputButton.TabIndex = 1;
            this.outputButton.Text = "Browse";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(9, 12);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(455, 20);
            this.outputTextBox.TabIndex = 0;
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.Filter = resources.GetString("inputFileDialog.Filter");
            this.inputFileDialog.RestoreDirectory = true;
            this.inputFileDialog.Title = "Select File to Convert";
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.helpButton.Location = new System.Drawing.Point(103, 410);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(88, 25);
            this.helpButton.TabIndex = 3;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.Filter = "Any File|*.*";
            this.outputFileDialog.OverwritePrompt = false;
            this.outputFileDialog.RestoreDirectory = true;
            // 
            // formatSeperator
            // 
            this.formatSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatSeperator.Label = "File Format";
            this.formatSeperator.Location = new System.Drawing.Point(6, 47);
            this.formatSeperator.Name = "formatSeperator";
            this.formatSeperator.Size = new System.Drawing.Size(553, 15);
            this.formatSeperator.TabIndex = 5;
            // 
            // resolutionSeperator
            // 
            this.resolutionSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionSeperator.Label = "Resolution and Frame Rate";
            this.resolutionSeperator.Location = new System.Drawing.Point(6, 237);
            this.resolutionSeperator.Name = "resolutionSeperator";
            this.resolutionSeperator.Size = new System.Drawing.Size(553, 15);
            this.resolutionSeperator.TabIndex = 15;
            // 
            // codecSeperator
            // 
            this.codecSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codecSeperator.Label = "Codec Options";
            this.codecSeperator.Location = new System.Drawing.Point(6, 36);
            this.codecSeperator.Name = "codecSeperator";
            this.codecSeperator.Size = new System.Drawing.Size(553, 15);
            this.codecSeperator.TabIndex = 6;
            // 
            // channelsSeperator
            // 
            this.channelsSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelsSeperator.Label = "Channels and Sample Rate";
            this.channelsSeperator.Location = new System.Drawing.Point(6, 138);
            this.channelsSeperator.Name = "channelsSeperator";
            this.channelsSeperator.Size = new System.Drawing.Size(553, 15);
            this.channelsSeperator.TabIndex = 16;
            // 
            // commentSeperator
            // 
            this.commentSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentSeperator.Label = "Comment";
            this.commentSeperator.Location = new System.Drawing.Point(6, 177);
            this.commentSeperator.Name = "commentSeperator";
            this.commentSeperator.Size = new System.Drawing.Size(553, 15);
            this.commentSeperator.TabIndex = 9;
            // 
            // copyrightSeperator
            // 
            this.copyrightSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightSeperator.Label = "Copyright";
            this.copyrightSeperator.Location = new System.Drawing.Point(6, 121);
            this.copyrightSeperator.Name = "copyrightSeperator";
            this.copyrightSeperator.Size = new System.Drawing.Size(553, 15);
            this.copyrightSeperator.TabIndex = 8;
            // 
            // authorSeperator
            // 
            this.authorSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorSeperator.Label = "Author";
            this.authorSeperator.Location = new System.Drawing.Point(6, 65);
            this.authorSeperator.Name = "authorSeperator";
            this.authorSeperator.Size = new System.Drawing.Size(553, 15);
            this.authorSeperator.TabIndex = 7;
            // 
            // titleSeperator
            // 
            this.titleSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleSeperator.Label = "Title";
            this.titleSeperator.Location = new System.Drawing.Point(6, 9);
            this.titleSeperator.Name = "titleSeperator";
            this.titleSeperator.Size = new System.Drawing.Size(553, 15);
            this.titleSeperator.TabIndex = 6;
            // 
            // processingTab
            // 
            this.processingTab.Controls.Add(this.denoiseComboBox);
            this.processingTab.Controls.Add(this.scalingComboBox);
            this.processingTab.Controls.Add(this.deinterlacingComboBox);
            this.processingTab.Controls.Add(this.denoiseLabel);
            this.processingTab.Controls.Add(this.scalingLabel);
            this.processingTab.Controls.Add(this.deinterlacingLabel);
            this.processingTab.Location = new System.Drawing.Point(4, 22);
            this.processingTab.Name = "processingTab";
            this.processingTab.Padding = new System.Windows.Forms.Padding(3);
            this.processingTab.Size = new System.Drawing.Size(568, 362);
            this.processingTab.TabIndex = 8;
            this.processingTab.Text = "Post Processing";
            this.processingTab.UseVisualStyleBackColor = true;
            // 
            // deinterlacingLabel
            // 
            this.deinterlacingLabel.AutoSize = true;
            this.deinterlacingLabel.Location = new System.Drawing.Point(27, 28);
            this.deinterlacingLabel.Name = "deinterlacingLabel";
            this.deinterlacingLabel.Size = new System.Drawing.Size(72, 13);
            this.deinterlacingLabel.TabIndex = 0;
            this.deinterlacingLabel.Text = "Deinterlacing:";
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(27, 68);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(75, 13);
            this.scalingLabel.TabIndex = 1;
            this.scalingLabel.Text = "Scaling Mode:";
            // 
            // denoiseLabel
            // 
            this.denoiseLabel.AutoSize = true;
            this.denoiseLabel.Location = new System.Drawing.Point(27, 115);
            this.denoiseLabel.Name = "denoiseLabel";
            this.denoiseLabel.Size = new System.Drawing.Size(49, 13);
            this.denoiseLabel.TabIndex = 2;
            this.denoiseLabel.Text = "Denoise:";
            // 
            // deinterlacingComboBox
            // 
            this.deinterlacingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deinterlacingComboBox.FormattingEnabled = true;
            this.deinterlacingComboBox.Items.AddRange(new object[] {
            "Off",
            "FFmpeg Standard",
            "Yadif",
            "Yadif (Double Framerate)",
            "MCDeint (Double Framerate)"});
            this.deinterlacingComboBox.Location = new System.Drawing.Point(139, 25);
            this.deinterlacingComboBox.Name = "deinterlacingComboBox";
            this.deinterlacingComboBox.Size = new System.Drawing.Size(121, 21);
            this.deinterlacingComboBox.TabIndex = 3;
            // 
            // scalingComboBox
            // 
            this.scalingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scalingComboBox.FormattingEnabled = true;
            this.scalingComboBox.Items.AddRange(new object[] {
            "Nearest Neighbor",
            "Fast Bilinear",
            "Bilinear",
            "Bicubic",
            "Sinc",
            "Lanczos",
            "Spline"});
            this.scalingComboBox.Location = new System.Drawing.Point(139, 65);
            this.scalingComboBox.Name = "scalingComboBox";
            this.scalingComboBox.Size = new System.Drawing.Size(121, 21);
            this.scalingComboBox.TabIndex = 4;
            // 
            // denoiseComboBox
            // 
            this.denoiseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.denoiseComboBox.FormattingEnabled = true;
            this.denoiseComboBox.Items.AddRange(new object[] {
            "Off",
            "Weak",
            "Medium",
            "Strong"});
            this.denoiseComboBox.Location = new System.Drawing.Point(139, 112);
            this.denoiseComboBox.Name = "denoiseComboBox";
            this.denoiseComboBox.Size = new System.Drawing.Size(121, 21);
            this.denoiseComboBox.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(592, 446);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.convertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SmoothTranscode Beta";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.mainTabs.ResumeLayout(false);
            this.inputTab.ResumeLayout(false);
            this.inputTab.PerformLayout();
            this.videoTab.ResumeLayout(false);
            this.videoTab.PerformLayout();
            this.videoBitratePanel.ResumeLayout(false);
            this.videoBitratePanel.PerformLayout();
            this.audioTab.ResumeLayout(false);
            this.audioTab.PerformLayout();
            this.audioBitratePanel.ResumeLayout(false);
            this.audioBitratePanel.PerformLayout();
            this.cropTab.ResumeLayout(false);
            this.cropLeftGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cropLeftUpDown)).EndInit();
            this.cropRightGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cropRightUpDown)).EndInit();
            this.cropBottomGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cropBottomUpDown)).EndInit();
            this.cropTopGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cropTopUpDown)).EndInit();
            this.padTab.ResumeLayout(false);
            this.padBottomGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.padBottomUpDown)).EndInit();
            this.padRightGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.padRightUpDown)).EndInit();
            this.padLeftGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.padLeftUpDown)).EndInit();
            this.padTopGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.padTopUpDown)).EndInit();
            this.metadataTab.ResumeLayout(false);
            this.metadataTab.PerformLayout();
            this.outputTab.ResumeLayout(false);
            this.outputTab.PerformLayout();
            this.processingTab.ResumeLayout(false);
            this.processingTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.TabPage inputTab;
        private System.Windows.Forms.TabPage videoTab;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.TabPage cropTab;
        private System.Windows.Forms.TabPage padTab;
        private System.Windows.Forms.TabPage metadataTab;
        private System.Windows.Forms.TabPage outputTab;
        private System.Windows.Forms.Label videoCodecLabel;
        private System.Windows.Forms.CheckBox deinterlaceCheckBox;
        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.ComboBox videoComboBox;
        private System.Windows.Forms.Label cbrLabel;
        private System.Windows.Forms.TextBox cbrTextBox;
        private System.Windows.Forms.ComboBox aspectComboBox;
        private System.Windows.Forms.Button advancedButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.GroupBox cropLeftGroupBox;
        private System.Windows.Forms.GroupBox cropRightGroupBox;
        private System.Windows.Forms.GroupBox cropBottomGroupBox;
        private System.Windows.Forms.GroupBox cropTopGroupBox;
        private System.Windows.Forms.NumericUpDown cropLeftUpDown;
        private System.Windows.Forms.NumericUpDown cropRightUpDown;
        private System.Windows.Forms.NumericUpDown cropBottomUpDown;
        private System.Windows.Forms.NumericUpDown cropTopUpDown;
        private System.Windows.Forms.GroupBox padBottomGroupBox;
        private System.Windows.Forms.GroupBox padRightGroupBox;
        private System.Windows.Forms.GroupBox padLeftGroupBox;
        private System.Windows.Forms.GroupBox padTopGroupBox;
        private System.Windows.Forms.NumericUpDown padBottomUpDown;
        private System.Windows.Forms.NumericUpDown padRightUpDown;
        private System.Windows.Forms.NumericUpDown padLeftUpDown;
        private System.Windows.Forms.NumericUpDown padTopUpDown;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.TextBox copyrightTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.SaveFileDialog outputFileDialog;
        private System.Windows.Forms.Label pixelsLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.ComboBox containerComboBox;
        private Seperator formatSeperator;
        private System.Windows.Forms.CheckBox videoCheckBox;
        private Seperator codecSeperator;
        private System.Windows.Forms.RadioButton sameQualRadioButton;
        private System.Windows.Forms.RadioButton vbrRadioButton;
        private System.Windows.Forms.RadioButton cbrRadioButton;
        private System.Windows.Forms.Panel videoBitratePanel;
        private System.Windows.Forms.TabPage audioTab;
        private System.Windows.Forms.TextBox audioBitrateTextBox;
        private System.Windows.Forms.ComboBox sampleComboBox;
        private System.Windows.Forms.ComboBox channelsComboBox;
        private System.Windows.Forms.Label audioKbpsLabel;
        private System.Windows.Forms.Label sampleLabel;
        private System.Windows.Forms.Label channelsLabel;
        private System.Windows.Forms.ComboBox audioComboBox;
        private System.Windows.Forms.Label audioCodecLabel;
        private System.Windows.Forms.TextBox vbrTextBox;
        private System.Windows.Forms.Label vbrKbpsLabel;
        private System.Windows.Forms.Label vbrOptionalLabel;
        private System.Windows.Forms.Label vbrMinLabel;
        private System.Windows.Forms.TextBox vbrMinTextBox;
        private System.Windows.Forms.Label vbrMaxLabel;
        private System.Windows.Forms.TextBox vbrMaxTextBox;
        private System.Windows.Forms.TextBox vbrBufferTextBox;
        private System.Windows.Forms.Label vbrBufferLabel;
        private Seperator resolutionSeperator;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.ComboBox frameRateComboBox;
        private System.Windows.Forms.CheckBox audioCheckBox;
        private System.Windows.Forms.Panel audioBitratePanel;
        private System.Windows.Forms.RadioButton audioBitrateRadioButton;
        private System.Windows.Forms.TextBox audioQualTextBox;
        private System.Windows.Forms.RadioButton audioQualRadioButton;
        private Seperator channelsSeperator;
        private Seperator titleSeperator;
        private Seperator authorSeperator;
        private Seperator copyrightSeperator;
        private Seperator commentSeperator;
        private System.Windows.Forms.TabPage processingTab;
        private System.Windows.Forms.ComboBox denoiseComboBox;
        private System.Windows.Forms.ComboBox scalingComboBox;
        private System.Windows.Forms.ComboBox deinterlacingComboBox;
        private System.Windows.Forms.Label denoiseLabel;
        private System.Windows.Forms.Label scalingLabel;
        private System.Windows.Forms.Label deinterlacingLabel;
    }
}

