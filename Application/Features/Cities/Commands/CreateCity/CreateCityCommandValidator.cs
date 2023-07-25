using Application.Common.Interfaces;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreateCityCommandValidator: AbstractValidator<CreateCityCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCityCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsUnique!)
            .WithMessage("'{PropertyName}' already exists")
            .WithErrorCode("Not unique");
    }

    private async Task<bool> IsUnique(string cityName, CancellationToken cancellationToken)
    {
        return await _context.Cities.FirstOrDefaultAsync(
            c => c.Name == cityName, 
            cancellationToken: cancellationToken) == null;
    }
}