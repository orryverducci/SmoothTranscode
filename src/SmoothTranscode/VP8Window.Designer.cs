namespace SmoothTranscode
{
    partial class VP8Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VP8Window));
            this.qualityComboBox = new System.Windows.Forms.ComboBox();
            this.qualitySeperator = new SmoothTranscode.Seperator();
            this.cpuUpDown = new System.Windows.Forms.NumericUpDown();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cpuUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // qualityComboBox
            // 
            this.qualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBox.FormattingEnabled = true;
            this.qualityComboBox.Items.AddRange(new object[] {
            "Real Time",
            "Good",
            "Best"});
            this.qualityComboBox.Location = new System.Drawing.Point(9, 33);
            this.qualityComboBox.Name = "qualityComboBox";
            this.qualityComboBox.Size = new System.Drawing.Size(376, 21);
            this.qualityComboBox.TabIndex = 9;
            // 
            // qualitySeperator
            // 
            this.qualitySeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qualitySeperator.Label = "Quality";
            this.qualitySeperator.Location = new System.Drawing.Point(5, 9);
            this.qualitySeperator.Name = "qualitySeperator";
            this.qualitySeperator.Size = new System.Drawing.Size(380, 15);
            this.qualitySeperator.TabIndex = 8;
            // 
            // cpuUpDown
            // 
            this.cpuUpDown.Location = new System.Drawing.Point(73, 68);
            this.cpuUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.cpuUpDown.Name = "cpuUpDown";
            this.cpuUpDown.Size = new System.Drawing.Size(40, 20);
            this.cpuUpDown.TabIndex = 17;
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(7, 70);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(60, 13);
            this.cpuLabel.TabIndex = 16;
            this.cpuLabel.Text = "CPU Used:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(203, 102);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 25);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(298, 102);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // VP8Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(394, 138);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cpuUpDown);
            this.Controls.Add(this.cpuLabel);
            this.Controls.Add(this.qualityComboBox);
            this.Controls.Add(this.qualitySeperator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VP8Window";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VP8 Advanced Options";
            this.Load += new System.EventHandler(this.VP8Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cpuUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox qualityComboBox;
        private Seperator qualitySeperator;
        private System.Windows.Forms.NumericUpDown cpuUpDown;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}