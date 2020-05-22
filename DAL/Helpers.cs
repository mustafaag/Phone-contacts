using DAL.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public class Helpers
    {
        public static string  path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "DAL", "DATA");
      

        public static bool WriteAllContacts(List<Contacts> contacts)
        {
            try
            {
                var contactsPath = Path.Combine(path, "contacts.json");
                string contactList = Newtonsoft.Json.JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(contactsPath, contactList);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public static string ReadAllContactTypes()
        {
            var contactTypePath = Path.Combine(path, "contactType.json");
            var types = File.ReadAllText(contactTypePath);
            return types;
        }
    }
}
