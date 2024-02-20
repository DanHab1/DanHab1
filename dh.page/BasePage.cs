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
        WebDriverAdapter driver;
        public BasePage(WebDriverAdapter driver)
        {
            this.driver = driver;
            //WaitLoading();
        }

        private string _pathLoading = "//*[contains(@data-loading,'lazy-pending')]";
        protected void WaitLoading()
        {
            //try
            //{
            //    var wait = new WebDriverWait(driver.webDriver, TimeSpan.FromSeconds(10));
            //    wait.Until(driver => driver.FindElements(By.XPath(_pathLoading)).Count == 0);
            //}
            //catch (WebDriverTimeoutException ex) { }
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
    }
}
