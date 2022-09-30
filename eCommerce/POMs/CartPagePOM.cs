using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce.Support.SupporterStaticMethods;

namespace eCommerce.POMs
{
    internal class CartPagePOM
    {
        IWebDriver driver;
        public CartPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Variables instantiate once called 
        IWebElement couponCode => driver.FindElement(By.Id("coupon_code"));
        IWebElement applyCoupon => driver.FindElement(By.Name("apply_coupon"));

        IWebElement currentPrice => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount > bdi"));
        By currentPriceLocator => By.CssSelector(".cart-subtotal > td");

        IWebElement totalPrice => driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount > bdi"));
        IWebElement couponDiscount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        IWebElement removeItem => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .product-remove > .remove"));
        IWebElement checkoutLink => driver.FindElement(By.LinkText("Proceed to checkout"));




        public void AddCoupon(string coupon)
        {
            //Adds and applies coupon 
            couponCode.SendKeys(coupon);
            applyCoupon.Click();
            WaitForElmStatic(driver, 2, currentPriceLocator);
        }


        //Returns values for current price,total price and coupon discount
        public decimal GetCurrentPrice()
        {
            return  Convert.ToDecimal(currentPrice.Text.Substring(1));
        }

        public decimal GetTotalPrice()
        {
            return Convert.ToDecimal(totalPrice.Text.Substring(1));
        }

        public decimal GetCouponDiscount()
        {
            return Convert.ToDecimal(couponDiscount.Text.Substring(1));
        }


        public void RemoveCartItems()
        {
            //While items are in cart loops, removing the top item until no element is found using try cattch
            bool inCart = true;
            while (inCart)
            {

                try
                {
                    IWebElement itemHere = removeItem;
                    itemHere.Click();
                    Thread.Sleep(1500);
                    inCart = true;
                }
                catch (NoSuchElementException)
                {
                    inCart = false;
                }
            }
        }

        public void GoCheckout()
        {
            //Check out page
            checkoutLink.Click();
        }
    }
}

