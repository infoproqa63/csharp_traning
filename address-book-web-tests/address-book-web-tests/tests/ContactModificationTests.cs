using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Петр", "Петров");
            //newData.LastName = "Петров";

            ContactData oldData = new ContactData("Петр для редактирования", "Петров для редактирования");
            //oldData.LastName = "Петров для редактирования";


            if (app.Contact.IsCheckedContact() == false)
            {
                app.Contact.Create(oldData);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModify = oldContacts[0];

            app.Contact.Modify(0, oldData, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            //oldContacts.Add(contact);
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FistName = newData.FistName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModify.Id)
                {
                    Assert.AreEqual(newData.FistName, toBeModify.FistName);
                }
            }

            //List<GroupData> newGroups = app.Group.GetGroupList();

            //oldGroups[0].Name = newData.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);

            //foreach (GroupData group in newGroups)
            //{
            //    if (group.Id == toBeModify.Id)
            //    {
            //        Assert.AreEqual(newData.Name, toBeModify.Name);
            //    }
            //}
        }
    }
}
