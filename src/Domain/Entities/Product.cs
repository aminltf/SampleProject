#nullable disable

using Domain.Common.Abstractions;

namespace Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Product()
    {
        
    }

    public Product(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
}
