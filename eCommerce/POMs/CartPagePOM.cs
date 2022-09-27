using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.POMs
{
    internal class CartPagePOM
    {
        IWebDriver driver;
        public CartPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement couponCode => driver.FindElement(By.Id("coupon_code"));
        IWebElement applyCoupon => driver.FindElement(By.Name("apply_coupon"));
        IWebElement currentPrice => driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount > bdi"));
        IWebElement totalPrice => driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount > bdi"));
        IWebElement couponDiscount => driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
        IWebElement removeItem => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .product-remove > .remove"));
        public void AddCoupon(string coupon)
        {
            couponCode.SendKeys(coupon);
        }

        public void ApplyCoupon()
        {
            applyCoupon.Click();
        }

        public double GetCurrentPrice()
        {
            return  Convert.ToDouble(currentPrice.Text.Substring(1));
        }

        public double GetTotalPrice()
        {
            return Convert.ToDouble(totalPrice.Text.Substring(1));
        }

        public double GetCouponDiscount()
        {
            return Convert.ToDouble(couponDiscount.Text.Substring(1));
        }

        public void RemoveCartItems()
        {
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
                catch (NoSuchElementException e)
                {
                    inCart = false;
                }
            }


        }
    }
}

