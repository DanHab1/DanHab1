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
    [AllureSuite("Авторизация")]
    public class AuthTest : BaseTest
    {
        [AllureName("Авторизация")]
        [DisplayName("Авторизация по логину и паролю")]
        [Test]
        /* 
         * Кейс:
         * 1) Открыть страницу
         * 2) Нажать на кнопку "Войти" в хедере страницы
         * 3) Ввести номер телефона
         * 4) Не вводить пароль
         * Ожидаемое поведение системы:
         * Вход не осуществлен в систему
         */
        public void AuthNegativeTest()
        {
            var header = new Header(driver);
            header
                .GetTab("Войти")
                .OpenTab();

            var authPage = new AuthPage(driver);

            authPage
                .SendEmailField("ddada@")
                .SendPasswordField("123")
                .ClickLogIn();
        }
    }
}
