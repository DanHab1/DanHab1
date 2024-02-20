using dh.core.UI.Adapter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Component
{
    public class Header : BaseComponent<Header>
    {
        IWebElement element;
        WebDriverAdapter driver;

        private string _catalogButton = "ember156";
        private string _learnButton = "ember145";
        private string _searchInput = "//header//child::input[contains(@class,'navbar__search-input')]";
        private string _searchCourseComplite = "ember3501";

        public Header(IWebElement element) : base(element)
        {
            this.element = element;
        }
        public CatalogPage OpenCatalog()
        {
            driver.webDriver.FindElement(By.Id(_catalogButton)).Click();
            return new CatalogPage(driver);
        }

        public LearnPage OpenLearn()
        {
            driver.webDriver.FindElement(By.Id(_learnButton)).Click();
            return new LearnPage(driver);
        }

        public SearchCatalogPage SearchInputSendText(string text)
        {
            var inputSearch = driver.FindElement(_searchInput);
            inputSearch.Click();
            inputSearch.Clear();
            inputSearch.SendKeys(text);

            var searchComplite = new Complite(driver.FindElement(_searchCourseComplite));
            searchComplite.GetItemComplite().ElementAt(1).Value.Click();
            return new SearchCatalogPage(driver);
        }

    }
}
