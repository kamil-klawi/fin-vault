namespace IdentityService.Domain.ValueObjects
{
    public sealed class PasswordHash : IEquatable<PasswordHash>
    {
        public string Value { get; } = null!;

        private PasswordHash() {}

        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be null or whitespace!", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as PasswordHash);

        public bool Equals(PasswordHash? other)
        {
            if (other is not null)
                return Value == other.Value;

            return false;
        }

        public static implicit operator string(PasswordHash passwordHash) => passwordHash.Value;
        public static bool operator ==(PasswordHash left, PasswordHash right) => Equals(left, right);
        public static bool operator !=(PasswordHash left, PasswordHash right) => !Equals(left, right);
    }
}
