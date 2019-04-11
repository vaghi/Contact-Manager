using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactManager.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult createContact([FromBody] Contact newContact)
        {
            Contact createdContact = _contactService.createContact(newContact);
            return Ok(createdContact);
        }

        [HttpGet("{contactId}")]
        public IActionResult getContact(int contactId)
        {
            Contact contact =_contactService.getContact(contactId);
            return Ok(contact);
        }

        [HttpPut]
        public IActionResult updateContact([FromBody] Contact contact)
        {
            _contactService.updateContact(contact);
            return Ok();
        }

        [HttpDelete("{contactId}")]
        public IActionResult deleteContact(int contactId)
        {
            _contactService.deleteContact(contactId);
            return Ok();
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult getContactByEmail(string email)
        {
            Contact contact = _contactService.getContactByEmail(email);
            return Ok(contact);
        }

        [HttpGet("getByPhone/{phone}")]
        public IActionResult getContactByPhone(string phone)
        {
            Contact contact = _contactService.getContactByPhone(phone);
            return Ok(contact);
        }

        [HttpGet("getContactsFromState/{state}")]
        public IActionResult getContactsByState(string state)
        {
            IList<Contact> contacts = _contactService.getContactsByState(state);
            return Ok(contacts);
        }

        [HttpGet("getContactsFromCity/{city}")]
        public IActionResult getContactsByCity(string city)
        {
            IList<Contact> contacts = _contactService.getContactsByCity(city);
            return Ok(contacts);
        }
    }
}