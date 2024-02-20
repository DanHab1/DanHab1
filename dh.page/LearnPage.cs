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
        WebDriverAdapter driver;
        public LearnPage(WebDriverAdapter driver) : base(driver)
        {
            this.driver = driver;
        }

    }
}
