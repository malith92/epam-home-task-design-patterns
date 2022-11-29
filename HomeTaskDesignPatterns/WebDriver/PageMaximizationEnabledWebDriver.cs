using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HomeTaskDesignPatterns.WebDriver
{
    public class PageMaximizationEnabledWebDriver : WebDriverDecorator
    {

        public PageMaximizationEnabledWebDriver(IWebDriver driver) : base(driver)
        {
            base.Driver.Manage().Window.Maximize();
        }
    }
}
