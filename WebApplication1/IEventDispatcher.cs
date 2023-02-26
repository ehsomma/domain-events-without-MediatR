namespace WebApplication1;

public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent @event, CancellationToken cancellationToken = default);
}