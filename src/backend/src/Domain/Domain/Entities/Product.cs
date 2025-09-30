namespace Domain.Entities;

public class Product
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Product() { }

    public static Product Create(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (price <= 0)
            throw new ArgumentException("Price must be positive", nameof(price));

        return new Product
        {
            Name = name,
            Price = price
        };
    }
}



