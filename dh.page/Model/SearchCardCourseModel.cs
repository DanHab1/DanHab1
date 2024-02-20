using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.page.Model
{
    public class SearchCardCourseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Price { get; set; } = "";
        public bool IsWithSertificate { get; set; } = false;
        public IWebElement ElementModel { get; set; }

        public override string ToString()
        {
            return $"{Title}\n{Author}\n{Description}\n{Price}\n{IsWithSertificate}";
        }
    }
}
