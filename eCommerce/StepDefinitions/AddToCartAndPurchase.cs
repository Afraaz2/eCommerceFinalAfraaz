using System;
using TechTalk.SpecFlow;
using eCommerce.POMs;
using OpenQA.Selenium;
using static eCommerce.StepDefinitions.Hooks;
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

        [Then(@"Item is in cart and I can apply a coupon")]
        public void ThenItemIsInCartAndICanApplyACoupon()
        {
            CartPagePOM cartPagePOM = new CartPagePOM(_driver);
            cartPagePOM.AddCoupon("edgewords");
            cartPagePOM.ApplyCoupon();
            Console.Write(cartPagePOM.GetCurrentPrice());
            
            
        }

        [Then(@"The coupon gives a discount equivalent to (.*)% of the retail value")]
        public void ThenTheCouponGivesADiscountEquivalentToOfTheRetailValue(int p0)
        {
            throw new PendingStepException();
        }
    }
}
