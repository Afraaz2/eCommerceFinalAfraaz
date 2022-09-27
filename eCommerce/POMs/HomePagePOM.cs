using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.POMs
{
    internal class HomePagePOM
    {
        IWebDriver driver;
        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement loginLink => driver.FindElement(By.LinkText("My account"));
        IWebElement cartLink => driver.FindElement(By.LinkText("Cart"));
        public void goLoginPage()
        {
            loginLink.Click();
        }

        public void goCartPage()
        {
            cartLink.Click();
        }
    }
}
