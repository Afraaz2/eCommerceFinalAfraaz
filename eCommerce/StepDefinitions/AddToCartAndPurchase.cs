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
    public class AddToCartAndPurchase
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public AddToCartAndPurchase(ScenarioContext scenarioContext)
        {
            //Fetches current instance of driver
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)scenarioContext["mydriver"];

        }

        [When(@"I add an item to my cart and view the cart")]
        public void CartManagement()
        {
            //Adds to cart and views item
            ShopPagePOM shopPOM = new ShopPagePOM(_driver);
            shopPOM.AddToCart();
            shopPOM.ViewCart();
            Console.WriteLine("Item added to cart");
            TakeScreenShot(_driver, "Item in cart");
        }

        [When(@"I add an item to the cart and apply coupon (.*)")]
        public void ApplyCoupon(string coupon)
        {
            //Applys coupon declared in the gherkin file
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            cartPagePOM.AddCoupon(coupon);
            TakeScreenShot(_driver, "Coupon applied");
            Console.WriteLine("Coupon applied");
            Thread.Sleep(1000);
        }

        [Then(@"The coupon gives a discount of (.*)% on the retail value")]
        public void CouponDiscountVerification(int targetPercentage)
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            decimal subTotal = cartPagePOM.GetCurrentPrice();
            decimal coupon = cartPagePOM.GetCouponDiscount();
            decimal percentage = ((subTotal - (subTotal - coupon)) / subTotal) * 100;
            Math.Round(percentage, 2);
            Console.WriteLine($"The coupon applies a {percentage}% discount, the target percentage is {targetPercentage}%");
            Assert.That(percentage == targetPercentage, ($"Coupon does not apply {targetPercentage}% discount"));
        }


    }
}
