using SharedLibrary.Common.Enums;

namespace SharedLibrary.Common.ValueObjects
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public CurrencyCode Currency { get; }

        private Money() {}

        public Money(decimal amount, CurrencyCode currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be less than zero!", nameof(amount));

            Amount = Math.Round(amount, 2, MidpointRounding.ToEven);;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies!");

            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot subtract money with different currencies!");

            if (Amount < other.Amount)
                throw new InvalidOperationException("Resulting amount cannot be negative!");

            return new Money(Amount - other.Amount, Currency);
        }

        public bool IsZero() => Amount == 0m;

        public Money ConvertTo(CurrencyCode currency, decimal exchangeRate)
        {
            if (exchangeRate <= 0)
                throw new ArgumentException("Exchange rate must be greater than zero!", nameof(exchangeRate));

            decimal newAmount = Math.Round(Amount * exchangeRate, 2, MidpointRounding.ToEven);
            return new Money(newAmount, currency);
        }

        public override string ToString() => $"{Amount} {Currency}";

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Amount,
                Currency
            );
        }

        public override bool Equals(object? obj) => Equals(obj as Money);

        public bool Equals(Money? other)
        {
            if (other is not null)
            {
                return Amount == other.Amount && Currency == other.Currency;
            }

            return false;
        }

        public static bool operator ==(Money left, Money right) => Equals(left, right);
        public static bool operator !=(Money left, Money right) => !Equals(left, right);
    }
}
