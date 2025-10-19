namespace SharedLibrary.Contracts.Common
{
    public class AddressDto
    {
        public string Street { get; init; } = default!;
        public string City { get; init; } = default!;
        public string PostalCode { get; init; } = default!;
        public string Country { get; init; } = default!;
    }
}
