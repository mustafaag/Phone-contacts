using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ContactFunctions : IContacts
    {
        public static string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "DAL", "DATA");
        public Contacts AddContact(Contacts contact)
        {

            List<Contacts> contacts = GetContacts();

            contact.ID = contacts.Max(x => x.ID) + 1;
            contact.IsDeleted = false;           

            List<ContactType> contactTypesList = GetContactTypes();

            if (contactTypesList.Count(x=>x.ID ==contact.ContactTypeId) == 0)
            {
                return null;
            }
            contacts.Add(contact);
            Helpers.WriteAllContacts(contacts);
            return contact;
        }

        public bool DeleteContact(int ID)
        {

            List<Contacts> contacts = GetContacts();

            Contacts contactToDelete = contacts.FirstOrDefault(c => c.ID == ID);
            if(contactToDelete != null)
            {
                contacts.Remove(contactToDelete);

                Helpers.WriteAllContacts(contacts);
                return true;
            }
            return false;

        }

        public Contacts GetContact(int ID)
        {
            List<Contacts> contacts = GetContacts();
            return contacts.FirstOrDefault(c => c.ID == ID);          
        }

        public List<Contacts> GetContacts()
        {
            var contactsPath = Path.Combine(path, "contacts.json");
            var contactsJson = File.ReadAllText(contactsPath);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contacts>>(contactsJson).ToList();
        }

        public List<ContactType> GetContactTypes()
        {
            var contactTypePath = Path.Combine(path, "contactType.json");
            var types = File.ReadAllText(contactTypePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContactType>>(types).ToList();
        }

        public Contacts UpdateContact(int id, Contacts contact)
        {
            List<Contacts> contacts = GetContacts();
            contacts.Where(x => x.ID == id).ToList().ForEach(x =>
            {
                x.FName = contact.FName;
                x.LName = contact.LName;
            });

            Helpers.WriteAllContacts(contacts);

            return GetContact(id);
        }

        public IEnumerable<Contacts> GetOrderd(string direction, string param)
        {
            List<Contacts> contacts = GetContacts();
            if(direction == "asc")
            {
                if(param == "fname")
                {
                    return contacts.OrderBy(x => x.FName);
                }
                else
                {
                    return contacts.OrderBy(x => x.LName);
                }
            }
            else
            {
                if (param == "fname")
                {
                    return contacts.OrderByDescending(x => x.FName);
                }
                else
                {
                    return contacts.OrderByDescending(x => x.LName);
                }
            }
        }
    }
}
