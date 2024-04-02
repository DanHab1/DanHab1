using dh.core.UI.Adapter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dh.page.Component
{
    public class Header : BaseComponent<Header>
    {
        IWebElement element;
        WebDriverWrapper driver;

        //private string _catalogButton = "ember156";
        //private string _learnButton = "ember145";
        //private string _searchCourseComplite = "ember3501";
        private string _header = "//nav[@id='main-navbar']";
        private string _searchInput = "//header//child::input[contains(@class,'navbar__search-input')]";


        public Header(WebDriverWrapper driver) : base()
        {
            this.driver = driver;
            element = GetHeader();
        }

        private IWebElement GetHeader() => driver.webDriver.FindElement(By.XPath(_header));

        public Header GetTab(string nameTitle)
        {
            element = element.FindElements(By.XPath(".//a")).Where(x => x.GetDomProperty("innerText") == nameTitle).First();
            return this;
        }

        public void OpenTab() => element.Click();


        //public LearnPage OpenLearn()
        //{
        //    driver.webDriver.FindElement(By.Id(_learnButton)).Click();
        //    return new LearnPage(driver);
        //}
        //public LearnPage OpenTeaching()
        //{
        //    driver.webDriver.FindElement(By.Id(_learnButton)).Click();
        //    return new LearnPage(driver);
        //}

        public SearchCatalogPage SearchInputSendText(string text)
        {
            var inputSearch = driver.FindElement(_searchInput);
            inputSearch.Click();
            inputSearch.Clear();
            inputSearch.SendKeys(text);

            var searchComplite = new Complite(driver, "Поиск...");
            searchComplite.GetItemComplite().ElementAt(1).Value.Click();
            return new SearchCatalogPage(driver);
        }

        public List<string> GetTitleOfTabs()
        {
            List<string> names = new List<string>();
            var tabs = element.FindElements(By.XPath(".//a"));
            foreach( var tab in tabs )
                names.Add(tab.GetAttribute("innerText"));
            return names;
        }

    }
}
