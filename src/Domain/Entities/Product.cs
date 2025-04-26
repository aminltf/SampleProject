#nullable disable

using Domain.Common.Abstractions;

namespace Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Product()
    {
        
    }

    public Product(string name, decimal price, string description, Guid categoryId)
    {
        Name = name;
        Price = price;
        Description = description;
        CategoryId = categoryId;
    }
}
