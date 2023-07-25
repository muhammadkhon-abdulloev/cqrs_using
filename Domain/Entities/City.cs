using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

[Table("city")]
public class City: BaseAuditableEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Order> SenderOrders { get; set; } = new();
    public List<Order> ReceiverOrders { get; set; } = new();

}