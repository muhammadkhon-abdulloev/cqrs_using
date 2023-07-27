namespace Api.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/user")]
[ApiVersion("1.0")]
public class UserController: ControllerBase
{
    // public UserController() {}
    
    [HttpPost("login")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async void GetCitiesByPagination(ISender sender)
    {
    }
    
    [HttpPost("register")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async void CreateCity(ISender sender)
    {
        
    }
}