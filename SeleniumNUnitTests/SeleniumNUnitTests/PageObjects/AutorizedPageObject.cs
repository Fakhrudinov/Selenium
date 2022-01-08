using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumNUnitTests.PageObjects
{
    internal class AutorizedPageObject
    {
        private IWebDriver _driver;

        private readonly By _assertionUserAgreement = By.XPath("//label[@class='dd-selected-text']");
        
        private readonly By _selectAccountItems = By.XPath("//ul[@class='dd-options dd-click-off-close']/li//label");

        internal AutorizedPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        internal string GetUserAgreement()
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

        /// <summary>
        /// способ 1 проверка наличия элемента - не совсем корректная, занимает много времени, если элемента нет
        /// </summary>
        /// <returns></returns>
        internal bool IsUserAgreementPresent_Example1()
        {
            try
            {
                _driver.FindElement(_assertionUserAgreement);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// способ 2 проверка наличия любого указанного значения класса/id/текста в PageSource страницы в любом элементе.
        /// Без таймера - очень быстрый.
        /// </summary>
        /// <returns></returns>
        internal bool IsUserAgreementPresent_Example2()
        {
            try
            {
                // какое то свойство, присущее только авторизованной страничке
                _driver.PageSource.Contains("account");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        // запись второго способа лямбдой
        internal bool IsUserAgreementPresent_Example22 =>
            _driver.PageSource.Contains("account");

        /// <summary>
        /// способ 3 проверка наличия элемента - на выдаваемое исключение. странный и редко используется
        /// </summary>
        /// <returns></returns> 
        internal AutorizedPageObject ClickToSomeThing3()
        {
            _driver.FindElement(_assertionUserAgreement).Click();

            return this;
        }

        /// <summary>
        /// Проверка наличия элемента из списка. странный и редко используется
        /// </summary>
        /// <returns></returns>
        internal List<string> GetAllUserAccounts4()
        {
            // предварительные действия - могут быть не нужны в ином случае
            _driver.FindElement(_assertionUserAgreement).Click();
            WaitUntil.WaitTimeInterval(100);

            // получаем список текстов из элементов
            var list = _driver.FindElements(_selectAccountItems)
                .Select(item => item.Text)
                .ToList();

            return list;
        }
        /* // запись 4го через лямбду
           // сработает, но только если не нужен дополнительный клик и ожидание - иначе все элементы невидимы
        internal List<string> GetAllUserAccounts42 =>
            _driver.FindElements(_selectAccountItems)
            .Select(item => item.Text)
            .ToList();
        */


        internal MoneyTransferPageObject NavigateToMoneyTransferPageObject()
        {
            _driver.Navigate().GoToUrl("https://matrix.ittrade.ru/qcabinet/cl.phtml?select=18&part=19");

            return new MoneyTransferPageObject(_driver);
        }
    }
}
