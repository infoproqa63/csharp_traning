using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : GroupTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData()
                {
                    FistName = GenerateRandomString(10),
                    LastName = GenerateRandomString(20),
                    Address = GenerateRandomString(30)
                });


            }


            return contacts;

        }


        public static IEnumerable<ContactData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));

        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAll();


            app.Contact.Create(contact);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }


        [Test]
        public void TestDBConnectivityContact()
        {

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            System.Console.Out.WriteLine(toBeRemoved.Id);

            //DateTime start = DateTime.Now;
            //List<ContactData> fromUI = app.Contact.GetContactList();
            //DateTime end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));

            //start = DateTime.Now;
            //List<ContactData> fromDB = ContactData.GetAll();

            //end = DateTime.Now;
            //System.Console.Out.WriteLine(end.Subtract(start));
        }

    }
}
