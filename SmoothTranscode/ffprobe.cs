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
using System.Text;
using System.Diagnostics;
using System.Xml.Linq;

namespace SmoothTranscode
{
    class ffprobe
    {
        private ProcessStartInfo ffprobeProcInfo;
        private Process ffprobeProcess;
        private static string infoXML = "";
        public delegate void InfoEventHandler(object sender, InfoEventArgs cmdoutput);
        public event InfoEventHandler infoRetrieved;

        public ffprobe()
        {
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

        public void GetInfo(string input)
        {
            infoXML = String.Empty;
            ffprobeProcInfo.Arguments = "-print_format xml -show_streams -show_format -i \"" + input + "\"";
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
            XDocument inputInfo = XDocument.Parse(infoXML);

            public string format()
            {
                var codec = from node in inputInfo.Descendants("format")
                            select (string)node.Attribute("format_long_name");
                string result = String.Empty;

                foreach (var node in codec)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string videoCodec()
            {
                var codec = from node in inputInfo.Descendants("stream")
                            where (string)node.Attribute("codec_type") == "video"
                            select (string)node.Attribute("codec_long_name");
                string result = String.Empty;

                foreach (var node in codec)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string resolution()
            {
                var width = from node in inputInfo.Descendants("stream")
                            where (string)node.Attribute("codec_type") == "video"
                            select (string)node.Attribute("width");
                var height = from node in inputInfo.Descendants("stream")
                             where (string)node.Attribute("codec_type") == "video"
                             select (string)node.Attribute("height");
                string widthStr = String.Empty;
                string heightStr = String.Empty;

                foreach (var node in width)
                {
                    if (widthStr == String.Empty)
                        widthStr = node;
                }

                foreach (var node in height)
                {
                    if (heightStr == String.Empty)
                        heightStr = node;
                }

                return widthStr + "x" + heightStr;
            }

            public string aspectRatio()
            {
                var ratio = from node in inputInfo.Descendants("stream")
                            where (string)node.Attribute("codec_type") == "video"
                            select (string)node.Attribute("display_aspect_ratio");
                string result = String.Empty;

                foreach (var node in ratio)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string frameRate()
            {
                var rate = from node in inputInfo.Descendants("stream")
                           where (string)node.Attribute("codec_type") == "video"
                           select (string)node.Attribute("r_frame_rate");
                string result = String.Empty;

                foreach (var node in rate)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string audioCodec()
            {
                var codec = from node in inputInfo.Descendants("stream")
                            where (string)node.Attribute("codec_type") == "audio"
                            select (string)node.Attribute("codec_long_name");
                string result = String.Empty;

                foreach (var node in codec)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string channels()
            {
                var channels = from node in inputInfo.Descendants("stream")
                               where (string)node.Attribute("codec_type") == "audio"
                               select (string)node.Attribute("channels");
                string result = String.Empty;

                foreach (var node in channels)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string sampleRate()
            {
                var rate = from node in inputInfo.Descendants("stream")
                           where (string)node.Attribute("codec_type") == "audio"
                           select (string)node.Attribute("sample_rate");
                string result = String.Empty;

                foreach (var node in rate)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }
        }

        protected virtual void FfprobeProcessExited(object sender, EventArgs e)
        {
            ffprobeProcess.CancelOutputRead();
            if (infoRetrieved != null)
                infoRetrieved(this, new InfoEventArgs());
        }
    }
}
