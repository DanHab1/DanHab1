using dh.core.UI.Adapter;
using dh.page.Model;
using dh.page.Model.Dto;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page
{
    public class AuthorInfoPage : BasePage
    {
        WebDriverWrapper driver;
        public AuthorInfoPage(WebDriverWrapper driver) : base(driver)
        {
            this.driver = driver;
        }

        private string _pathListCourseItems = "//li[@class='course-cards__item']";

        public List<CardAuthorAndCardCatalogDto> GetCourseOfAuthorModels()
        {
            driver.WaitElement(_pathListCourseItems, 10);
            var courseModels = new List<CardAuthorAndCardCatalogDto>();
            var items = driver.FindElements(_pathListCourseItems);
            foreach (var item in items)
            {
                var card = item.GetAttribute("innerText").Split("\r\n");
                CardAuthorAndCardCatalogDto cardDto = new CardAuthorAndCardCatalogDto()
                {
                    Title = card[0] ?? throw new Exception("Не удалось получить заголовок карточки курса"),
                    Author = card[1],
                    Price = card[card.Length - 1],
                    ElementModel = item
                };

                courseModels.Add(cardDto);
            }
            return courseModels;
        }

    }
}
