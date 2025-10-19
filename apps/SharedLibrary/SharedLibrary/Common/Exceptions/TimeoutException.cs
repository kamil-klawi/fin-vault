namespace SharedLibrary.Common.Exceptions
{
    public sealed class TimeoutException(string message) : Exception(message);
}
