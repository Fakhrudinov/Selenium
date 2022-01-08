using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnitTests.PageObjects;

namespace SeleniumNUnitTests
{
    [TestFixture]
    internal class Tests : BaseTest
    {
         // F12 ����� �������
        // Ctrl + Shift + C � ������ ������ �� ������
        // ���
        // Ctrl+F, � ������ ������ ���� Xpath //span[text()='�����']

        private const string _assertionExpectedUserAgreement = "BP19195";

        [Test]
        public void Test1()
        {
            var loginPage = new LoginPageObject(_driver);

            //var assertionActualUserAgreement = loginPage
            //    .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword) // ������ �� �������� �����
            //    .GetUserAgreement();//����� ����� ������ � �������������� ���������, �.�. ��� ������� ��� ���������

            // ���� ����� �� 2 ��������
            AutorizedPageObject firstPage = loginPage
                .LogOn(UserNameForTests.StartLogin, UserNameForTests.StartPassword); // ������ �� �������� �����
            string assertionActualUserAgreement2 = firstPage.GetUserAgreement();

            // ��������� �� �������� �������� ���������
            //var moneyTransfer = firstPage.NavigateToMoneyTransferPageObject();

            // ��������� ���������� ������ � ������� �� �������� � �������
            //moneyTransfer.ClickToAccountsSelectByText(AccountsTexts.CD);

            //�������� ����������� ������ �� ��������
            /*
            Assert.AreEqual(_assertionExpectedUserAgreement, assertionActualUserAgreement2, 
                "Assertion fail: User Agreement not equal for expected data or logon is incomplete.");
            */

            // �������� ������� �������� - 4 �������
            //Assert.IsTrue(firstPage.IsUserAgreementPresent_Example1());// 1 ���������� - ��������� � ����������� �������
            //Assert.IsTrue(firstPage.IsUserAgreementPresent_Example2());// 2 ok

            //Assert.Throws<NoSuchElementException>(() => firstPage.ClickToSomeThing3());// 3 ��� �������� ����������
            //Assert.DoesNotThrow(() => firstPage.ClickToSomeThing3());// 3 ��� �������� �������

            Assert.That(firstPage.GetAllUserAccounts4, Has.Member(AccountsTexts.FX));// 4 ��� �������� �������
            Assert.That(firstPage.GetAllUserAccounts4, Has.No.Member("blabla"));// 4 ��� �������� ����������


        }
    }
}