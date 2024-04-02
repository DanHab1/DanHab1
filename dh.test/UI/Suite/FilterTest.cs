using dh.page;
using OpenQA.Selenium;
using System.ComponentModel;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace dh.test.UI.Suite
{
    [AllureSuite("UI")]
    public class FilterTest : BaseTest
    {
        [AllureName("����������")]
        [DisplayName("���������� �� ������������ �����")]
        [Test]
        [TestCase("python")]
        [TestCase("sql")]
        /* 
         * ����:
         * 1) ������� �������� ��������
         * 2) ������ ������������ ����� � ����� �������
         * 3) ������� ������ �� ��������
         * 4) ��������� ��������� ������� �� ������� ������� ���������� ������������ �����
         * ��������� ��������� �������:
         * ��������� ������ � ������ ���������� �� ������������ ����� (��� ��������)
         */
        public void FilterToNameCourse(string nameCourse)
        {
            string rez = "";

            CatalogPage catalogPage = new CatalogPage(driver);
            var itemsFilterCourse = catalogPage
                .SendTextOnFilterOfNameCourse(nameCourse)
                .GoToItemComplite(1)
                .GetModelsSearchCourseItems();
            
            foreach (var item in itemsFilterCourse)
                if (!item.Title.ToLower().Contains(nameCourse.ToLower()))
                    rez += item.Title; 

            Assert.IsTrue(rez != "",
                $"��� ���������� ��������� �����, ������� �� �������� ������������ �� ������������� ����:\n������: {nameCourse.ToLower()}\n���������: {rez}");
        }

        /* 
        * ����:
        * 1) ������� �������� ��������
        * 2) ������ ������ ����� � ����� �������
        * 3) ������� 1 ������ �� ��������
        * 4) ������� �������� ������
        * 5) �������� �����, �������� ��� ���������� �� ������ � ����� �� �������� ������
        * ��������� ��������� �������:
        * ��������� ��� �����, ������� ���� � ������
        */
        [AllureName("����������")]
        [DisplayName("���������� �� ������ �����")]
        [Test]
        [TestCase("��������������� ����������� �����������")]
        [TestCase("TechTutors")]
        public void FilterToAuthorCourse(string nameAuthor)
        {
            string rez = "";

            CatalogPage catalogPage = new CatalogPage(driver);
            var searchCataologPage = catalogPage.SendTextOnFilterOfNameCourse(nameAuthor)
                .ClickToSearchButton();

            var itemsFilterCourse = searchCataologPage
                .GetModelsSearchCourseItems()
                .OrderBy(x => x.Title);

            var itemsAuthorCourse = searchCataologPage
                .GoToAuthorInfo(0)
                .GetCourseOfAuthorModels()
                .OrderBy(x => x.Title);

            Assert.IsTrue(itemsFilterCourse.Count() == itemsAuthorCourse.Count(),
                $"�� ��������� ���-�� ������ � ������ � ��� ���������� � ��������\n��� ���������� ���-�� �������: {itemsFilterCourse.Count()}\n� ������ ���-�� ������: {itemsAuthorCourse.Count()}");

            for (int i = 0; i < itemsFilterCourse.Count(); i++)
                if (itemsFilterCourse.ElementAt(i).ToString() == itemsAuthorCourse.ElementAt(i).ToString())
                    rez += itemsFilterCourse.ElementAt(i).ToString() + itemsAuthorCourse.ElementAt(i).ToString();

            Assert.IsTrue(rez != "", $"�� ��������� ����� � �������� ������ � ��� ���������� � ��������:\n{rez}");
        }

        /* 
        * ����:
        * 1) ������� �������� ��������
        * 2) ������ ������ ����� � ����� �������
        * 3) ������ �� ������ "������"
        * 4) ������������� ������������ �����
        * 5) ������� � �� �������� ������
        * 6) ������������� �����, ������� ���� � ������
        * 7) �������� ����� �� ���� 4 � 6
        * ��������� ��������� �������:
        * ��� ���������� � �������� ��������� ��� ����� ������
        */
        [AllureName("����������")]
        [DisplayName("���������� �� ������ ������")]
        [Test]
        [TestCase("TechTutors")]
        public void FilterLanguage(string nameCourse)
        {
            string rez = "";
            string[] arrayTitle = {"�� ����� �����", "�� �������", "�� ����������"};

            CatalogPage catalogPage = new CatalogPage(driver);

            var itemsFilterCourse = catalogPage.SendTextOnFilterOfNameCourse(nameCourse)
                .ClickToSearchButton()
                .SetCheckbox("�����", true)
                .SetCheckbox("�������", true)
                .SetCheckbox("����������", true);

            var titleAppliedFiter = itemsFilterCourse.GetTitleAppliedFilterBar();

            foreach(var item in titleAppliedFiter)
                if(!arrayTitle.Any(s => s == item)) rez += item;

            Assert.IsTrue(rez != "", $"����������� ��������� ������ ����� ����������� '{rez}'");
        }
    }
}