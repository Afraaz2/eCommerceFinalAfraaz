using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using static eCommerce.Support.SupporterStaticMethods;

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


        [When(@"I proceed to check out and fill out all key information, using (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void CheckOut(string firstName, string lastName, string phone, string postcode, string city, string address, string email)
        {
            //Fills out cart page and checks out
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            cartPagePOM.GoCheckout();
            checkoutPage.fillBillingDetails(firstName,lastName,phone,postcode, city,address,email);
            TakeScreenShot(_driver, "Billing details filled");
            Console.WriteLine("Billing details filled");
        }

        [When(@"I complete order and fetch the order number")]
        public void CompleteOrder()
        {
            //Completes order and saves order number to class wide scope variable
            CheckoutPagePOM checkoutPage = new CheckoutPagePOM(_driver);
            OrderCompletePagePOM orderPage = new OrderCompletePagePOM(_driver);
            checkoutPage.placeOrder();
            Thread.Sleep(1500);
            orderNumber = orderPage.returnOrderNumber();
            TakeScreenShot(_driver, "Order placed");
            Console.WriteLine("Order placed");
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
            TakeScreenShot(_driver, "Order number in account information");
            Assert.That(orderNumber == savedOrderNumber, "The order numbers do no match up");
        }
    }
}
