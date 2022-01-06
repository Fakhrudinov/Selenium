using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumNUnitTests
{
    public class Tests
    {
        private IWebDriver driver;

        // F12 найти элемент
        // Ctrl + Shift + C и нажать мышкой на нужный
        // или
        // Ctrl+F, в строке поиска ищем Xpath //span[text()='¬ойти']
        // перед // можно ставить ','

        private readonly By _loginInputButton = By.XPath("//input[@id='login']");        
        private readonly By _passwordInputButton = By.XPath("//input[@id='password']");
        private readonly By _logonButton = By.XPath("//input[@class='form-control btn btn_green btn-primary']");
        private readonly By _assertionUserAgreement = By.XPath("//label[@class='dd-selected-text']");

        private const string _login = "asbuka";
        private const string _password = "1qaZXsw2";
        private const string _assertionExpectedUserAgreement = "BP19195";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://matrix.ittrade.ru/qcabinet/cl.phtml");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var login = driver.FindElement(_loginInputButton);
            login.SendKeys(_login);
            var password = driver.FindElement(_passwordInputButton);
            password.SendKeys(_password);

            var logon = driver.FindElement(_logonButton);
            logon.Click();

            Thread.Sleep(1000);

            var assertionActualUserAgreement = driver.FindElement(_assertionUserAgreement).Text.Split('-')[0];

            Assert.AreEqual(_assertionExpectedUserAgreement, assertionActualUserAgreement, 
                "Assertion fail: User Agreement not equal for expected data or logon is incomplete.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}