namespace Help
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
            this.helpToolStrip = new System.Windows.Forms.ToolStrip();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.forwardButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.contentsButton = new System.Windows.Forms.ToolStripButton();
            this.helpProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.helpBrowser = new System.Windows.Forms.WebBrowser();
            this.helpToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpToolStrip
            // 
            this.helpToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.helpToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.toolStripSeparator,
            this.contentsButton,
            this.helpProgressBar});
            this.helpToolStrip.Location = new System.Drawing.Point(0, 0);
            this.helpToolStrip.Name = "helpToolStrip";
            this.helpToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.helpToolStrip.Size = new System.Drawing.Size(711, 25);
            this.helpToolStrip.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton.Enabled = false;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(23, 22);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardButton.Enabled = false;
            this.forwardButton.Image = ((System.Drawing.Image)(resources.GetObject("forwardButton.Image")));
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(23, 22);
            this.forwardButton.Text = "Forward";
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // contentsButton
            // 
            this.contentsButton.Image = ((System.Drawing.Image)(resources.GetObject("contentsButton.Image")));
            this.contentsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contentsButton.Name = "contentsButton";
            this.contentsButton.Size = new System.Drawing.Size(75, 22);
            this.contentsButton.Tag = "";
            this.contentsButton.Text = "Contents";
            this.contentsButton.Click += new System.EventHandler(this.contentsButton_Click);
            // 
            // helpProgressBar
            // 
            this.helpProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpProgressBar.Name = "helpProgressBar";
            this.helpProgressBar.Size = new System.Drawing.Size(100, 22);
            this.helpProgressBar.Step = 1;
            this.helpProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.helpProgressBar.Visible = false;
            // 
            // helpBrowser
            // 
            this.helpBrowser.AllowWebBrowserDrop = false;
            this.helpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpBrowser.Location = new System.Drawing.Point(0, 25);
            this.helpBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.helpBrowser.Name = "helpBrowser";
            this.helpBrowser.Size = new System.Drawing.Size(711, 358);
            this.helpBrowser.TabIndex = 1;
            this.helpBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.helpBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.helpBrowser_DocumentCompleted);
            this.helpBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.helpBrowser_Navigating);
            this.helpBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.helpBrowser_ProgressChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 383);
            this.Controls.Add(this.helpBrowser);
            this.Controls.Add(this.helpToolStrip);
            this.Name = "MainWindow";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.helpToolStrip.ResumeLayout(false);
            this.helpToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip helpToolStrip;
        private System.Windows.Forms.WebBrowser helpBrowser;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStripButton forwardButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton contentsButton;
        private System.Windows.Forms.ToolStripProgressBar helpProgressBar;
    }
}

