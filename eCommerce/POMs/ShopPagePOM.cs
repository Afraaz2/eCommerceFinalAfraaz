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
        IWebElement itemLink => driver.FindElement(By.XPath("//main[@id='main']/section[@class='storefront-product-section storefront-recent-products']//ul//a[@href='?add-to-cart=36']"));
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

