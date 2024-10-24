﻿using BlazorDiscoveryAPI.Domain.Base;

namespace BlazorDiscoveryAPI.Domain.Entities
{
    public class Person : AggregateRoot
    {
        protected Person() { }
        public Person(string name, DateOnly birthDate, string document, Address address, string phone, string email)
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
        public Address Address { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
    }

    public class Address
    {
        protected Address() { }
        public Address(string street, int number, string city, string state, string zipCode)
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