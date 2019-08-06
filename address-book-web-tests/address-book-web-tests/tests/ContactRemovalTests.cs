using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            ContactData oldData = new ContactData("Петр для удаления", "Петров для удаления");
            //oldData.LastName = "Петров для удаления";

            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}
