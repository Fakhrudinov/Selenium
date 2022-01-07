using OpenQA.Selenium;

namespace SeleniumNUnitTests.PageObjects
{
    internal class LoginPageObject
    {
        private IWebDriver _driver;

        private readonly By _loginInputButton = By.XPath("//input[@id='login']");
        private readonly By _passwordInputButton = By.XPath("//input[@id='password']");
        private readonly By _logonButton = By.XPath("//input[@class='form-control btn btn_green btn-primary']");


        internal LoginPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        internal AutorizedPageObject LogOn(string login, string password)
        {
            _driver.FindElement(_loginInputButton).SendKeys(login);
            _driver.FindElement(_passwordInputButton).SendKeys(password);

            _driver.FindElement(_logonButton).Click();

            //Thread.Sleep(1000);

            return new AutorizedPageObject(_driver);
        }
    }
}
