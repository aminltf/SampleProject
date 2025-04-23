#nullable disable

using Domain.Common.Interfaces;

namespace Domain.Common.Abstractions;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
}
