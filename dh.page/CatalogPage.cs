using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using dh.page.Component;
using dh.core.UI.Adapter;

namespace dh.page
{
    public class CatalogPage : BasePage
    {
        WebDriverAdapter driver;
        public CatalogPage(WebDriverAdapter driver) : base(driver)
        {
            this.driver = driver;
        }
        private string _pathInputFilter = "//div[contains(@class,'search-form__input')]";
        private string _pathSearchButton = "//button[text()='Искать']";
        //private string _pathInputFilter = "//input[@class='search-form__input ']";
        public CatalogPage SendTextOnFilterOfNameCourse(string nameCourse)
        {
            var inputFilter = driver.FindElement(_pathInputFilter + "//input");
            inputFilter.Click();
            inputFilter.Clear();
            inputFilter.SendKeys(nameCourse);
            return this;
        }

        public SearchCatalogPage GoToItemComplite(int indexItem)
        {
            var complite = new Complite(driver.FindElement(_pathInputFilter));
            complite.GetItemComplite().ElementAt(indexItem).Value.Click();
            return new SearchCatalogPage(driver);
        }

        public List<string> GetTextItemComplite()
        {
            List<string> listItemText = new List<string>(); 
            var complite = new Complite(driver.FindElement(_pathInputFilter));
            var items = complite.GetItemComplite();

            foreach (var i in items.Keys)
            {
                listItemText.Add(i.ToString());
            }
            return listItemText;
        }

        public SearchCatalogPage ClickToSearchButton()
        {
            driver.FindElement(_pathSearchButton).Click();
            return new SearchCatalogPage(driver);
        }
    }
}
