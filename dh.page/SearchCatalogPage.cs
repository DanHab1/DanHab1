using dh.core.Helper.WebHelper.Js;
using dh.core.UI.Adapter;
using dh.page.Component;
using dh.page.Model;
using dh.page.Model.Dto;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dh.page
{
    public class SearchCatalogPage : BasePage
    {
        WebDriverWrapper driver;
        public SearchCatalogPage(WebDriverWrapper driver) : base(driver)
        {
            this.driver = driver;
        }

        List<CardAuthorAndCardCatalogDto> courseModels = new List<CardAuthorAndCardCatalogDto>();

        private string _pathCourseCardsItems = "//div[contains(@class,'catalog-block')]//ul";
        private string _pathAuthorLink = "//a[@class='course-card__author']";
        private string _pathFilterBar = "//div[@class='applied-filters catalog__applied-filters-bar']";

        public List<CardAuthorAndCardCatalogDto> GetModelsSearchCourseItems()
        {
            for(int i = 0; i < 3; i++) //Временное решение загрузки страницы со скроллом
            {
                JSWebHelper.ScrollWindow(driver.webDriver, 0, 1000);
                Thread.Sleep(1500); 
            }
            
            var items = driver.FindElement(_pathCourseCardsItems).FindElements(By.XPath(".//li"));
            foreach(var item in items)
            {
                var card = item.GetAttribute("innerText").Split("\r\n");
                CardAuthorAndCardCatalogDto cardDto = new CardAuthorAndCardCatalogDto()
                {
                    Title = card[0] ?? throw new Exception("Не удалось получить заголовок карточки курса"),
                    Author = card[1],
                    Price = card[card.Length - 1],
                    ElementModel = item
                };
                //SearchCardCourseModel cardModel = new SearchCardCourseModel()
                //{
                //    Title = card[0] ?? throw new Exception("Не удалось получить заголовок карточки курса"),
                //    Author = card[1],
                //    //Description = card[2],
                //    Price = card[card.Length - 1],
                //    //IsWithSertificate = card[card.Length - 3] == "сертификат" ? true : false,
                //    ElementModel = item
                //};
                courseModels.Add(cardDto);
            }
            return courseModels;
        }

        public AuthorInfoPage GoToAuthorInfo(int indexItem)
        {
            var element = driver.FindElements(_pathAuthorLink).ElementAt(indexItem);
            JSWebHelper.ForcedClickOnElement(driver.webDriver, element);
            return new AuthorInfoPage(driver);
        }

        public SearchCatalogPage SetCheckbox(string nameCheckbox, bool value)
        {
            var checkbox = new Checkbox(driver, nameCheckbox);
            checkbox
                .SetCheckbox(value);
            return this;
        }

        public IEnumerable<string> GetTitleAppliedFilterBar() =>
            driver.FindElement(_pathFilterBar).FindElements(By.XPath("//*[@class='applied-filters-badge__title']"))
                .Select(x => x.GetAttribute("innerText"));
    }
}
