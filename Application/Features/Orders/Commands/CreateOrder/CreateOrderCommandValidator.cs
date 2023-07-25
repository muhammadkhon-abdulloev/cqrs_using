using Application.Common.Interfaces;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(o => o.SenderCityId)
            .NotEmpty()
            .MustAsync(CityExists)
            .WithMessage("'{PropertyName}' doesn't exists")
            .WithErrorCode("InvalidCityId");
        RuleFor(o => o.SenderAddress)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be empty")
            .WithErrorCode("Empty");
        RuleFor(o => o.ReceiverCityId)
            .NotEmpty()
            .MustAsync(CityExists)
            .WithMessage("'{PropertyName}' doesn't exists")
            .WithErrorCode("Doesn't exists");
        RuleFor(o => o.ReceiverAddress)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be empty")
            .WithErrorCode("Empty");
        RuleFor(o => o.CargoWeight)
            .GreaterThan(0)
            .WithMessage("'{PropertyName}' can't be less than 0")
            .WithErrorCode("Invalid weight");
        RuleFor(o => o.PickupDate)
            .GreaterThan(DateOnly.MinValue)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("'{PropertyName}' can't be in past")
            .WithErrorCode("Back in future?");
    }

    private async Task<bool> CityExists(int cityId, CancellationToken cancellationToken)
    {
        return await _context.Cities.FirstOrDefaultAsync(
            o => o.Id == cityId, 
            cancellationToken: cancellationToken) != null;
    }
}