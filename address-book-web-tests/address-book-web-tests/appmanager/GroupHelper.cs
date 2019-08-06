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

        public GroupHelper(ApplicationManager manager) : base(manager)
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

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {

                groupCache = new List<GroupData>();
                manager.Navigator.OpenGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });


                }
            }

            return new List<GroupData>(groupCache);
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

        public GroupHelper Modify(GroupData group, GroupData newData)
        {

            manager.Navigator.OpenGroupPage();
            SelectGroup(group.Id);
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

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            SelectGroup(group.Id);
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
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public bool IsCheckedElement()
        {
            manager.Navigator.OpenGroupPage();
            return IsElementPresent(By.XPath("//*[@id='content']/form/span/input"));

        }

        public void CreateGroupIfNoGroups(GroupData group)
        {
            manager.Navigator.OpenGroupPage();
            if (!IsElementPresent(By.CssSelector("form span:nth-child(5)")))
            {
                Create(group);
            }
        }

    }
}
