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
        private string duration;
        public event EventHandler conversionEnded;
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs cmdoutput);
        public event ProgressEventHandler progressUpdate;

        public ffmpeg()
        {
            procInfo = new ProcessStartInfo();
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardError = true;
            procInfo.FileName = "ffmpeg.exe";
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
            procInfo.Arguments = "-i \"" + input + "\"" + arguments + " -y \"" + output + "\"";
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
            if (e.Data != null)
            {
                if (duration != null)
                {
                    if (e.Data.Contains("time"))
                    {
                        ProgressUpdate(this, new ProgressEventArgs(GetStringInBetween("time=", " bitrate=", e.Data, false, false)[0]));
                    }
                }
                else
                {
                    if (e.Data.Contains("duration"))
                    {
                        duration = GetStringInBetween("duration: ", ", start", e.Data, false, false)[0];
                    }
                }
            }
        }

		private string[] GetStringInBetween(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)           
        {
            string[] result =
			{
			    "",
				""
			};
            int iIndexOfBegin = strSource.IndexOf(strBegin);
            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired
                if (includeBegin)
                    iIndexOfBegin -= strBegin.Length;
                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);
                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
				    // include the End string if desired
                    if (includeEnd)
                        iEnd += strEnd.Length;
                    result[0] = strSource.Substring(0, iEnd);
                    // advance beyond this segment
                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);
				}
            }
            else
            // stay where we are
            result[1] = strSource;
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
            private string encoderOutput;

            public ProgressEventArgs(string result)
            {
                encoderOutput = result;
            }

            public string EncoderOutput()
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