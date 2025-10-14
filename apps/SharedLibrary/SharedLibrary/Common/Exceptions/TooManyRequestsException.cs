namespace SharedLibrary.Common.Exceptions
{
    public sealed class TooManyRequestsException(string message) : Exception(message);
}
