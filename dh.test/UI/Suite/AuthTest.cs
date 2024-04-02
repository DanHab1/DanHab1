using dh.page;
using dh.page.Component;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.test.UI.Suite
{
    [AllureSuite("UI")]
    public class AuthTest : BaseTest
    {
        [AllureName("Авторизация")]
        [DisplayName("Авторизация по емейл и паролю")]
        [Test]
        /* 
         * Кейс:
         * 1) Открыть страницу
         * 2) Нажать на кнопку "Войти" в хедере страницы
         * 3) Ввести емейл не валидный
         * 4) Не вводить пароль
         * Ожидаемое поведение системы:
         * Вход не осуществлен в систему
         */
        [TestCase("dad", "1")]
        [TestCase("dad@", "1")]
        [TestCase("dad@mail,ru", "1")]
        [TestCase("", "")]
        [TestCase("", "1")]
        
        public void AuthNegativeTest(string email, string password)
        {
            var header = new Header(driver);
            header
                .GetTab("Войти")
                .OpenTab();

            var authPage = new AuthPage(driver);

            authPage
                .SendEmailField(email)
                .SendPasswordField(password)
                .ClickLogIn();

            Thread.Sleep(1000); //временно, сделать явное ожидание
            var headerUpt = new Header(driver);
            Assert.IsFalse(headerUpt.GetTitleOfTabs().Any(x => x == "Моё обучение"));
        }

        [AllureName("Авторизация")]
        [DisplayName("Авторизация по емейл и паролю")]
        [Test]
        [TestCase("test1test2_test1test2@mail.ru", "c#isgood")]
        public void AuthPositiveTest(string email, string password)
        {
            var header = new Header(driver);
            header
                .GetTab("Войти")
                .OpenTab();

            var authPage = new AuthPage(driver);

            authPage
                .SendEmailField(email)
                .SendPasswordField(password)
                .ClickLogIn();

            Thread.Sleep(1000); //временно, сделать явное ожидание
            var headerUpt = new Header(driver);
            Assert.IsTrue(headerUpt.GetTitleOfTabs().Any(x => x == "Моё обучение"));
        }
    }
}
