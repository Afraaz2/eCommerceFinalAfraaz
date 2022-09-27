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
        //Variables instantiate once called 
        IWebElement loginLink => driver.FindElement(By.LinkText("My account"));
        IWebElement cartLink => driver.FindElement(By.LinkText("Cart"));

        //Login page/account page link
        public void goLoginPage()
        {
            loginLink.Click();
        }

        //cart page link method
        public void goCartPage()
        {
            cartLink.Click();
        }
    }
}
