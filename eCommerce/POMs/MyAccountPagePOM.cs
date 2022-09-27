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
        IWebElement orderLink => driver.FindElement(By.LinkText("Orders"));
        IWebElement orderNumber => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
        public void GoShop()
        {
            shopLink.Click();
        }

        public void Logout()
        {
            logoutLink.Click();
        }
        
        public void GoOrders()
        {
            orderLink.Click();
        }

        public int GetOrderNumber()
        {
            return Convert.ToInt32(orderNumber.Text.Substring(1));
        }
    }
}

