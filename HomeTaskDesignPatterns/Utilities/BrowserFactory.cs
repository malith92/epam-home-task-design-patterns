using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V105.Target;
using OpenQA.Selenium.Firefox;

namespace HomeTaskDesignPatterns.Utilities
{
    public class BrowserFactory
    {
        private IWebDriver? _driver;

        private static BrowserFactory _instance;
        private BrowserFactory()
        {

        }

        public static BrowserFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BrowserFactory();
            }

            return _instance;
        }


        public IWebDriver CreateBrowser(string browserType)
        {
            switch (browserType)
            {
                case "CHROME":
                    _driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    _driver = new FirefoxDriver();
                    break;
            }

            return _driver;
        }
    }
}
