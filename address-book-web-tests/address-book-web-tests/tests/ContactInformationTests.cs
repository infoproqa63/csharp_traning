﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactInformationTests : AuthTestBase
    {


        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }


        [Test]
        public void TestContactInformationEditFormAndDetails()
        {
            ContactData fromDetails = app.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            //verifications
            Assert.AreEqual(fromDetails.AllInfo, fromForm.AllInfo);
        }


            //[Test]
            //public void TestContactTest()
            //{
            //    {
            //        ContactData fromViewForm = app.Contact.GetContactInformationFromViewForm(0);
            //        ContactData fromEditForm = app.Contact.GetContactInformationFromEditForm(0);


            //        Console.WriteLine(fromViewForm.DetailedInformation);
            //        Console.WriteLine(fromEditForm.DetailedInformation);
            //        Console.WriteLine("111");
            //        Assert.AreEqual(fromViewForm.DetailedInformation, fromEditForm.DetailedInformation);


            //    }
            //}
        }
}
