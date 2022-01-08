using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnitTests.PageObjects;

namespace SeleniumNUnitTests
{
    [TestFixture]
    internal class Tests : BaseTest
    {
         // F12 найти элемент
        // Ctrl + Shift + C и нажать мышкой на нужный
        // или
        // Ctrl+F, в строке поиска ищем Xpath //span[text()='Войти']

        private const string _assertionExpectedUserAgreement = "BP19195";

        [Test]
        public void Test1()
        {
            var loginPage = new LoginPageObject(_driver);

            //var assertionActualUserAgreement = loginPage
            //    .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword) // вводим на странице входа
            //    .GetUserAgreement();//затем берем данные в авторизованной страничке, т.к. нам вернули эту страничку

            // тоже самое на 2 действия
            AutorizedPageObject firstPage = loginPage
                .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword); // вводим на странице входа
            string assertionActualUserAgreement2 = firstPage.GetUserAgreement();

            // переходим на страницу денежных переводов
            //var moneyTransfer = firstPage.NavigateToMoneyTransferPageObject();

            // открываем выпадающий список и кликаем по элементу с текстом
            //moneyTransfer.ClickToAccountsSelectByText(AccountsTexts.CD);

            //проверка содержимого какого то элемента
            /*
            Assert.AreEqual(_assertionExpectedUserAgreement, assertionActualUserAgreement2, 
                "Assertion fail: User Agreement not equal for expected data or logon is incomplete.");
            */

            // проверка наличия элемента - 4 способа
            //Assert.IsTrue(firstPage.IsUserAgreementPresent_Example1());// 1 недостатки - медленная в большинстве случаев
            //Assert.IsTrue(firstPage.IsUserAgreementPresent_Example2());// 2 ok

            //Assert.Throws<NoSuchElementException>(() => firstPage.ClickToSomeThing3());// 3 для проверки отсутствия
            //Assert.DoesNotThrow(() => firstPage.ClickToSomeThing3());// 3 для проверки наличия

            Assert.That(firstPage.GetAllUserAccounts4, Has.Member(AccountsTexts.FX));// 4 для проверки наличия
            Assert.That(firstPage.GetAllUserAccounts4, Has.No.Member("blabla"));// 4 для проверки отсутствия


        }
    }
}