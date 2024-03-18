using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dh.core.UI.Adapter;
using OpenQA.Selenium;

namespace dh.page
{
    public class LearnPage : BasePage
    {
        WebDriverWrapper driver;
        public LearnPage(WebDriverWrapper driver) : base(driver)
        {
            this.driver = driver;
        }

    }
}
