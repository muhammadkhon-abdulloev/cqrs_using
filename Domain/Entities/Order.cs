using Domain.Common;

namespace Domain.Entities;

[Table("order")]
public class Order: BaseAuditableEntity
{
    public int SenderCityId { get; set; }
    public City SenderCity { get; set; }
    public string? SenderAddress { get; set; }
    public int ReceiverCityId { get; set; }
    public City ReceiverCity { get; set; }
    public string? ReceiverAddress { get; set; }
    public double CargoWeight { get; set; }
    public DateOnly PickupDate { get; set; }
}