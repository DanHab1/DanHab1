using dh.page;
using OpenQA.Selenium;
using System.ComponentModel;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace dh.test.UI.Suite
{
    [AllureSuite("Фильтрация по каталогу")]
    public class Tests : BaseTest
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
            CatalogPage catalogPage = new CatalogPage(driver);
            var itemsFilterCourse = catalogPage.SendTextOnFilterOfNameCourse(nameCourse)
                .GoToItemComplite(1)
                .GetModelsSearchCourseItems();
            foreach (var item in itemsFilterCourse)
            {
                Assert.IsTrue(item.Title.ToLower().Contains(nameCourse.ToLower()) || item.Description.ToLower().Contains(nameCourse.ToLower()),
                    $"При фильтрации обнаружен курс, который не содержит наименования или описания по фильтрованной теме:\nФильтр: {nameCourse.ToLower()}\nНаименование: {item.Title}\nОписание: {item.Description}");
            }
        }

        /* 
        * Кейс:
        * 1) Открыть страницу каталога
        * 2) Ввести автора курса в инпут фильтра
        * 3) Нажать на кнопку "Искать"
        * 4) Проверить результат фильтра на предмет наличия введенного автора курса 
        * Ожидаемое поведение системы:
        * Выводятся записи с учетом фильтрации по автору курса (или описания)
        */
        [AllureName("Фильтрация")]
        [DisplayName("Фильтрация по автору курса")]
        [Test]
        [TestCase("Дальневосточный федеральный университет")]
        [TestCase("TechTutors Team")]
        public void FilterToAuthorCourse(string nameAuthor)
        {
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
            {
                Assert.IsTrue(itemsFilterCourse.ElementAt(i).ToString() == itemsAuthorCourse.ElementAt(i).ToString(),
                    $"Не совпадают курсы в карточке автора и при фильтрации в каталоге\n{itemsFilterCourse.ElementAt(i).ToString()}\n{itemsAuthorCourse.ElementAt(i).ToString()}");
            };

            //foreach (var item in itemsFilterCourse)
            //{
            //    //Assert.IsTrue(item.Author.ToLower().Contains(nameAuthor.ToLower()),
            //    //    $"При фильтрации обнаружен курс, который не содержит введенного автора:\nФильтр: {nameAuthor.ToLower()}\nАвтор курса: {item.Author}\nНаименование курса: {item.Title}");
            //}
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
        [DisplayName("Фильтрация по автору курса")]
        [Test]
        [TestCase("TechTutors Team")]
        public void FilterCourseAuthor(string nameCourse)
        {

        }
    }
}