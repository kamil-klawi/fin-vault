namespace SharedLibrary.Contracts.User
{
    public class CurrentUser
    {
        public Guid Id { get; init; }
        public string PhoneNumber { get; init; } = default!;
        public string Email { get; init; } = default!;
        public List<string> Roles { get; init; } = [];
        public List<string> Permissions { get; init; } = [];
    }
}
