#nullable disable

using Domain.Common.Abstractions;

namespace Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }

    public Category()
    {
        
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
