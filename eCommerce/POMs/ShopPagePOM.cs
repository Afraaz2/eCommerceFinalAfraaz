using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.POMs
{
    internal class ShopPagePOM
    {
        IWebDriver driver;
        public ShopPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement itemLink => driver.FindElement(By.CssSelector(".storefront-product-section:nth-child(3) .product:nth-child(2) > .button"));

        IWebElement cartLink => driver.FindElement(By.LinkText("View cart"));
        public void AddToCart()
        {
            itemLink.Click();
        }

        public void ViewCart()
        {
            cartLink.Click();
        }
    }
}

