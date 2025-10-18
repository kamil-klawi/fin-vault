namespace SharedLibrary.Common.ValueObjects
{
    public sealed class TransactionId : IEquatable<TransactionId>
    {
        public Guid Value { get; }

        private TransactionId() {}

        public TransactionId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("TransactionId cannot be empty GUID!", nameof(value));

            Value = value;
        }

        public static TransactionId NewId() => new TransactionId(Guid.NewGuid());

        public override string ToString() => Value.ToString();
        public override int GetHashCode() => Value.GetHashCode();
        public override bool Equals(object? obj) => Equals(obj as TransactionId);

        public bool Equals(TransactionId? other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }

        public static bool operator ==(TransactionId? left, TransactionId? right) => Equals(left, right);
        public static bool operator !=(TransactionId? left, TransactionId? right) => !Equals(left, right);
    }
}
