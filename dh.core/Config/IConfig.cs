using dh.core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace dh.core.Config
{
    public interface IConfig
    {
        static string NAMEPROJECT { get; } = "dh";

        //Временное решение, пока только для web
        static string ENV { get; } = "WEB";
        static IConfig getConfig()
        {
            if(ENV == "WEB")
            {
                return WebConfig.INSTANCE;
            }
            else
            {
                throw new ExceptionCore("Отсутствует заданное окружение");
            }
        }

        string GetWebUrl();
        string GetBrowserName();
    }
}
