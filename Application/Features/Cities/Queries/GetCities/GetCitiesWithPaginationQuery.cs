using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;

namespace Application.City.Queries.GetCities;

public class GetCitiesWithPaginationQuery: IRequest<PaginatedList<CityDto>>
{
    public int CityId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCitiesWithPaginationQueryHandler : IRequestHandler<GetCitiesWithPaginationQuery, PaginatedList<CityDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCitiesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CityDto>> Handle(GetCitiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cities
            .Where(c => c.Id == request.CityId || request.CityId == 0)
            .OrderBy(c => c.Name)
            .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}