using dh.page;
using OpenQA.Selenium;
using System.ComponentModel;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace dh.test.UI.Suite
{
    [AllureSuite("UI")]
    public class FilterTest : BaseTest
    {
        [AllureName("Фильтрация")]
        [DisplayName("Фильтрация по наименованию курса")]
        [Test]
        [TestCase("python")]
        [TestCase("sql")]
        /* 
         * Кейс:
         * 1) Открыть страницу каталога
         * 2) Ввести наименование курса в инпут фильтра
         * 3) Выбрать запись из комплита
         * 4) Проверить результат фильтра на предмет наличия введенного наименования курса
         * Ожидаемое поведение системы:
         * Выводятся записи с учетом фильтрации по наименованию курса (или описания)
         */
        public void FilterToNameCourse(string nameCourse)
        {
            string rez = "";

            CatalogPage catalogPage = new CatalogPage(driver);
            var itemsFilterCourse = catalogPage
                .SendTextOnFilterOfNameCourse(nameCourse)
                .GoToItemComplite(1)
                .GetModelsSearchCourseItems();
            
            foreach (var item in itemsFilterCourse)
                if (!item.Title.ToLower().Contains(nameCourse.ToLower()))
                    rez += item.Title; 

            Assert.IsTrue(rez != "",
                $"При фильтрации обнаружен курсы, которые не содержат наименования по фильтрованной теме:\nФильтр: {nameCourse.ToLower()}\nРезультат: {rez}");
        }

        /* 
        * Кейс:
        * 1) Открыть страницу каталога
        * 2) Ввести автора курса в инпут фильтра
        * 3) Выбрать 1 запись из комплита
        * 4) Открыть страницу автора
        * 5) Сравнить курсы, выданные при фильтрации по автору и курсы на странице автора
        * Ожидаемое поведение системы:
        * Выводятся все курсы, которые есть у автора
        */
        [AllureName("Фильтрация")]
        [DisplayName("Фильтрация по автору курса")]
        [Test]
        [TestCase("Дальневосточный федеральный университет")]
        [TestCase("TechTutors")]
        public void FilterToAuthorCourse(string nameAuthor)
        {
            string rez = "";

            CatalogPage catalogPage = new CatalogPage(driver);
            var searchCataologPage = catalogPage.SendTextOnFilterOfNameCourse(nameAuthor)
                .ClickToSearchButton();

            var itemsFilterCourse = searchCataologPage
                .GetModelsSearchCourseItems()
                .OrderBy(x => x.Title);

            var itemsAuthorCourse = searchCataologPage
                .GoToAuthorInfo(0)
                .GetCourseOfAuthorModels()
                .OrderBy(x => x.Title);

            Assert.IsTrue(itemsFilterCourse.Count() == itemsAuthorCourse.Count(),
                $"Не совпадают кол-во курсов у автора и при фильтрации в каталоге\nПри фильтрации кол-во записей: {itemsFilterCourse.Count()}\nУ Автора кол-во курсов: {itemsAuthorCourse.Count()}");

            for (int i = 0; i < itemsFilterCourse.Count(); i++)
                if (itemsFilterCourse.ElementAt(i).ToString() == itemsAuthorCourse.ElementAt(i).ToString())
                    rez += itemsFilterCourse.ElementAt(i).ToString() + itemsAuthorCourse.ElementAt(i).ToString();

            Assert.IsTrue(rez != "", $"Не совпадают курсы в карточке автора и при фильтрации в каталоге:\n{rez}");
        }

        /* 
        * Кейс:
        * 1) Открыть страницу каталога
        * 2) Ввести автора курса в инпут фильтра
        * 3) Нажать на кнопку "Искать"
        * 4) Зафиксировать отображенные курсы
        * 5) Перейти в на страницу автора
        * 6) Зафиксировать курсы, которые есть у автора
        * 7) Сравнить курсы на шаге 4 и 6
        * Ожидаемое поведение системы:
        * При фильтрации в каталоге выводятся все курсы автора
        */
        [AllureName("Фильтрация")]
        [DisplayName("Фильтрация по языкам курсов")]
        [Test]
        [TestCase("TechTutors")]
        public void FilterLanguage(string nameCourse)
        {
            string rez = "";
            string[] arrayTitle = {"На любом языке", "На русском", "На английском"};

            CatalogPage catalogPage = new CatalogPage(driver);

            var itemsFilterCourse = catalogPage.SendTextOnFilterOfNameCourse(nameCourse)
                .ClickToSearchButton()
                .SetCheckbox("Любой", true)
                .SetCheckbox("Русский", true)
                .SetCheckbox("Английский", true);

            var titleAppliedFiter = itemsFilterCourse.GetTitleAppliedFilterBar();

            foreach(var item in titleAppliedFiter)
                if(!arrayTitle.Any(s => s == item)) rez += item;

            Assert.IsTrue(rez != "", $"Отсутствует выбранный фильтр среди применненых '{rez}'");
        }
    }
}