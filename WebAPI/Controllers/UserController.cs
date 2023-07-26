using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/user")]
[ApiVersion("1.0")]
public class UserController: ControllerBase
{
    public UserController() {}
    
    [HttpPost("login")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<int> GetCitiesByPagination(ISender sender)
    {
        return await sender.Send(query);
    }
    
    [HttpPost("register")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<int> CreateCity(ISender sender)
    {
        
        return await sender.Send(query);
    }
}