using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;
using static eCommerce.StepDefinitions.Hooks;
namespace eCommerce.StepDefinitions
{
    [Binding]

    public class LoginToCommerce
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public LoginToCommerce(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)scenarioContext["mydriver"];

        }

        [Given(@"I am on the website homepage")]
        [Given(@"I am on the website homepage and click the My Account button")]
        public void GivenIAmOnTheWebsiteHomepage()
        {
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            HomePagePOM home = new HomePagePOM(_driver);
            home.goLoginPage();

        }
        [Then(@"I login as a valid user account")]
        [Then(@"I can proceed to login page and login using valid details")]
        public void WhenIClickOn()
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            try
            {
                /*login.setUsername("afraaz.tiwana@nfocus.co.uk");
                login.setPassword("nfocusTesting123");*/
                login.setUsername(Environment.GetEnvironmentVariable("username"));
                login.setPassword(Environment.GetEnvironmentVariable("password"));
            }

            catch (NullReferenceException)
            {
                Console.WriteLine("Username and password have not been provided");
            }
            login.goSubmit();
        }
        [Given(@"I am currently on the shop page")]
        [When(@"I have arrived on the My account page I can access the shop page")]
        public void ThenICanLoginUsingValidDetails()
        {
            MyAccountPagePOM accountPom = new MyAccountPagePOM(_driver);
            accountPom.GoShop();
        }
    }
}
