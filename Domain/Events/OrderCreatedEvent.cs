using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class OrderCreatedEvent: BaseEvent
{
    public OrderCreatedEvent(Order order)
    {
        Order = order;
    }

    public Order Order { get; init; }
}