using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.core.Helper.WebHelper.Js
{
    public static class JSWebHelper
    {
        static IJavaScriptExecutor executor;
        public static void ScrollWindow(WebDriver driver, int scrollX, int scrollY)
        {
            executor = driver as IJavaScriptExecutor;
            if (executor != null)
            {
                executor.ExecuteScript($"window.scrollBy({scrollX},{scrollY});");
            }
        }

        public static void ExecuteJsScript(WebDriver driver, IWebElement element, string script)
        {
            executor = driver as IJavaScriptExecutor;
            if (executor != null)
            {
                executor.ExecuteScript(script, element);
            }
        }

        public static void ChangeColorElement(WebDriver driver, IWebElement element, string colorName)
        {
            executor = driver as IJavaScriptExecutor;
            if (executor != null)
            {
                try
                {
                    var beforeColor = element.GetCssValue("backgroundColor");
                    executor.ExecuteScript($"arguments[0].style.backgroundColor = '{colorName}'", element);
                    Thread.Sleep(100);
                    executor.ExecuteScript($"arguments[0].style.backgroundColor = '{beforeColor}'", element);
                }
                catch { }
            }
        }

        public static void ForcedClickOnElement(WebDriver driver, IWebElement element)
        {
            executor = driver as IJavaScriptExecutor;
            if (executor != null)
            {
                var beforeColor = element.GetCssValue("backgroundColor");
                executor.ExecuteScript($"arguments[0].click();", element);
            }
        }
    }
}
