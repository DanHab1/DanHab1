using dh.core.UI.Adapter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page
{
    public class BasePage
    {
        WebDriverWrapper driver;
        IWebElement element;
        public BasePage(WebDriverWrapper driver)
        {
            this.driver = driver;
            //WaitLoading();
        }

        private string _pathLoading = "//*[contains(@data-loading,'lazy-pending')]";
        protected void WaitLoading()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var load = driver.FindElement(_pathLoading);
                    if (load.Displayed)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch { }
        }

        protected IWebElement GetInput(string placeholderName) =>
            driver.FindElements("//input").Where(x => x.GetAttribute("placeholder") == placeholderName).First();

        protected IWebElement GetButton(string buttonName) => 
            driver.FindElements("//button").Where(x => x.GetAttribute("innerText") == buttonName).First();
    }
}
