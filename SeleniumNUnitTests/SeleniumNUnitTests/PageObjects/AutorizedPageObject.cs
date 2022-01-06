using OpenQA.Selenium;

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
            return _driver.FindElement(_assertionUserAgreement).Text.Split('-')[0];
        }
    }
}
