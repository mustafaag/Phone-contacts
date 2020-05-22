using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IContacts
    {
        public  Contacts AddContact(Contacts contact);
        Contacts UpdateContact(int id, Contacts contacts);
        bool DeleteContact(int ID);
        List<Contacts> GetContacts();
        Contacts GetContact(int ID);
        List<ContactType> GetContactTypes();

        IEnumerable<Contacts> GetOrderd(string direction, string param);
    }
}
