using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using eCommerce.POMs;

[assembly: Parallelizable(ParallelScope.Fixtures)] //Can only parallelise Features
[assembly: LevelOfParallelism(20)] //Worker thread i.e. max amount of Features to run in Parallel


namespace eCommerce.StepDefinitions
{
    [Binding]

    public class Hooks
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Before]
        public void SetUp()
        {
            driver = new ChromeDriver();
            _scenarioContext["mydriver"] = driver;
        }

        [After]
        public void TearDown()
        {
            Thread.Sleep(2000);
            HomePagePOM homePage = new HomePagePOM(driver);
            CartPagePOM cartPagePOM = new CartPagePOM(driver);
            MyAccountPagePOM myAccountPagePOM = new MyAccountPagePOM(driver);
            homePage.goCartPage();
            cartPagePOM.RemoveCartItems();
            homePage.goLoginPage();
            myAccountPagePOM.Logout();
            driver.Quit();
        }
    }
}
