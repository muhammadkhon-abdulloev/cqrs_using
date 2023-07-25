using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;

namespace Application.City.Queries.GetCitiesWithPagination;

public abstract class GetCityByIdQuery: IRequest<CityDto>
{
    public int CityId { get; init; }
}

public class GetCityByIdQueryHandler: IRequestHandler<GetCityByIdQuery, CityDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cities
            .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
            .FirstAsync(c => request.CityId == c.Id,cancellationToken);
    }
}