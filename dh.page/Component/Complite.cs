using dh.core.UI.Adapter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Component
{
    public class Complite : BaseComponent<Complite>
    {
        IWebElement Element { get; set; }
        WebDriverAdapter driver { get; set; }
        Dictionary<string, IWebElement> compliteItems;

        private string _complites = "//ul[contains(@class,'menu') and contains(@class,'drop-down-content')]";
        public Complite(IWebElement element) : base(element)
        {
            this.element = element;
            compliteItems = new Dictionary<string, IWebElement>();
        }

        public Dictionary<string, IWebElement> GetItemComplite()
        {
            var items = element.FindElements(By.XPath(".//li"));
            foreach (var item in items) 
            {
                compliteItems.Add(item.GetAttribute("innerText"), item);
            }
            return compliteItems;
        }
    }
}
