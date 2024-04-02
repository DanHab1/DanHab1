using dh.core.API;
using OpenQA.Selenium.DevTools.V119.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using dh.test.API.Model;
using NUnit.Allure.Attributes;
using System.ComponentModel;

namespace dh.test.API
{
    [AllureSuite("API")]
    public class FilterAPITest
    {
        [AllureName("Фильтрация")]
        [DisplayName("Фильтрация по наименованию курса")]
        [Test]
        [Order(1)]
        [TestCase("sql")]
        public void GetDataByFilterAPITest(string nameCourse)
        {
            Client client = new Client();
            RestRequest request = new RestRequest("api/search-results", Method.Get);
            request.AddQueryParameter("order", "conversion_rate__none,rating__none,quality__none,paid_weight__none,search_boost__none");
            request.AddQueryParameter("page", "1");
            request.AddQueryParameter("query", nameCourse);
            request.AddQueryParameter("type", "course");
            RestResponse response = new RestResponse();
            response = client.client.Get(request);
            var rez = JsonConvert.DeserializeObject<SearchResultsResp>(response?.Content);
            Assert.IsNotNull(rez?.searchresults, $"Отсутствуют результаты фильтрации {nameCourse}");

            foreach(var item in rez.searchresults)
                Assert.IsTrue(item.course_title.ToLower().Contains(nameCourse.ToLower()));

        }
    }
}
