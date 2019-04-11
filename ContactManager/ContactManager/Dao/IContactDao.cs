using ContactManager.Models;
using System.Collections.Generic;

namespace ContactManager.Dao
{
    public interface IContactDao
    {
        Contact createContact(Contact contact);
        Contact getContact(int contactId);
        void deleteContact(int contactId);
        void updateContact(Contact contact);
        Contact getContactByPhone(int phoneNumber);
        Contact getContactByEmail(string email);
        IList<Contact> getContactsByState(string state);
        IList<Contact> getContactsByCity(string city);
    }
}