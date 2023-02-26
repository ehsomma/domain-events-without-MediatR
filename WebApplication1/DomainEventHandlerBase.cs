using System.Threading;

namespace WebApplication1;

public abstract class DomainEventHandlerBase<TEvent> : IDomainEventHandler<TEvent> where TEvent : class, IDomainEvent
{
    public Task Handle(IDomainEvent @event, CancellationToken cancellationToken = default)
    {
        return Handle(@event as TEvent, cancellationToken);
    }

    public abstract Task Handle(TEvent @event, CancellationToken cancellationToken = default);
}