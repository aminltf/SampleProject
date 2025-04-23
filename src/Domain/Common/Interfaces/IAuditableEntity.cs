namespace Domain.Common.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    string CreatedBy { get; set; }
    DateTime ModifiedAt { get; set; }
    string ModifiedBy { get; set; }
    bool IsDeleted { get; set; }
    DateTime DeletedAt { get; set; }
    string DeletedBy { get; set; }
}
