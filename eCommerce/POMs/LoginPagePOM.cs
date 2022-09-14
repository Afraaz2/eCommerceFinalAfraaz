﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.POMs
{
    internal class LoginPagePOM
    {
        IWebDriver driver;
        public LoginPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement usernameField => driver.FindElement(By.Id("username"));
        IWebElement passwordField => driver.FindElement(By.Id("password"));
        IWebElement loginButton => driver.FindElement(By.CssSelector("button[name='login']"));

        public LoginPagePOM setUsername(string username)
        {
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPagePOM setPassword(string password)
        {
            passwordField.SendKeys(password);
            return this;
        }

        public void goSubmit()
        {
            loginButton.Click();
        }

    }
}
