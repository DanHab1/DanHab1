using dh.core.UI.Adapter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Component
{
    public class Complite : BaseComponent<Complite>
    {
        IWebElement element { get; set; }
        WebDriverWrapper driver { get; set; }

        Dictionary<string, IWebElement> compliteItems;
        string placeHolderName;

        //private string _complites = "//ul[contains(@class,'menu') and contains(@class,'drop-down-content')]";\
        private string _inputOfComplites = "//*[contains(@class,'with-autocomplete__content')]//input";
        //private string _complites = "//*[contains(@class,'with-autocomplete__content')]";
        private string _complites = "//*[contains(@class,'drop-down-menu')]";


        public Complite(WebDriverWrapper driver, string placeHolderName) : base()
        {
            this.driver = driver;
            this.placeHolderName = placeHolderName;
            compliteItems = new Dictionary<string, IWebElement>();
            element = GetComplite(this.placeHolderName);
        }

        //private IWebElement GetComplite(string placeHolderName) =>
        //    driver.FindElements(_complites)            
        //    .Where(x => x.FindElement(By.XPath(".//child::input")).GetAttribute("placeholder") == placeHolderName)
        //    .First();
        //.FindElement(By.XPath(".//ul"));

        private IWebElement GetComplite(string placeHolderName) => 
            driver.FindElements(_inputOfComplites).Where(x => x.GetDomProperty("placeholder") == placeHolderName).First();

        public Dictionary<string, IWebElement> GetItemComplite()
        {
            var items = element.FindElements(By.XPath(".//..//..//..//child::li"));

            foreach (var item in items) 
            {
                compliteItems.Add(item.GetAttribute("innerText"), item);
            }
            return compliteItems;
        }

        public Dictionary<string, IWebElement> SendTextToComplite(string text)
        {
            //var inputFilter = element.FindElement(By.XPath(".//input"));
            element.Click();
            element.Clear();
            element.SendKeys(text);
            return GetItemComplite();
        }

    }
}
