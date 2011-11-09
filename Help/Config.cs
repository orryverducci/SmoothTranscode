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
