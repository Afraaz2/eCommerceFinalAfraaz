using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

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

        [Then(@"I can add an item to my cart and view the cart")]
        public void CartManagement()
        {
            //Adds to cart and views item
            ShopPagePOM shopPOM = new ShopPagePOM(_driver);
            shopPOM.AddToCart();
            shopPOM.ViewCart();

        }

        [When(@"I add an item to the cart and apply coupon (.*)")]
        public void ApplyCoupon(string coupon)
        {
            //Applys coupon edgewords
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            cartPagePOM.AddCoupon(coupon);
            cartPagePOM.ApplyCoupon();
            Thread.Sleep(1000);
                        
        }

        [Then(@"The coupon gives a discount on the retail value")]
        public void CouponDiscountVerification()
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            double subTotal = cartPagePOM.GetCurrentPrice();
            double coupon = cartPagePOM.GetCouponDiscount();
            double afterCoupon = subTotal - coupon;
            double percentage = ((subTotal - afterCoupon) / subTotal) * 100;
            int intPercentage = Convert.ToInt32(percentage);
            Assert.That(intPercentage == 10, "Coupon does not apply 15% discount");
        }


    }
}
