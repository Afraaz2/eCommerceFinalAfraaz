using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

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
            Thread.Sleep(5000);
            shopPOM.ViewCart();


        }

        [When(@"I add an item to the cart and apply an coupon")]
        public void ThenItemIsInCartAndICanApplyACoupon()
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            cartPagePOM.AddCoupon("edgewords");
            cartPagePOM.ApplyCoupon();
            Console.Write(cartPagePOM.GetCurrentPrice());
            
            
        }

        [Then(@"The coupon gives a discount on the retail value")]
        public void ThenTheCouponGivesADiscountEquivalentToOfTheRetailValue()
        {
            throw new PendingStepException();
        }
    }
}
