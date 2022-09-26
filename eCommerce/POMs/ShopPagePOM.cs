using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        IWebElement itemLink => driver.FindElement(By.CssSelector(".post-32:nth-child(3) > .button"));
        IWebElement cartLink => driver.FindElement(By.LinkText("View cart"));
        public void AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until();
            itemLink.Click();
        }

        public void ViewCart()
        {
            cartLink.Click();
        }
    }
}

