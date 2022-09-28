using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce.Support.SupporterStaticMethods;

namespace eCommerce.POMs
{
    internal class ShopPagePOM
    {
        IWebDriver driver;
        public ShopPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Variables instantiate once called 
        IWebElement noticeLink => driver.FindElement(By.CssSelector(".demo_store.woocommerce-store-notice > .woocommerce-store-notice__dismiss-link"));
        IWebElement itemLink => driver.FindElement(By.CssSelector(".storefront-product-section.storefront-recent-products .has-post-thumbnail.instock.post-37.product.product-type-simple.product_cat-tshirts.purchasable.shipping-taxable.status-publish.type-product > .add_to_cart_button.ajax_add_to_cart.button.product_type_simple"));
        IWebElement cartLink => driver.FindElement(By.LinkText("View cart"));
        By cartLinkLocator => By.LinkText("View cart");



        public void AddToCart()
        {
            //Adds item to cart and removes notice
            noticeLink.Click();
            itemLink.Click();
        }

        public void ViewCart()
        {
            //View cart
            //Thread.Sleep(1000);
            WaitForElmStatic(driver, 2, cartLinkLocator);
            cartLink.Click();
        }
    }
}

