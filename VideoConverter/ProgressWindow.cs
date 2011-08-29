﻿/* 
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

namespace SmoothTranscode
{
    public partial class ProgressWindow : Form
    {
        private ffmpeg ffmpegConverter = new ffmpeg();
        private bool ended = false;

        public ProgressWindow()
        {
            InitializeComponent();
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {
            ffmpegConverter.ConvertFile();
            ffmpegConverter.conversionEnded += new EventHandler(ConversionEnded);
            ffmpegConverter.progressUpdate += new EventHandler(ProgressUpdate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ended)
            {
                if (MessageBox.Show("Are you sure you want to cancel this conversion?", "Cancel Conversion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    ffmpegConverter.CancelConversion();
                    e.Cancel = true;
                }
            }
        }

        private void ConversionEnded(object sender, EventArgs e)
        {
            ended = true;
            BeginInvoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }

        private void ProgressUpdate(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                label1.Text = "it works";
            });
        }
    }
}
