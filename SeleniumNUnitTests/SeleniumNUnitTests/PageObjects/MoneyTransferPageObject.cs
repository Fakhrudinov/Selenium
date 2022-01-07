using OpenQA.Selenium;
using System.Linq;

namespace SeleniumNUnitTests.PageObjects
{
    internal class MoneyTransferPageObject
    {
        private IWebDriver _driver;

        private readonly By _transferToSelectButton = By.XPath("//select[@name='dest_acc']");
        private readonly By _menuItems = By.XPath("//select[@name='dest_acc']/option");

        internal MoneyTransferPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        internal MoneyTransferPageObject ClickToAccountsSelectByText(string menuText)
        {
            WaitUntil.WaitElementVisibleAndClickable(_driver, _transferToSelectButton);
            _driver.FindElement(_transferToSelectButton).Click();

            WaitUntil.WaitTimeInterval(100);
            var selectAccount = _driver
                .FindElements(_menuItems)// взять все элементы
                .First(item => item.Text == menuText);// взять первый соответствующий тексту

            selectAccount.Click();

            return this;
        }
    }
}
