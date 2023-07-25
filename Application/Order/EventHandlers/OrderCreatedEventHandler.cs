using Domain.Events;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

// using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Application.Order.EventHandlers;

public class OrderCreatedEventHandler: INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger _logger = Log.ForContext<OrderCreatedEventHandler>();

    public OrderCreatedEventHandler()
    { }
    
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.Information("Cargo Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}