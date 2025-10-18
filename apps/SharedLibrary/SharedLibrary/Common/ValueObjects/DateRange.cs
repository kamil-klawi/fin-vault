namespace SharedLibrary.Common.ValueObjects
{
    public sealed class DateRange : IEquatable<DateRange>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        private DateRange() {}

        public DateRange(DateTime start, DateTime end)
        {
            if (end < start)
                throw new ArgumentException("End date must be greater than or equal to start date!");

            Start = start;
            End = end;
        }

        public override string ToString() => $"{Start:yyyy-MM-dd} to {End:yyyy-MM-dd}";
        public override int GetHashCode() => HashCode.Combine(Start, End);
        public override bool Equals(object? obj) => Equals(obj as DateRange);

        public bool Equals(DateRange? other)
        {
            if (other is not null)
                return Start == other.Start && End == other.End;

            return false;
        }

        public static bool operator ==(DateRange? left, DateRange? right) => Equals(left, right);
        public static bool operator !=(DateRange? left, DateRange? right) => !Equals(left, right);
    }
}
