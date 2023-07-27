using Application.Common.Interfaces;

namespace Application.Features.Cities.Commands.UpdateCity;

public class UpdateCityCommandValidator: AbstractValidator<UpdateCityCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCityCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(c => c.Id)
            .MustAsync(IsExists)
            .WithMessage("City with provided id was not found")
            .WithErrorCode("Invalid id");
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsUnique)
            .WithMessage("'{PropertyName}' already exists")
            .WithErrorCode("Not unique");
    }

    private async Task<bool> IsExists(int id, CancellationToken cancellationToken)
    {
        return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken) != null;
    }
    
    private async Task<bool> IsUnique(string cityName, CancellationToken cancellationToken)
    {
        return await _context.Cities.FirstOrDefaultAsync(
            c => c.Name == cityName, 
            cancellationToken: cancellationToken) == null;
    }
}