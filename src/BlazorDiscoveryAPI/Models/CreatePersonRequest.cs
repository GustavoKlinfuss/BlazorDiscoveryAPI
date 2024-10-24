using BlazorDiscoveryAPI.Models.Shared;

namespace BlazorDiscoveryAPI.Models
{
    public class CreatePersonRequest
    {
        public string Name { get; init; }
        public DateTime BirthDate { get; init; }
        public string Document { get; init; }
        public AddressRequest Address { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
    }
}
