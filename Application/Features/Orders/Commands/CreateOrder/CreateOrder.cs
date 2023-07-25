using Application.Common.Interfaces;
using Domain.Events;

namespace Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand: IRequest<int>
{
    public int SenderCityId { get; set; } = new();
    public string? SenderAddress { get; set; }
    public int ReceiverCityId { get; set; } = new();
    public string? ReceiverAddress { get; set; }
    public double CargoWeight { get; set; }
    public DateOnly PickupDate { get; set; }
}

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.PickupDate.Equals(null))
        {
            request.PickupDate = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(3);
        }
        
        var entity = new Domain.Entities.Order
        {
            SenderCityId = request.SenderCityId,
            // SenderCity = _mapper.Map<Domain.Entities.City>(request.SenderCity),
            SenderAddress = request.SenderAddress,
            ReceiverCityId =request.ReceiverCityId, 
            // ReceiverCity = _mapper.Map<Domain.Entities.City>(request.ReceiverCity),
            ReceiverAddress = request.ReceiverAddress,
            CargoWeight = request.CargoWeight,
            PickupDate = request.PickupDate,
            CreatedAt = DateTime.UtcNow
        };

        entity.AddDomainEvent(new OrderCreatedEvent(entity));
        
        await _context.Orders.AddAsync(entity, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}