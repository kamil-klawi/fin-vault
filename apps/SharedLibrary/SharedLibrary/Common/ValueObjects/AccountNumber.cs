using System.Text.RegularExpressions;

namespace SharedLibrary.Common.ValueObjects
{
    public sealed class AccountNumber : IEquatable<AccountNumber>
    {
        public string Value { get; } = null!;

        private AccountNumber() {}

        public AccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Account number cannot be null or whitespace!", nameof(value));

            if (!Regex.IsMatch(value, @"^\d{26}$"))
                throw new ArgumentException("Invalid account number format!");

            Value = value;
        }

        public override string ToString() => Value;
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as AccountNumber);

        public bool Equals(AccountNumber? other)
        {
            if (other is not null)
                return Value == other.Value;

            return false;
        }

        public static implicit operator string(AccountNumber accountNumber) => accountNumber.Value;
        public static bool operator ==(AccountNumber left, AccountNumber right) => Equals(left, right);
        public static bool operator !=(AccountNumber left, AccountNumber right) => !Equals(left, right);
    }
}
