using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumNUnitTests
{
    internal static class WaitUntil
    {
        /// <summary>
        /// Ожидание загрузки сайта
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="location"></param>
        /// <exception cref="NotFoundException"></exception>
        internal static void ShouldLocate(IWebDriver driver, string UrlLocation)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(UrlLocation));
            }
            catch (WebDriverTimeoutException ex)
            {

                throw new NotFoundException($"Cant find location {UrlLocation} ", ex);
            }
        }

        /// <summary>
        /// просто ожидание
        /// </summary>
        /// <param name="miliSeconds"></param>
        internal static void WaitTimeInterval(int miliSeconds = 10000)
        {
            Task.Delay(miliSeconds).Wait();
        }

        /// <summary>
        /// Поиск с ожиданием, которое можно задать.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="miliSeconds"> 10 секундл по умолчанию</param>
        internal static void WaitElementVisibleAndClickable(IWebDriver driver, By locator, int miliSeconds = 10000)
        {
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(miliSeconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(miliSeconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
