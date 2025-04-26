using Domain.Common.Interfaces;

namespace Domain.Common.Abstractions;

public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }

    public void SoftDelete(string deletedBy)
    {
        IsDeleted = true;
        DeletedBy = deletedBy;
        DeletedAt = DateTime.UtcNow;
    }

    public void Restore(string modifiedBy)
    {
        IsDeleted = false;
        DeletedBy = null;
        DeletedAt = null;
        ModifiedBy = modifiedBy;
        ModifiedAt = DateTime.UtcNow;
    }
}
