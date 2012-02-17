/*
 *  Copyright (C) 2012 Atomic Wasteland
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
using System.Linq.XML;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace SmoothTranscode
{
    public class ffmpeg
    {
        private ProcessStartInfo ffmpegProcInfo;
        private ProcessStartInfo ffprobeProcInfo;
        private Process ffmpegProcess;
        private Process ffprobeProcess;
        private static string input;
        private static string arguments;
        private static string infoXML = "";
        private static XDocument inputInfo;
        private static bool twopass;
        private static string output;
        private int duration = -1;
        private int pass = 1;
        public event EventHandler conversionEnded;
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs cmdoutput);
        public event ProgressEventHandler progressUpdate;
        public delegate void InfoEventHandler(object sender, InfoEventArgs cmdoutput);
        public event InfoEventHandler infoRetrieved;

        public ffmpeg()
        {
            //FFmpeg process settings
            ffmpegProcInfo = new ProcessStartInfo();
            ffmpegProcInfo.UseShellExecute = false;
            ffmpegProcInfo.RedirectStandardError = true;
            if (IntPtr.Size == 8) //If running on 64-bit system
            	ffmpegProcInfo.FileName = "ffmpeg/ffmpeg-x64.exe";
            else
            	ffmpegProcInfo.FileName = "ffmpeg/ffmpeg-x86.exe";
            ffmpegProcInfo.CreateNoWindow = true;
            //FFprobe process settings
            ffprobeProcInfo = new ProcessStartInfo();
            ffprobeProcInfo.UseShellExecute = false;
            ffprobeProcInfo.RedirectStandardOutput = true;
            if (IntPtr.Size == 8) //If running on 64-bit system
                ffprobeProcInfo.FileName = "ffmpeg/ffprobe-x64.exe";
            else
                ffprobeProcInfo.FileName = "ffmpeg/ffprobe-x86.exe";
            ffprobeProcInfo.CreateNoWindow = true;
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

        public static bool twoPass
        {
            get
            {
                return twopass;
            }
            set
            {
                twopass = value;
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
        
        public void GetInfo()
        {
            ffprobeProcInfo.Arguments = "-print_format xml -show_streams -i \"" + input + "\"";
            ffprobeProcess = new Process();
            ffprobeProcess.StartInfo = ffprobeProcInfo;
            ffprobeProcess.EnableRaisingEvents = true;
            ffprobeProcess.Exited += new EventHandler(FfprobeProcessExited);
            ffprobeProcess.OutputDataReceived += new DataReceivedEventHandler(PopulateInfo);
            ffprobeProcess.Start();
            ffprobeProcess.BeginOutputReadLine();
        }

        private void PopulateInfo(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                infoXML += e.Data;
            }
        }

        public class InfoEventArgs : EventArgs
        {
            private string xmlOutput;

            public InfoEventArgs(string xml)
            {
                xmlOutput = xml;
            }

            public string XML()
            {
                return xmlOutput;
            }
        } 

        protected virtual void FfprobeProcessExited(object sender, EventArgs e)
        {
            ffprobeProcess.CancelOutputRead();
            inputInfo = XDocument.Parse(infoXML);
            if (infoRetrieved != null)
                infoRetrieved(this, new InfoEventArgs(infoXML));
        }

        public void ConvertFile()
        {
            if (twopass)
                ffmpegProcInfo.Arguments = "-i \"" + input + "\" -pass " + pass.ToString() + " " + arguments + " -y \"" + output + "\"";
            else
                ffmpegProcInfo.Arguments = "-i \"" + input + "\" " + arguments + " -y \"" + output + "\"";
            ffmpegProcess = new Process();
            ffmpegProcess.StartInfo = ffmpegProcInfo;
            ffmpegProcess.EnableRaisingEvents = true;
            ffmpegProcess.Exited += new EventHandler(FfmpegProcessExited);
            ffmpegProcess.ErrorDataReceived += new DataReceivedEventHandler(ParseProgress);
            ffmpegProcess.Start();
            ffmpegProcess.BeginErrorReadLine();
        }

        private void ParseProgress(object sender, DataReceivedEventArgs e)
        {
            int percentage;
            string fps;
            string bitrate;
            TimeSpan currentTime;
            TimeSpan totalTime;

            if (e.Data != null)
            {
                if (duration != -1)
                {
                    if (e.Data.Contains("time"))
                    {
                        //Percentage
                        TimeSpan.TryParse(GetStringInBetween("time=", " bitrate=", e.Data), out currentTime);
                        percentage = Convert.ToInt32(currentTime.TotalSeconds);
                        percentage = percentage * 100 / duration;
                        if (twopass)
                            if (pass == 1)
                                percentage = percentage / 2;
                            else
                                percentage = (percentage / 2) + 50;
                        //Frames per second
                        fps = GetStringInBetween("fps=", " q=", e.Data).Trim();
                        //Bitrate
                        bitrate = GetStringInBetween("bitrate=", "its/s", e.Data).Trim();
                        bitrate += "/s";
                        //Update progress
                        ProgressUpdate(this, new ProgressEventArgs(percentage, fps, bitrate, pass));
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
            private int percentageOutput;
            private string fpsOutput;
            private string bitrateOutput;
            private int passOutput;

            public ProgressEventArgs(int percentage, string fps, string bitrate, int pass)
            {
                percentageOutput = percentage;
                fpsOutput = fps;
                bitrateOutput = bitrate;
                passOutput = pass;
            }

            public int Percentage()
            {
                return percentageOutput;
            }

            public string FPS()
            {
                return fpsOutput;
            }

            public string Bitrate()
            {
                return bitrateOutput;
            }

            public int Pass()
            {
                return passOutput;
            }
        } 

        protected virtual void FfmpegProcessExited(object sender, EventArgs e)
        {
            ffmpegProcess.CancelErrorRead();
            if (twopass && pass == 1)
            {
                pass = 2;
                ConvertFile();
            }
            else
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