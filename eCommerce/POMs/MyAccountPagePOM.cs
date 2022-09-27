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

        //Variables instantiate once called 
        IWebElement shopLink => driver.FindElement(By.CssSelector("a[rel='home']"));
        IWebElement logoutLink => driver.FindElement(By.LinkText("Logout"));
        IWebElement orderLink => driver.FindElement(By.LinkText("Orders"));
        IWebElement orderNumber => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
        public void GoShop()
        {
            //Opens shop
            shopLink.Click();
        }

        public void Logout()
        {
            //Logs out
            logoutLink.Click();
        }
        
        public void GoOrders()
        {
            //Goes to order page from myaccountpage
            orderLink.Click();
        }

        public int GetOrderNumber()
        {
            //Converts order nubmer string to int for comparison
            return Convert.ToInt32(orderNumber.Text.Substring(1));
        }
    }
}

