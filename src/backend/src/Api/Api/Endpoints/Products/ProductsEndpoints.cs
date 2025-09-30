using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Interfaces;
using Api.Common;

namespace Api.Endpoints.Products;

public static class ProductsEndpoints
{
    public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products").WithTags("Products");

        group.MapGet("/", GetProducts)
            .WithName("GetProducts")
            .Produces<Result<PagedResponse<ProductDto>>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", GetById)
            .WithName("GetProductById")
            .Produces<Result<ProductDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", Create)
            .WithName("CreateProduct")
            .Produces<Result<ProductDto>>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        return app;
    }

    private static async Task<IResult> GetProducts([FromServices] IPagedRepository<Product> pagedRepository, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken ct)
    {
        var result = await pagedRepository.GetPagedAsync(page <= 0 ? 1 : page, pageSize <= 0 ? 10 : pageSize, ct);
        var response = new PagedResponse<ProductDto>
        {
            Items = result.Items.Select(MapToDto).ToList(),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };
        return Results.Ok(Result<PagedResponse<ProductDto>>.Success(response));
    }

    private static async Task<IResult> GetById([FromRoute] string id, [FromServices] IProductRepository repository, CancellationToken ct)
    {
        var item = await repository.GetByIdAsync(id, ct);
        return item is null
            ? Results.NotFound(Result<ProductDto>.Failure("Not Found"))
            : Results.Ok(Result<ProductDto>.Success(MapToDto(item)));
    }

    private static async Task<IResult> Create([FromBody] CreateProductRequest body, [FromServices] IProductRepository repository, LinkGenerator links, HttpContext ctx, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(body.Name) || body.Price <= 0)
        {
            var errors = new Dictionary<string, string[]>
            {
                ["name"] = string.IsNullOrWhiteSpace(body.Name) ? new[] { "Name is required" } : Array.Empty<string>(),
                ["price"] = body.Price <= 0 ? new[] { "Price must be positive" } : Array.Empty<string>()
            };
            return Results.BadRequest(Result<ProductDto>.Failure("Validation Failed", errors));
        }

        var entity = Product.Create(body.Name, body.Price);
        await repository.AddAsync(entity, ct);

        var url = links.GetUriByName(ctx, "GetProductById", new { id = entity.Id });
        return Results.Created(url!, Result<ProductDto>.Success(MapToDto(entity)));
    }

    private static ProductDto MapToDto(Product product) => new(product.Id, product.Name, product.Price);
}


