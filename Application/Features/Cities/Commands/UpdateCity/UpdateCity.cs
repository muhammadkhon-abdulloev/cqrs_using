using Application.Common.Interfaces;

namespace Application.Features.Cities.Commands.UpdateCity;

public record UpdateCityCommand: IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class UpdateCity: IRequestHandler<UpdateCityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateCity(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (city == null)
        {
            return -1;
        }

        city.Name = request.Name;
        await _context.SaveChangesAsync(cancellationToken);
        
        return request.Id;
    }
}