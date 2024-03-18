using dh.core.UI.Adapter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dh.page
{
    public class AuthPage : BasePage
    {
        WebDriverWrapper driver;

        public AuthPage(WebDriverWrapper driver) : base(driver) 
        {
            this.driver = driver;
        }

        public AuthPage SendEmailField(string username)
        {
            GetInput("E-mail").SendKeys(username);
            return this;
        }

        public AuthPage SendPasswordField(string password)
        {
            GetInput("Пароль").SendKeys(password);
            return this;
        }

        public void ClickLogIn() => GetButton("Войти").Click();
    }
}
