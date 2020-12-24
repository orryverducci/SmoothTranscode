namespace SmoothTranscode
{
    partial class ProgressWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressWindow));
            this.cancelButton = new System.Windows.Forms.Button();
            this.conversionProgressBar = new wyDay.Controls.Windows7ProgressBar();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.mainLabel = new System.Windows.Forms.Label();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.lowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(277, 101);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // conversionProgressBar
            // 
            this.conversionProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conversionProgressBar.ContainerControl = this;
            this.conversionProgressBar.Location = new System.Drawing.Point(9, 38);
            this.conversionProgressBar.Name = "conversionProgressBar";
            this.conversionProgressBar.ShowInTaskbar = true;
            this.conversionProgressBar.Size = new System.Drawing.Size(355, 15);
            this.conversionProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.conversionProgressBar.TabIndex = 2;
            // 
            // lowerPanel
            // 
            this.lowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerPanel.BackColor = System.Drawing.SystemColors.Window;
            this.lowerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lowerPanel.Controls.Add(this.detailsLabel);
            this.lowerPanel.Controls.Add(this.mainLabel);
            this.lowerPanel.Controls.Add(this.conversionProgressBar);
            this.lowerPanel.Location = new System.Drawing.Point(-1, -1);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(375, 91);
            this.lowerPanel.TabIndex = 3;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.mainLabel.Location = new System.Drawing.Point(5, 7);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(115, 13);
            this.mainLabel.TabIndex = 3;
            this.mainLabel.Text = "Conversion in Progress";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Location = new System.Drawing.Point(5, 62);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(0, 13);
            this.detailsLabel.TabIndex = 4;
            // 
            // ProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(373, 137);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lowerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conversion in Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressWindow_FormClosing);
            this.Load += new System.EventHandler(this.ProgressWindow_Load);
            this.lowerPanel.ResumeLayout(false);
            this.lowerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private wyDay.Controls.Windows7ProgressBar conversionProgressBar;
        private System.Windows.Forms.Panel lowerPanel;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label detailsLabel;
    }
}