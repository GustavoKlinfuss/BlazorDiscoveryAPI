namespace BlazorDiscoveryAPI.Models.Shared
{
    public class AddressRequest
    {
        public string Street { get; init; }
        public int Number { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
    }
}
