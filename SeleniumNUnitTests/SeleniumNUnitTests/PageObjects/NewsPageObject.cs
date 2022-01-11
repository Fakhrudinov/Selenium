using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SeleniumNUnitTests.PageObjects
{
    internal class NewsPageObject
    {
        private IWebDriver _driver;

        private readonly By _newsDateTimeItems = By.XPath("//table[@class='info']//tr/td[1]/font");

        internal NewsPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        internal IEnumerable<DateTime> GetDateTimeList()
        {
            return _driver.FindElements(_newsDateTimeItems)
                .Select(item => DateTime.Parse(item.Text))
                .ToList();
        }
    }
}
