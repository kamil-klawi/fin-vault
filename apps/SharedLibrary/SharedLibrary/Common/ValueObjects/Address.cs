using System.Text.RegularExpressions;

namespace SharedLibrary.Common.ValueObjects
{
    public sealed class Address : IEquatable<Address>
    {
        public string Street { get; } = null!;
        public string City { get; } = null!;
        public string PostalCode { get; } = null!;
        public string Country { get; } = null!;

        private Address() {}

        public Address(string? street, string? city, string? postalCode, string? country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be null or whitespace!", nameof(street));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be null or whitespace!", nameof(city));

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("PostalCode cannot be null or whitespace!", nameof(postalCode));

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be null or whitespace!", nameof(country));

            if(!Regex.IsMatch(postalCode, @"^\d{2}-\d{3}$"))
                throw new ArgumentException("Postal code format is invalid!", nameof(postalCode));

            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public override string ToString() => $"{Street}, {PostalCode} {City}, {Country}";

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Street.ToLowerInvariant(),
                City.ToLowerInvariant(),
                PostalCode,
                Country.ToLowerInvariant()
            );
        }

        public override bool Equals(object? obj) => Equals(obj as Address);

        public bool Equals(Address? other)
        {
            if (other is not null)
            {
                return string.Equals(Street, other.Street, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(City, other.City, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(PostalCode, other.PostalCode, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(Country, other.Country, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        public static bool operator ==(Address left, Address right) => Equals(left, right);
        public static bool operator !=(Address left, Address right) => !Equals(left, right);
    }
}
