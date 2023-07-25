using Application.Common.Models;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/order")]
[ApiVersion("1.0")]
public class OrderController
{
    public OrderController()
    {}

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<PaginatedList<CityDto>>))]
    // [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DefaultResponseDto))]
    public async Task<PaginatedList<OrderDto>> GetOrdersByPagination(ISender sender, [AsParameters] GetOrdersWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task<int>))]
    public async Task<int> CreateOrder(ISender sender, CreateOrderCommand query)
    {
        return await sender.Send(query);
    }
}