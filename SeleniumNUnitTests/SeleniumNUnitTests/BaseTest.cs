using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitTests
{
    internal class BaseTest
    {
        protected IWebDriver _driver;

        // OneTimeSetUp = один раз перед всеми тестами
        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeOptions);

            //_driver = new OpenQA.Selenium.Chrome.ChromeDriver(); // так запускать без опций
        }

        // один раз после всех тестов
        [OneTimeTearDown]
        protected void DoAfterAllTests()
        {

        }

        // каждый раз после каждого теста
        [TearDown]
        protected void DoAfterEachTest()
        {
            //_driver.Quit();
        }

        // каждый раз перед каждым тестом
        [SetUp]
        protected void DoBeforeEachTest()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(TestSettings.HostPrefix);
            _driver.Manage().Window.Maximize();
            WaitUntil.ShouldLocate(_driver, TestSettings.LocationLK);
        }
    }
}
