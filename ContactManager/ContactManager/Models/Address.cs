namespace ContactManager.Models
{
    public class Address
    {
        public Address(string State, string City, string Street, short CP)
        {
            this.State = State;
            this.City = City;
            this.Street = Street;
            this.CP = CP;
        }

        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short CP { get; set; }
    }
}
