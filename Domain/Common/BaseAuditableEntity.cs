namespace Domain.Common;

public class BaseAuditableEntity: BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}