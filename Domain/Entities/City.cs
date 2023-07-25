using Domain.Common;

namespace Domain.Entities;

[Table("city")]
public class City: BaseAuditableEntity
{
    public string? Name { get; set; }
    public List<Order> SenderOrders { get; set; } = new();
    public List<Order> ReceiverOrders { get; set; } = new();

}