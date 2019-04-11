using System;
using System.Collections.Generic;
using ContactManager.Dao;
using ContactManager.Models;

namespace ContactManager.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactDao _contactDao;

        public ContactService(IContactDao contactDao)
        {
            _contactDao = contactDao;
        }

        public Contact createContact(Contact contact)
        {
            validateContact(contact);

            return _contactDao.createContact(contact);
        }

        public void deleteContact(int contactId)
        {
            if (getContact(contactId) == null)
                throw new Exception("Invalid contact Id");

            _contactDao.deleteContact(contactId);
        }

        public IList<Contact> getContactsByCity(string city)
        {
            return _contactDao.getContactsByCity(city);
        }

        public IList<Contact> getContactsByState(string state)
        {
            return _contactDao.getContactsByState(state);
        }

        public Contact getContact(int contactId)
        {
            Contact contact = _contactDao.getContact(contactId);

            if (contact != null)
                return contact;
            else
                throw new Exception("Invalid contact Id");
        }

        public Contact getContactByPhone(int phoneNumber)
        {
            Contact contact = _contactDao.getContactByPhone(phoneNumber);

            if (contact != null)
                return contact;
            else
                throw new Exception("Contact not found");
        }

        public Contact getContactByEmail(string email)
        {
            Contact contact = _contactDao.getContactByEmail(email);

            if (contact != null)
                return contact;
            else
                throw new Exception("Contact not found");
        }

        public void updateContact(Contact contact)
        {
            validateUpdateContact(contact);

            _contactDao.updateContact(contact);
        }

        private void validateUpdateContact(Contact contact)
        {
            if (getContact(contact.Id) == null)
                throw new Exception("Invalid contact");

            validateContact(contact);
        }

        private void validateContact(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
                throw new Exception("Invalid name");
            else if (string.IsNullOrEmpty(contact.Email))
                throw new Exception("Invalid email");

            if(!string.IsNullOrEmpty(contact.Email))
            {
                Contact contactByEmail = _contactDao.getContactByEmail(contact.Email);
                if(contactByEmail != null && !contactByEmail.Id.Equals(contact.Id))
                    throw new Exception("Email duplicated");
            }

            if (contact.PhoneNumber != 0)
            {
                Contact contactByPhone = _contactDao.getContactByPhone(contact.PhoneNumber);
                if (contactByPhone != null && !contactByPhone.Id.Equals(contact.Id))
                    throw new Exception("Email duplicated");
            }
        }
    }
}
