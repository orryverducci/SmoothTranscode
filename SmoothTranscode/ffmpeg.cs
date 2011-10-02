/*
 *  Copyright (C) 2011 Atomic Wasteland
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SmoothTranscode
{
    public class ffmpeg
    {
        private ProcessStartInfo procInfo;
        public Process ffmpegProcess;
        private static string input;
        private static string arguments;
        private static string output;
        private int duration = -1;
        public event EventHandler conversionEnded;
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs cmdoutput);
        public event ProgressEventHandler progressUpdate;

        public ffmpeg()
        {
            procInfo = new ProcessStartInfo();
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardError = true;
            if (IntPtr.Size == 8)
            	procInfo.FileName = "ffmpeg/ffmpeg-x64.exe";
            else
            	procInfo.FileName = "ffmpeg/ffmpeg-x86.exe";
            procInfo.CreateNoWindow = true;
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
            procInfo.Arguments = "-i \"" + input + "\" " + arguments + " -y \"" + output + "\"";
            ffmpegProcess = new Process();
            ffmpegProcess.StartInfo = procInfo;
            ffmpegProcess.EnableRaisingEvents = true;
            ffmpegProcess.Exited += new EventHandler(FfmpegProcessExited);
            ffmpegProcess.ErrorDataReceived += new DataReceivedEventHandler(ParseOutput);
            ffmpegProcess.Start();
            ffmpegProcess.BeginErrorReadLine();
        }

        private void ParseOutput(object sender, DataReceivedEventArgs e)
        {
            int percentage;
            TimeSpan currentTime;
            TimeSpan totalTime;

            if (e.Data != null)
            {
                if (duration != -1)
                {
                    if (e.Data.Contains("time"))
                    {
                        TimeSpan.TryParse(GetStringInBetween("time=", " bitrate=", e.Data), out currentTime);
                        percentage = Convert.ToInt32(currentTime.TotalSeconds);
                        percentage = percentage * 100 / duration;
                        ProgressUpdate(this, new ProgressEventArgs(percentage));
                    }
                }
                else
                {
                    if (e.Data.Contains("Duration"))
                    {
                        totalTime = TimeSpan.Parse(GetStringInBetween("Duration: ", ", start", e.Data));
                        duration = Convert.ToInt32(totalTime.TotalSeconds);
                    }
                }
            }
        }

		private string GetStringInBetween(string strBegin, string strEnd, string strSource)           
        {
            string result = "";
            int iIndexOfBegin = strSource.IndexOf(strBegin);
            if (iIndexOfBegin != -1)
            {
                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);
                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
                    result = strSource.Substring(0, iEnd);
				}
            }
            return result;
        }
		
        public void CancelConversion()
        {
            ffmpegProcess.Kill();
            Thread.Sleep(500);
            System.IO.File.Delete(output);
        }

        public class ProgressEventArgs : EventArgs
        {
            private int encoderOutput;

            public ProgressEventArgs(int result)
            {
                encoderOutput = result;
            }

            public int EncoderOutput()
            {
                return encoderOutput;
            }
        } 

        protected virtual void FfmpegProcessExited(object sender, EventArgs e)
        {
            ffmpegProcess.CancelErrorRead();
            if (conversionEnded != null)
                conversionEnded(this, e);
        }

        protected virtual void ProgressUpdate(object sender, ProgressEventArgs e)
        {
            if (progressUpdate != null)
                progressUpdate(this, e);
        }
    }
}