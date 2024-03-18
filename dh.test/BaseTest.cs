using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Allure.Net.Commons;
using dh.core.Config;
using dh.core.UI.Adapter;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace dh.test
{
    [AllureNUnit]
    public class BaseTest
    {
        protected readonly IConfig webConfig = IConfig.getConfig();
        protected WebDriverWrapper driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AllureLifecycle allure = AllureLifecycle.Instance;
            allure.CleanupResultDirectory();
        }


        [SetUp]
        public void SetUp()
        {
            driver = new WebDriverWrapper();
            driver.CreateDriver();
            driver.Wait(30);
            driver.NavigateToDriver(webConfig.GetWebUrl());
        }

        [TearDown]
        public void TearDown()
        {
            driver.DeleteDriver();
        }
    }
}
