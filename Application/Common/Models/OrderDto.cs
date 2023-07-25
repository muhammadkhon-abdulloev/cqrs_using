namespace Application.Common.Models;
public class OrderDto
{
    public int Id { get; init; }
    public CityDto SenderCity { get; init; } = null!;
    public string? SenderAddress { get; init; }
    public CityDto ReceiverCity { get; init; } = null!;
    public string? ReceiverAddress { get; init; }
    public double CargoWeight { get; init; }
    public DateOnly PickupDate { get; init; }
    public DateTime CreatedAt { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Order, OrderDto>().ReverseMap();
        }
    }
}