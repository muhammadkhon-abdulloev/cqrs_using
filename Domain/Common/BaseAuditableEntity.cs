using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class BaseAuditableEntity: BaseEntity
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}