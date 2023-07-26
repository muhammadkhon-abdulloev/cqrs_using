using Application.City.Queries.GetCities;
using Application.Common.Models;
using Application.Features.Cities.Commands.CreateCity;


namespace WebAPI.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/city")]
[ApiVersion("1.0")]
public class CityController: ControllerBase
{
    public CityController()
    {}

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<PaginatedList<CityDto>>))]
    public async Task<PaginatedList<CityDto>> GetCitiesByPagination(ISender sender, [AsParameters] GetCitiesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<int>))]
    public async Task<int> CreateCity(ISender sender, [AsParameters] CreateCityCommand query)
    {
        
        return await sender.Send(query);
    }
    
}