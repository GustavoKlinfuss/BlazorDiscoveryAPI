using BlazorDiscoveryAPI.Application.Base;
using BlazorDiscoveryAPI.Domain.Entities;

namespace BlazorDiscoveryAPI.Application.Commands.Outputs
{
    public class CreatePersonCommandOutput : CommandOutput
    {
        public CreatePersonCommandOutput(Person person)
        {
            Name = person.Name;
            BirthDate = person.BirthDate;
            Document = person.Document;
            Address = new CreatePersonCommandOutputAddress(
                person.Address.Street,
                person.Address.Number,
                person.Address.City,
                person.Address.State,
                person.Address.ZipCode
                );
            Phone = person.Phone;
            Email = person.Email;
        }

        public string Name { get; init; }
        public DateOnly BirthDate { get; init; }
        public string Document { get; init; }
        public CreatePersonCommandOutputAddress Address { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }

        public class CreatePersonCommandOutputAddress
        {
            protected CreatePersonCommandOutputAddress() { }
            public CreatePersonCommandOutputAddress(string street, int number, string city, string state, string zipCode)
            {
                Street = street;
                Number = number;
                City = city;
                State = state;
                ZipCode = zipCode;
            }

            public string Street { get; init; }
            public int Number { get; init; }
            public string City { get; init; }
            public string State { get; init; }
            public string ZipCode { get; init; }
        }
    }
}
