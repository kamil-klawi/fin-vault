using System.Text.RegularExpressions;

namespace SharedLibrary.Common.ValueObjects
{
    public sealed class Pesel : IEquatable<Pesel>
    {
        public string Value { get; } = null!;

        private Pesel() {}

        public Pesel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("PESEL cannot be null or whitespace!", nameof(value));

            string normalized = value.Replace(" ", "").Trim();

            if (!Regex.IsMatch(normalized, @"^\d{11}$"))
                throw new ArgumentException("PESEL format is invalid!", nameof(value));

            Value = normalized;
        }

        public override string ToString() => Value;
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as Pesel);

        public bool Equals(Pesel? other)
        {
            if (other is not null)
                return Value == other.Value;

            return false;
        }

        public static implicit operator string(Pesel pesel) => pesel.Value;
        public static bool operator ==(Pesel left, Pesel right) => Equals(left, right);
        public static bool operator !=(Pesel left, Pesel right) => !Equals(left, right);
    }
}
