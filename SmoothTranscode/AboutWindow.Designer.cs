namespace SmoothTranscode
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.okButton = new System.Windows.Forms.Button();
            this.aboutPanelMenu = new System.Windows.Forms.ToolStrip();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.creditsButton = new System.Windows.Forms.ToolStripButton();
            this.licenseButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hiddenTabsControl = new SmoothTranscode.HiddenTabsControl();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.LinkLabel = new wyDay.Controls.LinkLabel2();
            this.versionLabel = new System.Windows.Forms.Label();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.creditsPage = new System.Windows.Forms.TabPage();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.licensePage = new System.Windows.Forms.TabPage();
            this.licenseBrowser = new System.Windows.Forms.WebBrowser();
            this.aboutPanelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.hiddenTabsControl.SuspendLayout();
            this.aboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.creditsPage.SuspendLayout();
            this.licensePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(398, 11);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 25);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // aboutPanelMenu
            // 
            this.aboutPanelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutPanelMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.aboutPanelMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.aboutPanelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutButton,
            this.creditsButton,
            this.licenseButton});
            this.aboutPanelMenu.Location = new System.Drawing.Point(9, 10);
            this.aboutPanelMenu.Name = "aboutPanelMenu";
            this.aboutPanelMenu.Padding = new System.Windows.Forms.Padding(0);
            this.aboutPanelMenu.Size = new System.Drawing.Size(174, 28);
            this.aboutPanelMenu.TabIndex = 2;
            this.aboutPanelMenu.Text = "toolStrip1";
            // 
            // aboutButton
            // 
            this.aboutButton.Checked = true;
            this.aboutButton.CheckOnClick = true;
            this.aboutButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.aboutButton.Size = new System.Drawing.Size(54, 25);
            this.aboutButton.Text = "About";
            this.aboutButton.ToolTipText = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // creditsButton
            // 
            this.creditsButton.CheckOnClick = true;
            this.creditsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.creditsButton.Image = ((System.Drawing.Image)(resources.GetObject("creditsButton.Image")));
            this.creditsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.creditsButton.Size = new System.Drawing.Size(58, 25);
            this.creditsButton.Text = "Credits";
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // licenseButton
            // 
            this.licenseButton.CheckOnClick = true;
            this.licenseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.licenseButton.Image = ((System.Drawing.Image)(resources.GetObject("licenseButton.Image")));
            this.licenseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.licenseButton.Name = "licenseButton";
            this.licenseButton.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.licenseButton.Size = new System.Drawing.Size(60, 25);
            this.licenseButton.Text = "License";
            this.licenseButton.Click += new System.EventHandler(this.licenseButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.aboutPanelMenu);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Location = new System.Drawing.Point(-1, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 49);
            this.panel1.TabIndex = 1;
            // 
            // hiddenTabsControl
            // 
            this.hiddenTabsControl.Controls.Add(this.aboutPage);
            this.hiddenTabsControl.Controls.Add(this.creditsPage);
            this.hiddenTabsControl.Controls.Add(this.licensePage);
            this.hiddenTabsControl.Location = new System.Drawing.Point(0, 0);
            this.hiddenTabsControl.Name = "hiddenTabsControl";
            this.hiddenTabsControl.SelectedIndex = 0;
            this.hiddenTabsControl.Size = new System.Drawing.Size(494, 220);
            this.hiddenTabsControl.TabIndex = 3;
            // 
            // aboutPage
            // 
            this.aboutPage.BackgroundImage = global::SmoothTranscode.Properties.Resources.square_bg;
            this.aboutPage.Controls.Add(this.logoPictureBox);
            this.aboutPage.Controls.Add(this.LinkLabel);
            this.aboutPage.Controls.Add(this.versionLabel);
            this.aboutPage.Controls.Add(this.licenseLabel);
            this.aboutPage.Controls.Add(this.copyrightLabel);
            this.aboutPage.Location = new System.Drawing.Point(4, 22);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutPage.Size = new System.Drawing.Size(486, 194);
            this.aboutPage.TabIndex = 0;
            this.aboutPage.Text = "About";
            this.aboutPage.UseVisualStyleBackColor = true;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::SmoothTranscode.Properties.Resources.Logo;
            this.logoPictureBox.Location = new System.Drawing.Point(44, 25);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(400, 35);
            this.logoPictureBox.TabIndex = 6;
            this.logoPictureBox.TabStop = false;
            // 
            // LinkLabel
            // 
            this.LinkLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LinkLabel.HoverColor = System.Drawing.Color.Empty;
            this.LinkLabel.Location = new System.Drawing.Point(27, 115);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.RegularColor = System.Drawing.Color.Empty;
            this.LinkLabel.Size = new System.Drawing.Size(225, 14);
            this.LinkLabel.TabIndex = 5;
            this.LinkLabel.Text = "Online at http://www.atomicwasteland.co.uk/";
            this.LinkLabel.Click += new System.EventHandler(this.linkLabel21_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.versionLabel.Location = new System.Drawing.Point(41, 65);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(58, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Version x.x";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // licenseLabel
            // 
            this.licenseLabel.Location = new System.Drawing.Point(27, 147);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(434, 50);
            this.licenseLabel.TabIndex = 4;
            this.licenseLabel.Text = resources.GetString("licenseLabel.Text");
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(27, 97);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(281, 13);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "Copyright © 2012 Atomic Wasteland. All Rights Reserved.";
            // 
            // creditsPage
            // 
            this.creditsPage.AutoScroll = true;
            this.creditsPage.BackgroundImage = global::SmoothTranscode.Properties.Resources.square_bg;
            this.creditsPage.Controls.Add(this.creditsLabel);
            this.creditsPage.Location = new System.Drawing.Point(4, 22);
            this.creditsPage.Name = "creditsPage";
            this.creditsPage.Padding = new System.Windows.Forms.Padding(3);
            this.creditsPage.Size = new System.Drawing.Size(486, 194);
            this.creditsPage.TabIndex = 1;
            this.creditsPage.Text = "Credits";
            this.creditsPage.UseVisualStyleBackColor = true;
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Location = new System.Drawing.Point(20, 20);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(349, 117);
            this.creditsLabel.TabIndex = 0;
            this.creditsLabel.Text = resources.GetString("creditsLabel.Text");
            // 
            // licensePage
            // 
            this.licensePage.Controls.Add(this.licenseBrowser);
            this.licensePage.Location = new System.Drawing.Point(4, 22);
            this.licensePage.Name = "licensePage";
            this.licensePage.Padding = new System.Windows.Forms.Padding(3);
            this.licensePage.Size = new System.Drawing.Size(486, 194);
            this.licensePage.TabIndex = 2;
            this.licensePage.Text = "License";
            this.licensePage.UseVisualStyleBackColor = true;
            // 
            // licenseBrowser
            // 
            this.licenseBrowser.AllowWebBrowserDrop = false;
            this.licenseBrowser.IsWebBrowserContextMenuEnabled = false;
            this.licenseBrowser.Location = new System.Drawing.Point(0, 0);
            this.licenseBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.licenseBrowser.Name = "licenseBrowser";
            this.licenseBrowser.Size = new System.Drawing.Size(494, 220);
            this.licenseBrowser.TabIndex = 0;
            this.licenseBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.licenseBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(494, 268);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hiddenTabsControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About SmoothTranscode";
            this.Load += new System.EventHandler(this.AboutWindow_Load);
            this.aboutPanelMenu.ResumeLayout(false);
            this.aboutPanelMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.hiddenTabsControl.ResumeLayout(false);
            this.aboutPage.ResumeLayout(false);
            this.aboutPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.creditsPage.ResumeLayout(false);
            this.creditsPage.PerformLayout();
            this.licensePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolStrip aboutPanelMenu;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.ToolStripButton creditsButton;
        private System.Windows.Forms.ToolStripButton licenseButton;
        private HiddenTabsControl hiddenTabsControl;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.TabPage creditsPage;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private wyDay.Controls.LinkLabel2 LinkLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label licenseLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.TabPage licensePage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.WebBrowser licenseBrowser;
    }
}