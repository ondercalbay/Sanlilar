using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanlilar.CommonLibrary.Helpers
{
    public static class ConfigHelper
    {
        public static string Read(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
