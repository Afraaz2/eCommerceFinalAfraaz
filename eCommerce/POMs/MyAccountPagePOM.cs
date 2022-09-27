using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eCommerce.POMs
{
    internal class MyAccountPagePOM
    {
        IWebDriver driver;
        public MyAccountPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement shopLink => driver.FindElement(By.CssSelector("a[rel='home']"));
        IWebElement logoutLink => driver.FindElement(By.LinkText("Logout"));
        public void GoShop()
        {
            shopLink.Click();
        }

        public void Logout()
        {
            logoutLink.Click();
        }
    }
}

