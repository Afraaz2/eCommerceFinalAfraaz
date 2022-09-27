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
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)scenarioContext["mydriver"];
            WebDriverWait myWait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(2));

        }

        [Given(@"I am on the shop page")]
        public void GivenIAmOnTheShopPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I can add an item to my cart and view the cart")]
        public void ThenICanAddAnItemToMyCartAndViewTheCart()
        {
            ShopPagePOM shopPOM = new ShopPagePOM(_driver);
            shopPOM.AddToCart();
            shopPOM.ViewCart();


        }

        [When(@"I add an item to the cart and apply an coupon")]
        public void ThenItemIsInCartAndICanApplyACoupon()
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            cartPagePOM.AddCoupon("edgewords");
            cartPagePOM.ApplyCoupon();
                        
        }

        [Then(@"The coupon gives a discount on the retail value")]
        public void ThenTheCouponGivesADiscountEquivalentToOfTheRetailValue()
        {
           CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            double subTotal = cartPagePOM.GetCurrentPrice();
            double coupon = cartPagePOM.GetCouponDiscount();
            double afterCoupon = subTotal - coupon;
            double percentage = ((subTotal - afterCoupon) / subTotal) * 100;
            Math.Round(percentage, MidpointRounding.AwayFromZero);
            Console.WriteLine("the coupon value is " + coupon + " the percentage return is " + percentage);
            Assert.That(percentage == 15, "Coupon does not apply 15% discount");
        }


    }
}
