using Application.Common.Interfaces;

namespace Application.Features.Cities.Commands.CreateCity;

public record CreateCityCommand : IRequest<int>
{
    public string? Name { get; set; }
}

public class CreateCity: IRequestHandler<CreateCityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCity(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.City
        {
            Name = request.Name
        };

        await _context.Cities.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}