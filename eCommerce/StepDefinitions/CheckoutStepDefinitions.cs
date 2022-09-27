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
        private double orderNumber;

        public CheckoutStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)scenarioContext["mydriver"];

        }


        [Then(@"I can proceed to check out and fill out all key information")]
        public void CheckOut()
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            cartPagePOM.GoCheckout();
            checkoutPage.fillBillingDetails();
        }

        [Then(@"I can Complete order and fetch the order number")]
        public void CompleteOrder()
        {
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            OrderCompletePagePOM orderPage = new OrderCompletePagePOM(_driver);
            checkoutPage.placeOrder();
            orderNumber = orderPage.returnOrderNumber();
            Console.WriteLine("The order nubmer is " + orderNumber);

        }

        [Then(@"I can navigate to my orders and check the same order shows in the account")]
        public void NavigateToOrder()
        {
            MyAccountPagePOM accountPagePOM = new MyAccountPagePOM(_driver);
            HomePagePOM homePagePOM = new HomePagePOM(_driver);
            homePagePOM.goLoginPage();
            accountPagePOM.GoOrders();
            int savedOrderNumber = accountPagePOM.GetOrderNumber();

            Assert.That(orderNumber == savedOrderNumber, "The order numbers do no match up");
        }
    }
}
