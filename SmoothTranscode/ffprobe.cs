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

        private static string StripNonValidXMLCharacters(string textIn)
        {
            StringBuilder textOut = new StringBuilder();
            char current;

            if (textIn == null || textIn == string.Empty)
                return string.Empty;

            for (int i = 0; i < textIn.Length; i++)
            {
                current = textIn[i];

                if ((current == 0x9 || current == 0xA || current == 0xD) || ((current >= 0x20) && (current <= 0xD7FF)) || ((current >= 0xE000) && (current <= 0xFFFD)))
                {
                    textOut.Append(current);
                }
            }

            return textOut.ToString();
        } 

        public class InfoEventArgs : EventArgs
        {
            XDocument inputInfo = XDocument.Parse(StripNonValidXMLCharacters(infoXML));
            
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

            public string width()
            {
                var width = from node in inputInfo.Descendants("stream")
                             where (string)node.Attribute("codec_type") == "video"
                             select (string)node.Attribute("width");
                string result = String.Empty;

                foreach (var node in width)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string height()
            {
                var height = from node in inputInfo.Descendants("stream")
                             where (string)node.Attribute("codec_type") == "video"
                             select (string)node.Attribute("height");
                string result = String.Empty;

                foreach (var node in height)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
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
                string resultString = String.Empty;
                float result;

                foreach (var node in rate)
                {
                    if (resultString == String.Empty)
                        resultString = node;
                }

                if (resultString != String.Empty)
                {
                    string[] values = resultString.Split('/');
                    result = Convert.ToSingle(values[0]) / Convert.ToSingle(values[1]);
                }
                else
                    result = 0;


                return result.ToString();
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

            public string metadataTitle()
            {
                var title = from node in inputInfo.Descendants("tag")
                            where (string)node.Attribute("key") == "title"
                            select (string)node.Attribute("value");
                string result = String.Empty;

                foreach (var node in title)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string metadataArtist()
            {
                var artist = from node in inputInfo.Descendants("tag")
                            where (string)node.Attribute("key") == "artist"
                            select (string)node.Attribute("value");
                string result = String.Empty;

                foreach (var node in artist)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string metadataAlbum()
            {
                var album = from node in inputInfo.Descendants("tag")
                            where (string)node.Attribute("key") == "album"
                            select (string)node.Attribute("value");
                string result = String.Empty;

                foreach (var node in album)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string metadataCopyright()
            {
                var copyright = from node in inputInfo.Descendants("tag")
                            where (string)node.Attribute("key") == "copyright"
                            select (string)node.Attribute("value");
                string result = String.Empty;

                foreach (var node in copyright)
                {
                    if (result == String.Empty)
                        result = node;
                }

                return result;
            }

            public string metadataComment()
            {
                var comment = from node in inputInfo.Descendants("tag")
                            where (string)node.Attribute("key") == "comment"
                            select (string)node.Attribute("value");
                string result = String.Empty;

                foreach (var node in comment)
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
