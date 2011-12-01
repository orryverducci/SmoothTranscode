namespace SmoothTranscode
{
    partial class X264Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X264Window));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.tuningComboBox = new System.Windows.Forms.ComboBox();
            this.trellisLabel = new System.Windows.Forms.Label();
            this.trellisComboBox = new System.Windows.Forms.ComboBox();
            this.cabacCheckBox = new System.Windows.Forms.CheckBox();
            this.refLabel = new System.Windows.Forms.Label();
            this.refUpDown = new System.Windows.Forms.NumericUpDown();
            this.bframesLabel = new System.Windows.Forms.Label();
            this.bframesUpDown = new System.Windows.Forms.NumericUpDown();
            this.dctCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.strengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.weightedCheckBox = new System.Windows.Forms.CheckBox();
            this.pyramidalLabel = new System.Windows.Forms.Label();
            this.pyramidalComboBox = new System.Windows.Forms.ComboBox();
            this.adaptiveComboBox = new System.Windows.Forms.ComboBox();
            this.adaptiveLabel = new System.Windows.Forms.Label();
            this.directComboBox = new System.Windows.Forms.ComboBox();
            this.directLabel = new System.Windows.Forms.Label();
            this.decimateCheckBox = new System.Windows.Forms.CheckBox();
            this.meComboBox = new System.Windows.Forms.ComboBox();
            this.meLabel = new System.Windows.Forms.Label();
            this.subpixelLabel = new System.Windows.Forms.Label();
            this.subpixelComboBox = new System.Windows.Forms.ComboBox();
            this.aqLabel = new System.Windows.Forms.Label();
            this.psyLabel = new System.Windows.Forms.Label();
            this.aqTrackBar = new System.Windows.Forms.TrackBar();
            this.aqValueLabel = new System.Windows.Forms.Label();
            this.psyValueLabel = new System.Windows.Forms.Label();
            this.psyTrackBar = new System.Windows.Forms.TrackBar();
            this.deblockingSeperator = new SmoothTranscode.Seperator();
            this.analysisSeperator = new SmoothTranscode.Seperator();
            this.encodingSeperator = new SmoothTranscode.Seperator();
            this.frameSeperator = new SmoothTranscode.Seperator();
            this.tuningSeperator = new SmoothTranscode.Seperator();
            ((System.ComponentModel.ISupportInitialize)(this.refUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bframesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aqTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psyTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(298, 517);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(203, 517);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tuningComboBox
            // 
            this.tuningComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tuningComboBox.FormattingEnabled = true;
            this.tuningComboBox.Items.AddRange(new object[] {
            "Film",
            "Animation",
            "Grain",
            "Still Image",
            "PSNR",
            "SSIM",
            "Fast Decode",
            "Zero Latency"});
            this.tuningComboBox.Location = new System.Drawing.Point(9, 33);
            this.tuningComboBox.Name = "tuningComboBox";
            this.tuningComboBox.Size = new System.Drawing.Size(376, 21);
            this.tuningComboBox.TabIndex = 7;
            // 
            // trellisLabel
            // 
            this.trellisLabel.AutoSize = true;
            this.trellisLabel.Location = new System.Drawing.Point(188, 96);
            this.trellisLabel.Name = "trellisLabel";
            this.trellisLabel.Size = new System.Drawing.Size(37, 13);
            this.trellisLabel.TabIndex = 10;
            this.trellisLabel.Text = "Trellis:";
            // 
            // trellisComboBox
            // 
            this.trellisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trellisComboBox.FormattingEnabled = true;
            this.trellisComboBox.Items.AddRange(new object[] {
            "Off",
            "Enabled on Macroblock",
            "Enabled on All Modes"});
            this.trellisComboBox.Location = new System.Drawing.Point(233, 92);
            this.trellisComboBox.Name = "trellisComboBox";
            this.trellisComboBox.Size = new System.Drawing.Size(154, 21);
            this.trellisComboBox.TabIndex = 11;
            // 
            // cabacCheckBox
            // 
            this.cabacCheckBox.AutoSize = true;
            this.cabacCheckBox.Checked = true;
            this.cabacCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cabacCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cabacCheckBox.Location = new System.Drawing.Point(11, 94);
            this.cabacCheckBox.Name = "cabacCheckBox";
            this.cabacCheckBox.Size = new System.Drawing.Size(142, 18);
            this.cabacCheckBox.TabIndex = 12;
            this.cabacCheckBox.Text = "CABAC Entropy Coding";
            this.cabacCheckBox.UseVisualStyleBackColor = true;
            this.cabacCheckBox.CheckedChanged += new System.EventHandler(this.cabacCheckBox_CheckedChanged);
            // 
            // refLabel
            // 
            this.refLabel.AutoSize = true;
            this.refLabel.Location = new System.Drawing.Point(7, 175);
            this.refLabel.Name = "refLabel";
            this.refLabel.Size = new System.Drawing.Size(97, 13);
            this.refLabel.TabIndex = 14;
            this.refLabel.Text = "Reference Frames:";
            // 
            // refUpDown
            // 
            this.refUpDown.Location = new System.Drawing.Point(114, 173);
            this.refUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.refUpDown.Name = "refUpDown";
            this.refUpDown.Size = new System.Drawing.Size(40, 20);
            this.refUpDown.TabIndex = 15;
            this.refUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // bframesLabel
            // 
            this.bframesLabel.AutoSize = true;
            this.bframesLabel.Location = new System.Drawing.Point(188, 175);
            this.bframesLabel.Name = "bframesLabel";
            this.bframesLabel.Size = new System.Drawing.Size(101, 13);
            this.bframesLabel.TabIndex = 16;
            this.bframesLabel.Text = "Maximum B-Frames:";
            // 
            // bframesUpDown
            // 
            this.bframesUpDown.Location = new System.Drawing.Point(309, 173);
            this.bframesUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.bframesUpDown.Name = "bframesUpDown";
            this.bframesUpDown.Size = new System.Drawing.Size(40, 20);
            this.bframesUpDown.TabIndex = 17;
            this.bframesUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // dctCheckBox
            // 
            this.dctCheckBox.AutoSize = true;
            this.dctCheckBox.Checked = true;
            this.dctCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dctCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dctCheckBox.Location = new System.Drawing.Point(11, 124);
            this.dctCheckBox.Name = "dctCheckBox";
            this.dctCheckBox.Size = new System.Drawing.Size(99, 18);
            this.dctCheckBox.TabIndex = 18;
            this.dctCheckBox.Text = "8x8 Transform";
            this.dctCheckBox.UseVisualStyleBackColor = true;
            // 
            // thresholdUpDown
            // 
            this.thresholdUpDown.Location = new System.Drawing.Point(255, 483);
            this.thresholdUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.thresholdUpDown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.thresholdUpDown.Name = "thresholdUpDown";
            this.thresholdUpDown.Size = new System.Drawing.Size(40, 20);
            this.thresholdUpDown.TabIndex = 23;
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(188, 485);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(57, 13);
            this.thresholdLabel.TabIndex = 22;
            this.thresholdLabel.Text = "Threshold:";
            // 
            // strengthUpDown
            // 
            this.strengthUpDown.Location = new System.Drawing.Point(66, 483);
            this.strengthUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.strengthUpDown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.strengthUpDown.Name = "strengthUpDown";
            this.strengthUpDown.Size = new System.Drawing.Size(40, 20);
            this.strengthUpDown.TabIndex = 21;
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.Location = new System.Drawing.Point(7, 485);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(50, 13);
            this.strengthLabel.TabIndex = 20;
            this.strengthLabel.Text = "Strength:";
            // 
            // weightedCheckBox
            // 
            this.weightedCheckBox.AutoSize = true;
            this.weightedCheckBox.Checked = true;
            this.weightedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.weightedCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.weightedCheckBox.Location = new System.Drawing.Point(11, 231);
            this.weightedCheckBox.Name = "weightedCheckBox";
            this.weightedCheckBox.Size = new System.Drawing.Size(125, 18);
            this.weightedCheckBox.TabIndex = 24;
            this.weightedCheckBox.Text = "Weighted P-Frames";
            this.weightedCheckBox.UseVisualStyleBackColor = true;
            // 
            // pyramidalLabel
            // 
            this.pyramidalLabel.AutoSize = true;
            this.pyramidalLabel.Location = new System.Drawing.Point(188, 233);
            this.pyramidalLabel.Name = "pyramidalLabel";
            this.pyramidalLabel.Size = new System.Drawing.Size(102, 13);
            this.pyramidalLabel.TabIndex = 25;
            this.pyramidalLabel.Text = "Pyramidal P-Frames:";
            // 
            // pyramidalComboBox
            // 
            this.pyramidalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pyramidalComboBox.FormattingEnabled = true;
            this.pyramidalComboBox.Items.AddRange(new object[] {
            "Off",
            "Normal",
            "Strict"});
            this.pyramidalComboBox.Location = new System.Drawing.Point(308, 229);
            this.pyramidalComboBox.Name = "pyramidalComboBox";
            this.pyramidalComboBox.Size = new System.Drawing.Size(79, 21);
            this.pyramidalComboBox.TabIndex = 26;
            // 
            // adaptiveComboBox
            // 
            this.adaptiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adaptiveComboBox.FormattingEnabled = true;
            this.adaptiveComboBox.Items.AddRange(new object[] {
            "Off",
            "Fast",
            "Optimal"});
            this.adaptiveComboBox.Location = new System.Drawing.Point(121, 265);
            this.adaptiveComboBox.Name = "adaptiveComboBox";
            this.adaptiveComboBox.Size = new System.Drawing.Size(120, 21);
            this.adaptiveComboBox.TabIndex = 27;
            // 
            // adaptiveLabel
            // 
            this.adaptiveLabel.AutoSize = true;
            this.adaptiveLabel.Location = new System.Drawing.Point(7, 269);
            this.adaptiveLabel.Name = "adaptiveLabel";
            this.adaptiveLabel.Size = new System.Drawing.Size(99, 13);
            this.adaptiveLabel.TabIndex = 28;
            this.adaptiveLabel.Text = "Adaptive B-Frames:";
            // 
            // directComboBox
            // 
            this.directComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directComboBox.FormattingEnabled = true;
            this.directComboBox.Items.AddRange(new object[] {
            "None",
            "Spatial",
            "Temporal",
            "Automatic"});
            this.directComboBox.Location = new System.Drawing.Point(136, 300);
            this.directComboBox.Name = "directComboBox";
            this.directComboBox.Size = new System.Drawing.Size(120, 21);
            this.directComboBox.TabIndex = 29;
            // 
            // directLabel
            // 
            this.directLabel.AutoSize = true;
            this.directLabel.Location = new System.Drawing.Point(7, 305);
            this.directLabel.Name = "directLabel";
            this.directLabel.Size = new System.Drawing.Size(113, 13);
            this.directLabel.TabIndex = 30;
            this.directLabel.Text = "Adaptive Direct Mode:";
            // 
            // decimateCheckBox
            // 
            this.decimateCheckBox.AutoSize = true;
            this.decimateCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.decimateCheckBox.Location = new System.Drawing.Point(250, 267);
            this.decimateCheckBox.Name = "decimateCheckBox";
            this.decimateCheckBox.Size = new System.Drawing.Size(119, 18);
            this.decimateCheckBox.TabIndex = 31;
            this.decimateCheckBox.Text = "No DCT-Decimate";
            this.decimateCheckBox.UseVisualStyleBackColor = true;
            // 
            // meComboBox
            // 
            this.meComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meComboBox.FormattingEnabled = true;
            this.meComboBox.Items.AddRange(new object[] {
            "Diamond",
            "Hexagon",
            "Uneven Multi-Hexagon",
            "Exhaustive",
            "Transformed Exhaustive"});
            this.meComboBox.Location = new System.Drawing.Point(163, 335);
            this.meComboBox.Name = "meComboBox";
            this.meComboBox.Size = new System.Drawing.Size(150, 21);
            this.meComboBox.TabIndex = 32;
            // 
            // meLabel
            // 
            this.meLabel.AutoSize = true;
            this.meLabel.Location = new System.Drawing.Point(6, 339);
            this.meLabel.Name = "meLabel";
            this.meLabel.Size = new System.Drawing.Size(132, 13);
            this.meLabel.TabIndex = 33;
            this.meLabel.Text = "Motion Estimation Method:";
            // 
            // subpixelLabel
            // 
            this.subpixelLabel.AutoSize = true;
            this.subpixelLabel.Location = new System.Drawing.Point(6, 374);
            this.subpixelLabel.Name = "subpixelLabel";
            this.subpixelLabel.Size = new System.Drawing.Size(164, 13);
            this.subpixelLabel.TabIndex = 35;
            this.subpixelLabel.Text = "Subpixel ME and Mode Decision:";
            // 
            // subpixelComboBox
            // 
            this.subpixelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subpixelComboBox.FormattingEnabled = true;
            this.subpixelComboBox.Items.AddRange(new object[] {
            "SAD, no subpel",
            "SAD, qpel",
            "SATD, qpel",
            "SATD, multi-qpel",
            "SATD, qpel on all",
            "SATD, multi-qpel on all",
            "RD in I/P-frames",
            "RD in all frames",
            "RD refinement in I/P-frames",
            "RD refinement in all frames",
            "QPRD in all frames",
            "Full RD in all frames"});
            this.subpixelComboBox.Location = new System.Drawing.Point(189, 370);
            this.subpixelComboBox.Name = "subpixelComboBox";
            this.subpixelComboBox.Size = new System.Drawing.Size(198, 21);
            this.subpixelComboBox.TabIndex = 34;
            // 
            // aqLabel
            // 
            this.aqLabel.AutoSize = true;
            this.aqLabel.Location = new System.Drawing.Point(7, 402);
            this.aqLabel.Name = "aqLabel";
            this.aqLabel.Size = new System.Drawing.Size(157, 13);
            this.aqLabel.TabIndex = 36;
            this.aqLabel.Text = "Adaptive Quantization Strength:";
            // 
            // psyLabel
            // 
            this.psyLabel.AutoSize = true;
            this.psyLabel.Location = new System.Drawing.Point(188, 402);
            this.psyLabel.Name = "psyLabel";
            this.psyLabel.Size = new System.Drawing.Size(145, 13);
            this.psyLabel.TabIndex = 37;
            this.psyLabel.Text = "Psychovisual Rate Distortion:";
            // 
            // aqTrackBar
            // 
            this.aqTrackBar.Location = new System.Drawing.Point(2, 424);
            this.aqTrackBar.Maximum = 20;
            this.aqTrackBar.Name = "aqTrackBar";
            this.aqTrackBar.Size = new System.Drawing.Size(166, 45);
            this.aqTrackBar.TabIndex = 38;
            this.aqTrackBar.Value = 10;
            this.aqTrackBar.Scroll += new System.EventHandler(this.aqTrackBar_Scroll);
            // 
            // aqValueLabel
            // 
            this.aqValueLabel.AutoSize = true;
            this.aqValueLabel.Location = new System.Drawing.Point(166, 428);
            this.aqValueLabel.Name = "aqValueLabel";
            this.aqValueLabel.Size = new System.Drawing.Size(22, 13);
            this.aqValueLabel.TabIndex = 39;
            this.aqValueLabel.Text = "1.0";
            // 
            // psyValueLabel
            // 
            this.psyValueLabel.AutoSize = true;
            this.psyValueLabel.Location = new System.Drawing.Point(348, 428);
            this.psyValueLabel.Name = "psyValueLabel";
            this.psyValueLabel.Size = new System.Drawing.Size(22, 13);
            this.psyValueLabel.TabIndex = 41;
            this.psyValueLabel.Text = "1.0";
            // 
            // psyTrackBar
            // 
            this.psyTrackBar.Location = new System.Drawing.Point(184, 424);
            this.psyTrackBar.Maximum = 20;
            this.psyTrackBar.Name = "psyTrackBar";
            this.psyTrackBar.Size = new System.Drawing.Size(166, 45);
            this.psyTrackBar.TabIndex = 40;
            this.psyTrackBar.Value = 10;
            this.psyTrackBar.Scroll += new System.EventHandler(this.psyTrackBar_Scroll);
            // 
            // deblockingSeperator
            // 
            this.deblockingSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deblockingSeperator.Label = "Playback Deblocking Options";
            this.deblockingSeperator.Location = new System.Drawing.Point(7, 459);
            this.deblockingSeperator.Name = "deblockingSeperator";
            this.deblockingSeperator.Size = new System.Drawing.Size(380, 15);
            this.deblockingSeperator.TabIndex = 19;
            // 
            // analysisSeperator
            // 
            this.analysisSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisSeperator.Label = "Analysis Options";
            this.analysisSeperator.Location = new System.Drawing.Point(7, 205);
            this.analysisSeperator.Name = "analysisSeperator";
            this.analysisSeperator.Size = new System.Drawing.Size(380, 15);
            this.analysisSeperator.TabIndex = 13;
            // 
            // encodingSeperator
            // 
            this.encodingSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encodingSeperator.Label = "Encoding Options";
            this.encodingSeperator.Location = new System.Drawing.Point(7, 68);
            this.encodingSeperator.Name = "encodingSeperator";
            this.encodingSeperator.Size = new System.Drawing.Size(380, 15);
            this.encodingSeperator.TabIndex = 9;
            // 
            // frameSeperator
            // 
            this.frameSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameSeperator.Label = "Frame Options";
            this.frameSeperator.Location = new System.Drawing.Point(7, 149);
            this.frameSeperator.Name = "frameSeperator";
            this.frameSeperator.Size = new System.Drawing.Size(380, 15);
            this.frameSeperator.TabIndex = 8;
            // 
            // tuningSeperator
            // 
            this.tuningSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tuningSeperator.Label = "Source Tuning";
            this.tuningSeperator.Location = new System.Drawing.Point(5, 9);
            this.tuningSeperator.Name = "tuningSeperator";
            this.tuningSeperator.Size = new System.Drawing.Size(380, 15);
            this.tuningSeperator.TabIndex = 6;
            // 
            // X264Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(394, 553);
            this.Controls.Add(this.deblockingSeperator);
            this.Controls.Add(this.aqValueLabel);
            this.Controls.Add(this.psyValueLabel);
            this.Controls.Add(this.psyTrackBar);
            this.Controls.Add(this.aqTrackBar);
            this.Controls.Add(this.psyLabel);
            this.Controls.Add(this.aqLabel);
            this.Controls.Add(this.subpixelLabel);
            this.Controls.Add(this.subpixelComboBox);
            this.Controls.Add(this.meLabel);
            this.Controls.Add(this.meComboBox);
            this.Controls.Add(this.decimateCheckBox);
            this.Controls.Add(this.directLabel);
            this.Controls.Add(this.directComboBox);
            this.Controls.Add(this.adaptiveLabel);
            this.Controls.Add(this.adaptiveComboBox);
            this.Controls.Add(this.pyramidalComboBox);
            this.Controls.Add(this.pyramidalLabel);
            this.Controls.Add(this.weightedCheckBox);
            this.Controls.Add(this.thresholdUpDown);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.strengthUpDown);
            this.Controls.Add(this.strengthLabel);
            this.Controls.Add(this.dctCheckBox);
            this.Controls.Add(this.bframesUpDown);
            this.Controls.Add(this.bframesLabel);
            this.Controls.Add(this.refUpDown);
            this.Controls.Add(this.refLabel);
            this.Controls.Add(this.analysisSeperator);
            this.Controls.Add(this.cabacCheckBox);
            this.Controls.Add(this.trellisComboBox);
            this.Controls.Add(this.trellisLabel);
            this.Controls.Add(this.encodingSeperator);
            this.Controls.Add(this.frameSeperator);
            this.Controls.Add(this.tuningComboBox);
            this.Controls.Add(this.tuningSeperator);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "X264Window";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "H.264 Advanced Options";
            this.Load += new System.EventHandler(this.X264Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.refUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bframesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aqTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psyTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private Seperator tuningSeperator;
        private System.Windows.Forms.ComboBox tuningComboBox;
        private Seperator frameSeperator;
        private Seperator encodingSeperator;
        private System.Windows.Forms.Label trellisLabel;
        private System.Windows.Forms.ComboBox trellisComboBox;
        private System.Windows.Forms.CheckBox cabacCheckBox;
        private Seperator analysisSeperator;
        private System.Windows.Forms.Label refLabel;
        private System.Windows.Forms.NumericUpDown refUpDown;
        private System.Windows.Forms.Label bframesLabel;
        private System.Windows.Forms.NumericUpDown bframesUpDown;
        private System.Windows.Forms.CheckBox dctCheckBox;
        private Seperator deblockingSeperator;
        private System.Windows.Forms.NumericUpDown thresholdUpDown;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NumericUpDown strengthUpDown;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.CheckBox weightedCheckBox;
        private System.Windows.Forms.Label pyramidalLabel;
        private System.Windows.Forms.ComboBox pyramidalComboBox;
        private System.Windows.Forms.ComboBox adaptiveComboBox;
        private System.Windows.Forms.Label adaptiveLabel;
        private System.Windows.Forms.ComboBox directComboBox;
        private System.Windows.Forms.Label directLabel;
        private System.Windows.Forms.CheckBox decimateCheckBox;
        private System.Windows.Forms.ComboBox meComboBox;
        private System.Windows.Forms.Label meLabel;
        private System.Windows.Forms.Label subpixelLabel;
        private System.Windows.Forms.ComboBox subpixelComboBox;
        private System.Windows.Forms.Label aqLabel;
        private System.Windows.Forms.Label psyLabel;
        private System.Windows.Forms.TrackBar aqTrackBar;
        private System.Windows.Forms.Label aqValueLabel;
        private System.Windows.Forms.Label psyValueLabel;
        private System.Windows.Forms.TrackBar psyTrackBar;
    }
}