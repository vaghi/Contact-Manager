using ContactManager.Controllers;
using ContactManager.Dao;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace UnitTest
{
    public class ContactTest
    {
        ContactController _contactController;
        ContactService _contactService;
        ContactDao _contactDao;

        public ContactTest()
        {
            _contactDao = new ContactDao();
            _contactService = new ContactService(_contactDao);
            _contactController = new ContactController(_contactService);
        }

        [Fact]
        public void CreateContactReturnsOk()
        {
            Contact newContact = getTestContact();

            var response = _contactController.createContact(newContact);
            Assert.IsType<OkObjectResult>(response);

            OkObjectResult OkObjectResult = (OkObjectResult)response;
            Assert.Equal(200, OkObjectResult.StatusCode);
        }

        [Fact]
        public void CreateContactReturnsContactOk()
        {
            Contact newContact = getTestContact();

            OkObjectResult response = _contactController.createContact(newContact) as OkObjectResult;

            Assert.IsType<Contact>(response.Value);

            Contact returnedContact = response.Value as Contact;

            Assert.Equal(1, returnedContact.Id);

            Assert.Equal(newContact.Name, returnedContact.Name);
            Assert.Equal(newContact.ProfileImage, returnedContact.ProfileImage);
            Assert.Equal(newContact.PhoneNumber, returnedContact.PhoneNumber);
            Assert.Equal(newContact.Birthday, returnedContact.Birthday);
            Assert.Equal(newContact.Company, returnedContact.Company);
            Assert.Equal(newContact.Email, returnedContact.Email);
            Assert.Equal(newContact.Address, returnedContact.Address);
        }

        [Fact]
        public void CreateContactIncreasesIdByOne()
        {
            Contact newContact;
            OkObjectResult response;
            Contact returnedContact;

            for(int i = 1; i < 100; i++)
            {
                newContact = getTestContact();
                response = _contactController.createContact(newContact) as OkObjectResult;
                returnedContact = response.Value as Contact;

                Assert.Equal(i, returnedContact.Id);
            }
        }

        [Fact]
        public void CreateContactValidations()
        {
            Contact newContact = getTestContact();
            newContact.Name = null;
            
            Assert.Throws<Exception>(() => _contactController.createContact(newContact));

            newContact.Name = "Agustín";
            OkObjectResult response = _contactController.createContact(newContact) as OkObjectResult;
            Assert.Equal(200, response.StatusCode);
            Assert.IsType<Contact>(response.Value);

            newContact.Email = null;
            Assert.Throws<Exception>(() => _contactController.createContact(newContact));

            newContact.Email = "vaghiagustin@gmail.com";
            response = _contactController.createContact(newContact) as OkObjectResult;
            Assert.Equal(200, response.StatusCode);
            Assert.IsType<Contact>(response.Value);
        }

        [Fact]
        public void GetContactReturnsOk()
        {
            Contact newContact = getTestContact();
            OkObjectResult createResponse = _contactController.createContact(newContact) as OkObjectResult;
            Contact returnedContact = createResponse.Value as Contact;

            var getContactResponse = _contactController.getContact(returnedContact.Id);

            Assert.IsType<OkObjectResult>(getContactResponse);
        }

        [Fact]
        public void CreatedContactWasStored()
        {
            Contact newContact = getTestContact();
            OkObjectResult createResponse = _contactController.createContact(newContact) as OkObjectResult;
            Contact createdContactReturned = createResponse.Value as Contact;

            OkObjectResult getContactResponse = _contactController.getContact(createdContactReturned.Id) as OkObjectResult;
            Contact getContactReturned = createResponse.Value as Contact;

            Assert.IsType<Contact>(getContactResponse.Value);

            Assert.Equal(createdContactReturned.Id, getContactReturned.Id);
            Assert.Equal(createdContactReturned.Name, getContactReturned.Name);
            Assert.Equal(createdContactReturned.ProfileImage, getContactReturned.ProfileImage);
            Assert.Equal(createdContactReturned.PhoneNumber, getContactReturned.PhoneNumber);
            Assert.Equal(createdContactReturned.Birthday, getContactReturned.Birthday);
            Assert.Equal(createdContactReturned.Company, getContactReturned.Company);
            Assert.Equal(createdContactReturned.Email, getContactReturned.Email);
            Assert.Equal(createdContactReturned.Address, getContactReturned.Address);
        }

        private Contact getTestContact()
        {
            Address newAddress = new Address("California", "San Fransokyio", "Fake Street 123", 1426);
            Contact newContact = new Contact(
                "Agustin",
                "Freelance",
                "https://avatars2.githubusercontent.com/u/8461737?s=460&v=4",
                "vaghiagustin@gmail.com",
                new System.DateTime(1987, 3, 24),
                0800666,
                newAddress
            );

            return newContact;
        }
    }
}
