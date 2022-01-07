using NUnit.Framework;
using SeleniumNUnitTests.PageObjects;

namespace SeleniumNUnitTests
{
    internal class Tests : BaseTest
    {
         // F12 найти элемент
        // Ctrl + Shift + C и нажать мышкой на нужный
        // или
        // Ctrl+F, в строке поиска ищем Xpath //span[text()='Войти']
        // перед // можно ставить ','

        private const string _assertionExpectedUserAgreement = "BP19195";

        [Test]
        public void Test1()
        {
            var loginPage = new LoginPageObject(_driver);

            var assertionActualUserAgreement = loginPage
                .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword) // вводим на странице входа
                .GetUserAgreement();//затем берем данные в авторизованной страничке, т.к. нам вернули эту страничку

            //// тоже самое на 2 действия
            //AutorizedPageObject assertionActualUserAgreement2 = loginPage
            //    .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword); // вводим на странице входа
            //string str = assertionActualUserAgreement2.GetUserAgreement();

            Assert.AreEqual(_assertionExpectedUserAgreement, assertionActualUserAgreement, 
                "Assertion fail: User Agreement not equal for expected data or logon is incomplete.");
        }
    }
}