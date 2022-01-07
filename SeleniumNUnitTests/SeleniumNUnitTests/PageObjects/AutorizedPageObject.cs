using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading.Tasks;

namespace SeleniumNUnitTests.PageObjects
{
    internal class AutorizedPageObject
    {
        private IWebDriver _driver;

        private readonly By _assertionUserAgreement = By.XPath("//label[@class='dd-selected-text']");

        internal AutorizedPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUserAgreement()
        {
            // ожидания - вместо Thread.Sleep(1000);

            // используемые библиотеки:
            //   OpenQA.Selenium.Support.UI;
            //   DotNetSeleniumExtras.WaitHelpers
            // WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            // wait.Until(ExpectedConditions.ElementExists(_assertionUserAgreement));

            // еще один аналог Thread.Sleep(1000);
            //  Task.Delay(1000).Wait();
            //  Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            // ожидание через класс
            WaitUntil.WaitElementVisibleAndClickable(_driver, _assertionUserAgreement);

            return _driver.FindElement(_assertionUserAgreement).Text.Split('-')[0];
        }

        internal MoneyTransferPageObject NavigateToMoneyTransferPageObject()
        {
            _driver.Navigate().GoToUrl("https://matrix.ittrade.ru/qcabinet/cl.phtml?select=18&part=19");

            return new MoneyTransferPageObject(_driver);
        }
    }
}
