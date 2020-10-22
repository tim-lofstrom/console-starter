using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class GlobalSettings
    {
        public bool Auto
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["auto"]);
            }
            set
            {
                ConfigurationManager.AppSettings["auto"] = value.ToString();
            }
        }
    }
}
