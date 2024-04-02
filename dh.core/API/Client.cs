using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dh.core.Config;
using OpenQA.Selenium.DevTools.V119.Storage;
using RestSharp;

namespace dh.core.API
{
    public class Client
    {
        public RestClient client { get; }
        private readonly IConfig webConfig = IConfig.getConfig();

        public Client() 
        {
            RestClientOptions options = new RestClientOptions()
            {
                BaseUrl = new Uri(webConfig.GetWebUrl()),
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 YaBrowser/24.1.0.0 Safari/537.36"
            };
            client = new RestClient(options);
        }
    }
}
