using BlazorDiscoveryAPI.Application.Base;
using MediatR;

namespace BlazorDiscoveryAPI.Application.Commands
{
    public class CreatePersonCommand : IRequest<BaseResult>
    {
        public CreatePersonCommand(string name, DateOnly birthDate, string document, CreatePersonCommandAddress address, string phone, string email)
        {
            Name = name;
            BirthDate = birthDate;
            Document = document;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public string Name { get; init; }
        public DateOnly BirthDate { get; init; }
        public string Document { get; init; }
        public CreatePersonCommandAddress Address { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }

        public class CreatePersonCommandAddress
        {
            public CreatePersonCommandAddress(string street, int number, string city, string state, string zipCode)
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
