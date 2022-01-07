using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnitTests.PageObjects;

namespace SeleniumNUnitTests
{
    internal class BaseTest
    {
        protected IWebDriver _driver;

        // OneTimeSetUp = один раз перед всеми тестами
        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
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
            _driver.Quit();
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
