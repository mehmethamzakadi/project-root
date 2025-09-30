namespace Api.Endpoints.Products;

public sealed record ProductDto(string Id, string Name, decimal Price);

public sealed record CreateProductRequest(string Name, decimal Price);

public sealed class PagedResponse<T>
{
    public required IReadOnlyList<T> Items { get; init; }
    public required int Page { get; init; }
    public required int PageSize { get; init; }
    public required long TotalCount { get; init; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}



