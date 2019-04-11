using System;

namespace ContactManager.Models
{
    public class Contact
    {
        public Contact(string Name, string Company, string ProfileImage, string Email, DateTime Birthday, int PhoneNumber, Address Address)
        {
            this.Name = Name;
            this.Company = Company;
            this.ProfileImage = ProfileImage;
            this.Email = Email;
            this.Birthday = Birthday;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
        }

        public void UpdateContact(Contact contact)
        {
            Name = contact.Name;
            Company = contact.Company;
            ProfileImage = contact.ProfileImage;
            Email = contact.Email;
            Birthday = contact.Birthday;
            PhoneNumber = contact.PhoneNumber;
            Address = contact.Address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
