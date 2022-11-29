using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HomeTaskDesignPatterns.Utilities
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserType)
        {
            switch (browserType.ToUpper())
            {
                case "CHROME":
                    return new ChromeDriver();
                case "FIREFOX":
                    return new FirefoxDriver();
                case "EDGE":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Unsupported WebDriver : "+ browserType);
            }
        }
    }
}
