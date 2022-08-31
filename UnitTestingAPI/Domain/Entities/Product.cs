namespace UnitTestingAPI.Domain.Entities;

public partial class Product
{
    public Product(string name, string description, decimal price, bool isActive)
    {
        Name = name;
        Description = description;
        Price = price;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}