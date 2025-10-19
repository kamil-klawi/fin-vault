namespace SharedLibrary.Contracts.User
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }
}
