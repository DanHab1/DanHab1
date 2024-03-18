using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Internal;
using dh.core.Config;
using OpenQA.Selenium.Support.UI;
using dh.core.Helper.WebHelper.Js;

namespace dh.core.UI.Adapter
{
    public class WebDriverWrapper // : IWebDriver
    {
        public WebDriver webDriver;
        private readonly IConfig webConfig = IConfig.getConfig();

        public WebDriver CreateDriver()
        {
            if (webDriver?.SessionId == null)
            {
                if(webConfig.GetBrowserName() == "chrome")
                {
                    webDriver = new ChromeDriver();
                }
                else{
                    throw new Exception("Не найден драйвер браузера");
                }
                //webDriver = new EdgeDriver();
                return webDriver;
            }

            else return webDriver;
        }

        public void DeleteDriver()
        {
            if (webDriver.SessionId.ToString() == null) return;
            else webDriver.Quit();
        }

        public WebDriverWrapper ManageDriver()
        {
            webDriver.Manage().Window.Maximize();
            return this;
        }

        public WebDriverWrapper NavigateToDriver(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public IWebElement FindElement(string XPathLocator)
        {
            try
            {
                var element = webDriver.FindElement(By.XPath(XPathLocator));
                //JSWebHelper.ExecuteJsScript(webDriver, element, "arguments[0].style.backgroundColor = 'yellow'");
                JSWebHelper.ChangeColorElement(webDriver, element, "yellow");
                return element;
            }
            catch (NoSuchElementException)
            {
                throw new Exception($"Не найден элемент {XPathLocator}");
            }

        }

        public List<IWebElement> FindElements(string XPathLocator)
        {
            try
            {
                var element = webDriver.FindElements(By.XPath(XPathLocator)).ToList();
                //JSWebHelper.ExecuteJsScript(webDriver, element[0], "arguments[0].style.backgroundColor = 'yellow'");
                JSWebHelper.ChangeColorElement(webDriver, element.First(), "yellow");
                return element;
            }
            catch (NoSuchElementException)
            {
                throw new Exception($"Не найден элемент {XPathLocator}");
            }

        }

        public WebDriverWrapper Wait(int time)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            return this;
        }

        public void WaitElement(string xpathElement, int time)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(time));
            var myDynamicElement = wait.Until(d => webDriver.FindElement(By.XPath(xpathElement)).Displayed);
        }

        public string GetCurrentUrl() => webDriver.Url;

        public WebDriverWrapper GoToTab(int indexTab)
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles[indexTab]);
            return this;
        }
        
    }
}
