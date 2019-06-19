﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
