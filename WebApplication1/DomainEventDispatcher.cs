namespace WebApplication1;

public class DomainEventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Dispatch(IDomainEvent @event, CancellationToken cancellationToken = default)
    {
        if (@event == null)
        {
            throw new ArgumentNullException(nameof(@event));
        }

        Type handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
        IEnumerable<object> handlers = _serviceProvider.GetServices(handlerType);

        foreach (object handler in handlers)
        {
            IDomainEventHandler baseHandler = handler as IDomainEventHandler;
            if (baseHandler != null)
            {
                await baseHandler.Handle(@event, cancellationToken);
            }
        }
    }
}