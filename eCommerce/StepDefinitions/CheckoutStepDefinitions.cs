using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace eCommerce.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions { 

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private int orderNumber;

        public CheckoutStepDefinitions(ScenarioContext scenarioContext)
        {
            //Fetches current instance of driver
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)scenarioContext["mydriver"];

        }


        [Then(@"I can proceed to check out and fill out all key information")]
        public void CheckOut()
        {
            //Fills out cart page and checks out
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            cartPagePOM.GoCheckout();
            checkoutPage.fillBillingDetails();
        }

        [Then(@"I can Complete order and fetch the order number")]
        public void CompleteOrder()
        {
            //Completes order and saves order number to class wide scope variable
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            OrderCompletePagePOM orderPage = new OrderCompletePagePOM(_driver);
            checkoutPage.placeOrder();
            Thread.Sleep(1500);
            orderNumber = orderPage.returnOrderNumber();
        }

        [Then(@"I can navigate to my orders and check the same order shows in the account")]
        public void NavigateToOrder()
        {
            //Gets order number from account page and uses it to compare to global order variable
            MyAccountPagePOM accountPagePOM = new MyAccountPagePOM(_driver);
            HomePagePOM homePagePOM = new HomePagePOM(_driver);
            homePagePOM.goLoginPage();
            accountPagePOM.GoOrders();
            int savedOrderNumber = accountPagePOM.GetOrderNumber();
            Console.WriteLine("The order nubmer is " + savedOrderNumber);

            Assert.That(orderNumber == savedOrderNumber, "The order numbers do no match up");
        }
    }
}
