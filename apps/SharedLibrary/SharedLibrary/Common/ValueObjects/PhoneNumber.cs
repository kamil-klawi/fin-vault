using System.Text.RegularExpressions;

namespace SharedLibrary.Common.ValueObjects
{
    public sealed class PhoneNumber : IEquatable<PhoneNumber>
    {
        public string Value { get; } = null!;

        private PhoneNumber() {}

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or whitespace!", nameof(value));

            string normalized = value.Trim();

            if (!Regex.IsMatch(normalized, @"^\d{9}$"))
                throw new ArgumentException("Phone number format is invalid!", nameof(value));

            Value = normalized;
        }

        public bool Equals(PhoneNumber? other)
        {
            throw new NotImplementedException();
        }
    }
}
