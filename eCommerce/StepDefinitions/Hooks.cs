using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.POMs;
using TechTalk.SpecFlow;

//[assembly: Parallelizable(ParallelScope.Fixtures)] //Can only parallelise Features
//[assembly: LevelOfParallelism(20)] //Worker thread i.e. max amount of Features to run in Parallel


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
            string browser = Environment.GetEnvironmentVariable("BROWSER");

            // Uses enviroment variables to determine what browser to use
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    _scenarioContext["mydriver"] = driver;
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    _scenarioContext["mydriver"] = driver;
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    _scenarioContext["mydriver"] = driver;
                    break;
                default:
                    //If no driver provided, chrome is used as a default
                    Console.WriteLine("No browser or unknown browser");
                    Console.WriteLine("Using chrome as default");
                    driver = new ChromeDriver();
                    _scenarioContext["mydriver"] = driver;
                    break;
            }
        }

        [After]
        public void TearDown()
        {
            //Removes all items from cart and logs out after closing driver
            HomePagePOM homePage = new HomePagePOM(driver);
            CartPagePOM cartPagePOM = new CartPagePOM(driver);
            MyAccountPagePOM myAccountPagePOM = new MyAccountPagePOM(driver);
            homePage.goCartPage();
            cartPagePOM.RemoveCartItems();
            homePage.goLoginPage();
            myAccountPagePOM.Logout();
            driver.Quit();
            //test
        }
    }
}
