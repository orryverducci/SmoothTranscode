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
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace SmoothTranscode
{
    public class ffmpeg
    {
        private ProcessStartInfo procInfo;
        public Process ffmpegProcess;
        private static string input;
        private static string arguments;
        private static string output;
        public event EventHandler ConversionEnded;

        public ffmpeg()
        {
            procInfo = new ProcessStartInfo();
            procInfo.UseShellExecute = true;
            procInfo.FileName = "ffmpeg.exe";
        }

        public static string inputFile
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
            }
        }

        public static string procArguments
        {
            get
            {
                return arguments;
            }
            set
            {
                arguments = value;
            }
        }

        public static string outputFile
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }

        public void ConvertFile()
        {
            procInfo.Arguments = "-i \"" + input + "\"" + arguments + " -y \"" + output + "\"";
            //procInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ffmpegProcess = new Process();
            ffmpegProcess.StartInfo = procInfo;
            ffmpegProcess.EnableRaisingEvents = true;
            ffmpegProcess.Exited += new EventHandler(ffmpegProcess_Exited);
            ffmpegProcess.Start();
        }

        public void CancelConversion()
        {
            if (!ffmpegProcess.HasExited)
            {
                ffmpegProcess.Kill();
            }
        }

        protected virtual void OnProcessExit(EventArgs e)
        {
            if (ConversionEnded != null)
                ConversionEnded(this, e);
        }

        private void ffmpegProcess_Exited(object sender, System.EventArgs e)
        {
            OnProcessExit(new EventArgs());
        }
    }
}