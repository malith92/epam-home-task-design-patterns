using NUnit.Framework;
using HomeTaskDesignPatterns.PageObjects;

namespace HomeTaskDesignPatterns.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTestObject
    {
        private LoginPage? _loginPage;
        private EmailAccountHomePage? _emailAccountPage;

        [Test]
        public void LoginTest()
        {
            _loginPage = new LoginPage(_driver);

            _emailAccountPage = _loginPage.Login(configurationFileReader.TestData.EmailCredentials.UserName, configurationFileReader.TestData.EmailCredentials.Password);
            bool loginSuccessful = _emailAccountPage.GMailImageIsDisplayed();

            Assert.IsTrue(loginSuccessful);
        }
    }
}