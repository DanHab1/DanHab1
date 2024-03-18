using dh.core.UI.Adapter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Component
{
    public class Checkbox : BaseComponent<Checkbox>
    {
        private WebDriverWrapper _driver;
        private List<IWebElement> _listElement;
        private Checkbox _checkbox;
        public IWebElement element;

        private string _pathCheckbox = "(//*[@type='checkbox']//..)//child::span";

        public string name { get; set; }
        public bool value { get; set; }

        public Checkbox(WebDriverWrapper driver, string nameCheckbox) : base()
        {
            _driver = driver;
            name = nameCheckbox;
            _checkbox = GetCheckbox(nameCheckbox);
            value = GetValueCheckbox();
        }

        private Checkbox GetCheckbox(string nameCheckbox)
        {
            _listElement = _driver.FindElements(_pathCheckbox);
            element = _listElement.Where(x => x.GetAttribute("innerText") == nameCheckbox).First();
            return this;
        }

        public bool GetValueCheckbox() =>
             element.FindElement(By.XPath(".//..//input")).GetAttribute("checked") == "true" ? true : false;


        public void SetCheckbox(bool value)
        {
            if (_checkbox.GetValueCheckbox() != value) element.Click();
        }


    }
}
