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
        public void AddCoupon(string coupon)
        {
            couponCode.SendKeys(coupon);
        }

        public void ApplyCoupon()
        {
            applyCoupon.Click();
        }

        public string GetCurrentPrice()
        {
            return currentPrice.Text;
        }

        public string GetTotalPrice()
        {
            return totalPrice.Text;
        }
    }
}

