using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.core.Config
{
    public class WebConfig : IConfig
    {
        public static WebConfig INSTANCE = new WebConfig();
        private WebConfig() { }

        //Добавить опции для браузера

        public string GetWebUrl()
        {
            return "https://stepik.org/";
        }

        public string GetBrowserName()
        {
            return "chrome";
        }
    }
}
