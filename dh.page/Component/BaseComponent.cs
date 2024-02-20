using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Component
{
    public abstract class BaseComponent<T> where T : class
    {
        protected IWebElement element;

        public BaseComponent(IWebElement element)
        {
            this.element = element;
        }

        public IWebElement GetElement() => element;
    }
}
