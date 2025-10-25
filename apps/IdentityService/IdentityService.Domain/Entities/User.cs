using IdentityService.Domain.ValueObjects;
using SharedLibrary.Common.ValueObjects;

namespace IdentityService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; }
        public Email Email { get; private set; } = null!;
        public PasswordHash PasswordHash { get; private set; } = null!;
        public PersonalData PersonalData { get; private set; } = null!;
        public DateTime UpdatedAt { get; private set; }
        public DateTime CreatedAt { get; }
        public string? PasswordResetToken { get; private set; }
        public DateTime? PasswordResetTokenExpires { get; private set; }

        private User() {}

        public User(Email email, PasswordHash passwordHash, PersonalData personalData, DateTime updatedAt, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            PersonalData = personalData;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }

        public void UpdatePersonalData(string firstName, string lastName, PhoneNumber phoneNumber)
        {
            PersonalData = new PersonalData(
                firstName,
                lastName,
                PersonalData.Pesel,
                PersonalData.Gender,
                PersonalData.BirthDate,
                PersonalData.PlaceOfBirth,
                PersonalData.Nationality,
                phoneNumber,
                PersonalData.Address
            );

            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or whitespace!");

            PasswordHash = new PasswordHash(password);
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(string password)
        {
            PasswordHash = new PasswordHash(password);
        }

        public void SetPasswordResetToken(string? token, DateTime? expires)
        {
            PasswordResetToken = token;
            PasswordResetTokenExpires = expires;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }
    }
}
