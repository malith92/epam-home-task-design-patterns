using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using HomeTaskDesignPatterns.PageObjects;
using HomeTaskDesignPatterns.PageObjects.EmailAccountPageSections;
using HomeTaskDesignPatterns.Utilities;
using HomeTaskDesignPatterns.WebDriver;

namespace HomeTaskDesignPatterns.Tests
{
    [TestFixture]
    public class LoginPageTests
    {
        private IWebDriver _driver;

        private LoginPage? _loginPage;
        private EmailAccountHomePage? _emailAccountPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = WebDriverFactory.CreateWebDriver("CHROME");

            _driver = new PageLoadWaitEnabledWebDriver(_driver);
            _driver = new PageMaximizationEnabledWebDriver(_driver);

            _driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin/signinchooser?service=mail");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //_driver.Quit();
        }

        [Test]
        [TestCase("ta3862989@gmail.com", "!QAZ2wsx!@")]
        public void LoginTest(string userName, string password)
        {
            _loginPage = new LoginPage(_driver);

            _emailAccountPage = _loginPage.Login(userName, password);
            bool loginSuccessful = _emailAccountPage.GMailImageIsDisplayed();

            Assert.IsTrue(loginSuccessful);
        }
    }
}