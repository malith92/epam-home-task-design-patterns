using HomeTaskDesignPatterns.Utilities;
using HomeTaskDesignPatterns.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeTaskDesignPatterns.Tests
{
    public class BaseTestObject
    {
        protected ConfigurationFileReader? configurationFileReader;
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            configurationFileReader = ConfigurationFileReader.GetInstance();

            _driver = WebDriverFactory.CreateWebDriver(configurationFileReader.ConfigData.Browser);

            _driver = new PageLoadWaitEnabledWebDriver(_driver);
            _driver = new PageMaximizationEnabledWebDriver(_driver);

            _driver.Navigate().GoToUrl(configurationFileReader.ConfigData.AppUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //_driver.Quit();
        }
    }
}
