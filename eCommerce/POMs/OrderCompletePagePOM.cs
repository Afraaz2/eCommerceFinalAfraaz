using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.POMs
{
    internal class OrderCompletePagePOM
    {
        IWebDriver driver;
        public OrderCompletePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Variables instantiate once called 
        IWebElement orderNumber => driver.FindElement(By.CssSelector(".order_details.woocommerce-thankyou-order-details > .order"));

        public int returnOrderNumber()
        {
            //Fetches order number and converts it to an integer
            return Convert.ToInt32(orderNumber.Text.Substring(13));
        }
    }
}
