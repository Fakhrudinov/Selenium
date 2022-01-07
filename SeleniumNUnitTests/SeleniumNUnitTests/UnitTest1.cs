using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnitTests.PageObjects;

namespace SeleniumNUnitTests
{
    public class Tests
    {
        private IWebDriver _driver;

        // F12 ����� �������
        // Ctrl + Shift + C � ������ ������ �� ������
        // ���
        // Ctrl+F, � ������ ������ ���� Xpath //span[text()='�����']
        // ����� // ����� ������� ','

        private const string _assertionExpectedUserAgreement = "BP19195";

        [SetUp]
        public void Setup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _driver.Navigate().GoToUrl("https://matrix.ittrade.ru/qcabinet/cl.phtml");
            _driver.Manage().Window.Maximize();
            WaitUntil.ShouldLocate(_driver, "https://matrix.ittrade.ru/qcabinet/cl.phtml");
        }

        [Test]
        public void Test1()
        {
            var loginPage = new LoginPageObject(_driver);

            var assertionActualUserAgreement = loginPage
                .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword) // ������ �� �������� �����
                .GetUserAgreement();//����� ����� ������ � �������������� ���������, �.�. ��� ������� ��� ���������

            //// ���� ����� �� 2 ��������
            //AutorizedPageObject assertionActualUserAgreement2 = loginPage
            //    .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword); // ������ �� �������� �����
            //string str = assertionActualUserAgreement2.GetUserAgreement();

            Assert.AreEqual(_assertionExpectedUserAgreement, assertionActualUserAgreement, 
                "Assertion fail: User Agreement not equal for expected data or logon is incomplete.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}