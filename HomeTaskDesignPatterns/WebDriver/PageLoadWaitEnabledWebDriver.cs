using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HomeTaskDesignPatterns.WebDriver
{
    public class PageLoadWaitEnabledWebDriver : WebDriverDecorator
    {
        private WebDriverWait _webDriverWait;

        public PageLoadWaitEnabledWebDriver(IWebDriver driver) : base(driver)
        {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            WaitUntilPageLoads();
        }
        private void WaitUntilPageLoads()
        {
            _webDriverWait.Until((IWebDriver driver) =>
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;

                string script = "return document.readyState";

                bool scriptOutput = javaScriptExecutor.ExecuteScript(script).Equals("complete");

                return scriptOutput;
            });
        }
    }
}
