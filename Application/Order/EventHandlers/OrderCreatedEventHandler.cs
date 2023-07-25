using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.Order.EventHandlers;

public class OrderCreatedEventHandler: INotificationHandler<OrderCreatedEvent>
{
    // private readonly ILogger _logger;

    public OrderCreatedEventHandler()
    {
        // _logger = logger;
    }
    
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        // _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}