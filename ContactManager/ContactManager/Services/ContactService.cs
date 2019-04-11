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
            ValidateContact(contact);

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

        public Contact getContactByPhone(string phoneNumber)
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
            ValidateUpdateContact(contact);

            _contactDao.updateContact(contact);
        }

        private void ValidateUpdateContact(Contact contact)
        {
            if (getContact(contact.Id) == null)
                throw new Exception("Invalid contact");

            ValidateContact(contact);
        }

        private void ValidateContact(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
                throw new Exception("Invalid name");
            else if (string.IsNullOrEmpty(contact.Email))
                throw new Exception("Invalid email");

            if (string.IsNullOrEmpty(contact.Email) || !IsValidEmail(contact.Email))
                throw new Exception("Invalid email");
            else
            {
                Contact contactByEmail = _contactDao.getContactByEmail(contact.Email);
                if(contactByEmail != null && !contactByEmail.Id.Equals(contact.Id))
                    throw new Exception("Email duplicated");
            }

            if (string.IsNullOrEmpty(contact.Email) || !int.TryParse(contact.PhoneNumber, out int number))
                throw new Exception("Invalid Phone Number");
            else
            {
                Contact contactByPhone = _contactDao.getContactByPhone(contact.PhoneNumber);
                if (contactByPhone != null && !contactByPhone.Id.Equals(contact.Id))
                    throw new Exception("Phone Number duplicated");
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
