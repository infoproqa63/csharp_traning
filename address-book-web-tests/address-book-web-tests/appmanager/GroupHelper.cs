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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager): base (manager)
        {
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            InitGropCreation();
            FillGroup(group);
            SubmitGroup();
            manager.Navigator.OpenGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData oldData, GroupData newData)
        {

            //manager.Navigator.OpenGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroup(newData);
            SubmitGroupModification();
            manager.Navigator.OpenGroupPage();
            return this;
        }

        public GroupHelper Remove(int v, GroupData oldData)
        {
            //manager.Navigator.OpenGroupPage();
            SelectGroup(v);
            RemoveGroup();
            manager.Navigator.OpenGroupPage();
            return this;
        }

        public GroupHelper InitGropCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ index +"]")).Click();
            return this;
        }

        public GroupHelper FillGroup(GroupData group)
        {
            //driver.FindElement(By.Name("group_name")).Click();
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        
        public GroupHelper SubmitGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public bool IsCheckedElement()
        {
            manager.Navigator.OpenGroupPage();
            return IsElementPresent(By.XPath("//*[@id='content']/form/span/input"));
            
        }
                
    }
}
