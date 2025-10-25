using IdentityService.Domain.Enums;
using SharedLibrary.Common.ValueObjects;

namespace IdentityService.Domain.ValueObjects
{
    public sealed class PersonalData : IEquatable<PersonalData>
    {
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;
        public Pesel Pesel { get; } = null!;
        public Gender Gender { get; }
        public DateOnly BirthDate { get; }
        public string PlaceOfBirth { get; } = null!;
        public string Nationality { get; } = null!;
        public PhoneNumber PhoneNumber { get; } = null!;
        public Address Address { get; } = null!;

        private PersonalData() {}

        public PersonalData(
            string firstName,
            string lastName,
            Pesel pesel,
            Gender gender,
            DateOnly birthDate,
            string placeOfBirth,
            string nationality,
            PhoneNumber phoneNumber,
            Address address)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or whitespace!", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Surname cannot be null or whitespace!", nameof(lastName));

            if (string.IsNullOrWhiteSpace(placeOfBirth))
                throw new ArgumentException("Place of birth cannot be null or whitespace!", nameof(placeOfBirth));

            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("Nationality cannot be null or whitespace!", nameof(nationality));

            if ((DateOnly.FromDateTime(DateTime.Today).Year - birthDate.Year) <= 18)
                throw new ArgumentException("Person must be at least 18 years old!", nameof(birthDate));

            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Gender = gender;
            BirthDate = birthDate;
            PlaceOfBirth = placeOfBirth;
            Nationality = nationality;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString() => $"{FirstName} {LastName}, {Gender}, {BirthDate.Year} {PlaceOfBirth}, {Nationality}";

        public override int GetHashCode()
        {
            return HashCode.Combine(
                FirstName.ToLowerInvariant(),
                LastName.ToLowerInvariant(),
                Gender,
                PlaceOfBirth.ToLowerInvariant(),
                Nationality.ToLowerInvariant()
            );
        }

        public override bool Equals(object? obj) => Equals(obj as PersonalData);

        public bool Equals(PersonalData? other)
        {
            if (other is not null)
            {
                return string.Equals(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(LastName, other.LastName, StringComparison.OrdinalIgnoreCase) &&
                       Enum.Equals(Gender, other.Gender) &&
                       string.Equals(PlaceOfBirth, other.PlaceOfBirth) &&
                       string.Equals(Nationality, other.Nationality);
            }

            return false;
        }

        public static bool operator ==(PersonalData left, PersonalData right) => Equals(left, right);
        public static bool operator !=(PersonalData left, PersonalData right) => !Equals(left, right);
    }
}
