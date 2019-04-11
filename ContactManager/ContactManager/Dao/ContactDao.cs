using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Dao
{
    public class ContactDao : IContactDao
    {
        private readonly List<Contact> _contacts = new List<Contact>();
        private int contactId = 0;

        public Contact createContact(Contact contact)
        {
            contact.Id = ++this.contactId;
            _contacts.Add(contact);

            return getContact(contact.Id);
        }

        public void deleteContact(int contactId)
        {
            _contacts.RemoveAll(c => c.Id == contactId);
        }

        public IList<Contact> getContactsByCity(string city)
        {
            return _contacts.Where(c => c.Address.City.ToLower().Equals(city.ToLower())).ToList();
        }

        public IList<Contact> getContactsByState(string state)
        {
            return _contacts.Where(c => c.Address.State.ToLower().Equals(state.ToLower())).ToList();
        }

        public Contact getContact(int contactId)
        {
            return _contacts.FirstOrDefault(c => c.Id == contactId);
        }

        public Contact getContactByPhone(int phoneNumber)
        {
            return _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }

        public Contact getContactByEmail(string email)
        {
            return _contacts.FirstOrDefault(c => c.Email.ToLower() == email.ToLower());
        }

        public void updateContact(Contact contact)
        {
            Contact contactToUpdate = getContact(contact.Id);
            contactToUpdate.UpdateContact(contact);
        }
    }
}
