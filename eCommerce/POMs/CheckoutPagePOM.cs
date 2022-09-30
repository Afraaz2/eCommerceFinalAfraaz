using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.POCOs;

namespace eCommerce.POMs
{
    internal class CheckoutPagePOM
    {
        IWebDriver driver;
        public CheckoutPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Variables instantiate once called 
        IWebElement firstNameField => driver.FindElement(By.Id("billing_first_name"));
        IWebElement lastNameField => driver.FindElement(By.Id("billing_last_name"));
        IWebElement addressField => driver.FindElement(By.Id("billing_address_1"));
        IWebElement cityField => driver.FindElement(By.Id("billing_city"));
        IWebElement postcodeField => driver.FindElement(By.Id("billing_postcode"));
        IWebElement phoneField => driver.FindElement(By.Id("billing_phone"));
        IWebElement emailField => driver.FindElement(By.Id("billing_email"));
        IWebElement checkPaymentsButton => driver.FindElement(By.CssSelector(".payment_method_cheque.wc_payment_method > label"));
        IWebElement placeOrderButton => driver.FindElement(By.CssSelector("button#place_order"));

        public void fillBillingDetails(string firstName, string lastName, string phone, string postcode, string city, string address, string email)
        {
            //Clears every field and then sends data in for check outs
            firstNameField.Clear();
            lastNameField.Clear();
            addressField.Clear();
            cityField.Clear();
            postcodeField.Clear();
            phoneField.Clear();
            emailField.Clear();

            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            addressField.SendKeys(address);
            cityField.SendKeys(city);
            phoneField.SendKeys(phone);
            postcodeField.SendKeys(postcode);
            emailField.SendKeys(email);
            checkPaymentsButton.Click();
            Thread.Sleep(5000);
        }
       
        public void placeOrder()
        {
            //Presses the place order button
            placeOrderButton.Click();
        }

        
    }
}
