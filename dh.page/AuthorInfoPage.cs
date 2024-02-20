using dh.core.UI.Adapter;
using dh.page.Model;
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
        WebDriverAdapter driver;
        public AuthorInfoPage(WebDriverAdapter driver) : base(driver)
        {
            this.driver = driver;
        }

        private string _pathListCourseItems = "//li[@class='course-cards__item']";

        public List<SearchCardCourseModel> GetCourseOfAuthorModels()
        {
            driver.WaitElement(_pathListCourseItems, 10);
            var courseModels = new List<SearchCardCourseModel>();
            var items = driver.FindElements(_pathListCourseItems);
            foreach (var item in items)
            {
                var card = item.GetAttribute("innerText").Split("\r\n");
                SearchCardCourseModel cardModel = new SearchCardCourseModel()
                {
                    Title = card[0] ?? throw new Exception("Не удалось получить заголовок карточки курса"),
                    Author = card[1],
                    Price = card[card.Length - 1],
                    ElementModel = item
                };
                courseModels.Add(cardModel);
            }
            return courseModels;
        }

    }
}
