using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HomeTaskDesignPatterns.WebDriver
{
    public abstract class WebDriverDecorator : IWebDriver
    {
        private IWebDriver _driver;

        public WebDriverDecorator(IWebDriver driver)
        {
            this._driver = driver;
        }
        public IWebDriver Driver { get => _driver; set => _driver = value; }

        public string Url { get => _driver.Url; set => _driver.Url = value; }

        public string Title => _driver.Title;

        public string PageSource => _driver.PageSource;

        public string CurrentWindowHandle => _driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void Close()
        {
            _driver.Close();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }
    }
}
