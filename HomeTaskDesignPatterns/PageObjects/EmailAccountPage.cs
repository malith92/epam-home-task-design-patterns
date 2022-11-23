using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using HomeTaskDesignPatterns.PageObjects.EmailAccountPageSections;

namespace HomeTaskDesignPatterns.PageObjects
{
    public class EmailAccountPage : BasePage
    {
        private readonly By _gmailImageLocator = By.XPath("//a[@title='Gmail']/img");
        private readonly By _composeButtonLocator = By.XPath("//div[text()='Compose']");
        private readonly By _draftsLinkLocator = By.LinkText("Drafts");
        private readonly By _sentLinkLocator = By.LinkText("Sent");
        private readonly By _accountAvatarLinkLocator = By.XPath("//a[contains(@aria-label,'Google Account: Test Account')]");

        public EmailAccountPage(IWebDriver driver) : base(driver) { }

        public bool GMailImageIsDisplayed()
        {
            bool gmailLinkDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_gmailImageLocator)).Displayed;

            return gmailLinkDisplayed;
        }

        public EmailComposeSection ClickComposeButton()
        {
            base.Driver.FindElement(_composeButtonLocator).Click();

            return new EmailComposeSection(base.Driver);
        }

        public DraftsSection ClickDraftsLink()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_draftsLinkLocator)).Click();

            return new DraftsSection(base.Driver);
        }

        public SentSection ClickSentLink()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_sentLinkLocator)).Click();

            return new SentSection(base.Driver);
        }

        public AccountSection ClickAccountLink()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_accountAvatarLinkLocator)).Click();

            return new AccountSection(base.Driver);
        }
    }
}
