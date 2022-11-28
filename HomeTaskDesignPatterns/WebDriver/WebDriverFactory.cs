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
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserType)
        {
            switch (browserType)
            {
                case "CHROME":
                    return new ChromeDriver();
                case "FIREFOX":
                    return new FirefoxDriver();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
