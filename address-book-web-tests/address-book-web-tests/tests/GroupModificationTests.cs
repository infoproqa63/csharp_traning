﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData oldData = new GroupData("имя группы для переименования");
            oldData.Header = "хедер переименования";
            oldData.Footer = "футер переименования";

            GroupData newData = new GroupData("имя группы");
            newData.Header = "хедер";
            newData.Footer = "футер";


            if (app.Group.IsCheckedElement() == false)
            {
                app.Group.Create(oldData);
            }



            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModify = oldGroups[0];

            app.Group.Modify(toBeModify, newData);

            //List<GroupData> newGroups = app.Group.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModify.Id)
                {
                    Assert.AreEqual(newData.Name, toBeModify.Name);
                }
            }
        }
    }
}
