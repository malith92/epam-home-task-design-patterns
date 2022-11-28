using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using HomeTaskDesignPatterns.PageObjects;
using HomeTaskDesignPatterns.PageObjects.EmailAccountPageSections;
using HomeTaskDesignPatterns.Utilities;

namespace HomeTaskDesignPatterns.Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;

        private LoginPage? _loginPage;
        private EmailAccountPage? _emailAccountPage;
        private EmailComposeSection? _composeSection;
        private DraftsSection? _draftsSection;
        private SentSection? _sentSection;
        private AccountSection? _accountSection;
        private AccountChooserPage? _accountChooserPage;

        private string? _subject;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = WebDriverFactory.CreateWebDriver("CHROME");

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin/signinchooser?service=mail");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //_driver.Quit();
        }

        [Test, Order(1)]
        [TestCase("ta3862989@gmail.com", "!QAZ2wsx!@")]
        public void LoginTest(string userName, string password)
        {
            _loginPage = new LoginPage(_driver);

            _emailAccountPage = _loginPage.Login(userName, password);
            bool loginSuccessful = _emailAccountPage.GMailImageIsDisplayed();

            Assert.IsTrue(loginSuccessful);
        }

        [Test, Order(2)]
        [TestCase("malithwanniarachchi@gmail.com", "Test Email | ", "Test Email Content")]
        public void VerifyDraftedEmailPresentInDrafts(string recipientEmail, string subject, string content)
        {
            _composeSection = _emailAccountPage.ClickComposeButton();
            _subject = subject + DateTime.Now.ToString("F");
            _composeSection.CreateDraftEmail(recipientEmail, _subject, content);

            _draftsSection = _emailAccountPage.ClickDraftsLink();
            bool draftedEmailIsAvailable = _draftsSection.DraftedEmailIsDisplayed(_subject);

            Assert.IsTrue(draftedEmailIsAvailable);
        }

        [Test, Order(3)]
        [TestCase("malithwanniarachchi@gmail.com")]
        public void VerifyDraftEmailReceiver(string receiverEmailAddress)
        {
            _composeSection = _draftsSection.ClickDraftedEmail();

            string actualReceiverAddress = _composeSection.GetReceiverAddressFromDraftedEmail();

            Assert.AreEqual(receiverEmailAddress, actualReceiverAddress);
        }

        [Test, Order(4)]
        public void VerifyDraftEmailSubject()
        {
            string draftedEmailSubject = _composeSection.GetSubjectFromDraftedEmail();

            Assert.AreEqual(this._subject, draftedEmailSubject);
        }

        [Test, Order(5)]
        [TestCase("Test Email Content")]
        public void VerifyDraftEmailBody(string expectedContent)
        {
            string draftedEmailBody = _composeSection.GetContentFromDraftedEmail();

            Assert.AreEqual(expectedContent, draftedEmailBody);
        }

        [Test, Order(6)]
        public void VerifyDraftEmailDissapearedFromDrafts()
        {
            _composeSection.ClickSendButton();

            bool draftedEmailIsDisplayed = _draftsSection.DraftedEmailIsDisplayed(_subject);

            Assert.IsFalse(draftedEmailIsDisplayed);
        }

        [Test, Order(7)]
        public void VerifyMailIsinSentFolder()
        {
            _sentSection = _emailAccountPage.ClickSentLink();

            bool sentEmailIsDisplayed = _sentSection.SentEmailIsDisplayed(_subject);

            Assert.IsTrue(sentEmailIsDisplayed);
        }

        [Test, Order(8)]
        public void LogOffTest()
        {
            _accountSection = _emailAccountPage.ClickAccountLink();

            _accountChooserPage = _accountSection.SignOut();

            bool logOffSuccessful = _accountChooserPage.ChooseAccountTextIsDisplayed();

            Assert.IsTrue(logOffSuccessful);
        }
    }
}