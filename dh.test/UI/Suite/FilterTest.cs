using dh.page;
using OpenQA.Selenium;
using System.ComponentModel;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace dh.test.UI.Suite
{
    [AllureSuite("���������� �� ��������")]
    public class Tests : BaseTest
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
            CatalogPage catalogPage = new CatalogPage(driver);
            var itemsFilterCourse = catalogPage.SendTextOnFilterOfNameCourse(nameCourse)
                .GoToItemComplite(1)
                .GetModelsSearchCourseItems();
            foreach (var item in itemsFilterCourse)
            {
                Assert.IsTrue(item.Title.ToLower().Contains(nameCourse.ToLower()) || item.Description.ToLower().Contains(nameCourse.ToLower()),
                    $"��� ���������� ��������� ����, ������� �� �������� ������������ ��� �������� �� ������������� ����:\n������: {nameCourse.ToLower()}\n������������: {item.Title}\n��������: {item.Description}");
            }
        }

        /* 
        * ����:
        * 1) ������� �������� ��������
        * 2) ������ ������ ����� � ����� �������
        * 3) ������ �� ������ "������"
        * 4) ��������� ��������� ������� �� ������� ������� ���������� ������ ����� 
        * ��������� ��������� �������:
        * ��������� ������ � ������ ���������� �� ������ ����� (��� ��������)
        */
        [AllureName("����������")]
        [DisplayName("���������� �� ������ �����")]
        [Test]
        [TestCase("��������������� ����������� �����������")]
        [TestCase("TechTutors Team")]
        public void FilterToAuthorCourse(string nameAuthor)
        {
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
            {
                Assert.IsTrue(itemsFilterCourse.ElementAt(i).ToString() == itemsAuthorCourse.ElementAt(i).ToString(),
                    $"�� ��������� ����� � �������� ������ � ��� ���������� � ��������\n{itemsFilterCourse.ElementAt(i).ToString()}\n{itemsAuthorCourse.ElementAt(i).ToString()}");
            };

            //foreach (var item in itemsFilterCourse)
            //{
            //    //Assert.IsTrue(item.Author.ToLower().Contains(nameAuthor.ToLower()),
            //    //    $"��� ���������� ��������� ����, ������� �� �������� ���������� ������:\n������: {nameAuthor.ToLower()}\n����� �����: {item.Author}\n������������ �����: {item.Title}");
            //}
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
        [DisplayName("���������� �� ������ �����")]
        [Test]
        [TestCase("TechTutors Team")]
        public void FilterCourseAuthor(string nameCourse)
        {

        }
    }
}