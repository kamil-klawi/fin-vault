using System.Text.RegularExpressions;


namespace SharedLibrary.Common.ValueObjects
{
    public sealed class Email : IEquatable<Email>
    {
        public string Value { get; } = null!;

        private Email() {}

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or whitespace!", nameof(value));

            string normalized = value.Trim().ToLowerInvariant();

            if(!Regex.IsMatch(normalized, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email format is invalid!", nameof(value));

            Value = normalized;
        }

        public override string ToString() => Value;
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as Email);

        public bool Equals(Email? other)
        {
            if (other is not null)
                return Value == other.Value;

            return false;
        }

        public static implicit operator string(Email email) => email.Value;
        public static bool operator ==(Email left, Email right) => Equals(left, right);
        public static bool operator !=(Email left, Email right) => !Equals(left, right);
    }
}
