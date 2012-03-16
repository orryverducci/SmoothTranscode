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

namespace SmoothTranscode
{
    class logger
    {
        System.IO.StreamWriter logFile;

        public logger()
        {
            string appDataFolder = Environment.GetEnvironmentVariable("LocalAppData");
            logFile = new System.IO.StreamWriter(appDataFolder + "\\SmoothTranscode\\encode.log");
            log("Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(3));
            if (IntPtr.Size == 8) //If running on 64-bit system
                log("Architecture: 64 bit");
            else
                log("Architecture: 32 bit");
            log("Operating System: " + System.Environment.OSVersion);
        }

        public void log(string line)
        {
            logFile.WriteLine(line);
        }

        public void finishLog()
        {
            logFile.Close();
        }
    }
}
