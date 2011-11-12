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
