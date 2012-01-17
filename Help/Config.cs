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

namespace Help
{
    public class Config
    {
        private static string baseURL;
        private static string specifiedPage;

        /// <summary>
        /// The base URL containing the contents page
        /// </summary>
        public static string url
        {
            get
            {
                return baseURL;
            }
            set
            {
                baseURL = value;
            }
        }

        /// <summary>
        /// The suffix of the specific help page, placed after the base URL
        /// </summary>
        public static string page
        {
            get
            {
                return specifiedPage;
            }
            set
            {
                specifiedPage = value;
            }
        }
    }
}
