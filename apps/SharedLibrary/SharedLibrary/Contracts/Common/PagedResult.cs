namespace SharedLibrary.Contracts.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; init; } = Enumerable.Empty<T>();
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int TotalCount { get; init; }
    }
}
