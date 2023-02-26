namespace WebApplication1;

public interface IDomainEventHandler
{
    Task Handle(IDomainEvent @event, CancellationToken cancellationToken = default);
}

public interface IDomainEventHandler<in TEvent> : IDomainEventHandler where TEvent : IDomainEvent
{
    Task Handle(TEvent @event, CancellationToken cancellationToken = default);
}