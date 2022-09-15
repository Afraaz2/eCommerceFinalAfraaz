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

        IWebElement shopLink => driver.FindElement(By.CssSelector("a[rel='home']"));

        public void goShop()
        {
            shopLink.Click();
        }
    }
}

