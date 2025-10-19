namespace SharedLibrary.Contracts.Common
{
    public class ErrorResponse
    {
        public string Message { get; init; } = null!;
        public string? StatusCode { get; init; }
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;
        public IEnumerable<string>? Errors { get; init; }
    }
}
