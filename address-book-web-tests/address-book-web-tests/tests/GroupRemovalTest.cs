﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData oldData = new GroupData("имя группы для удаления");
            oldData.Header = "хедер удаления";
            oldData.Footer = "футер удаления";


            if (app.Group.IsCheckedElement() == false)
            {
                app.Group.Create(oldData);
            }


            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Remove(0, oldData);

            List<GroupData> newGroups = app.Group.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
