namespace WebApplication1;

public class AssetAddedEventHandler : DomainEventHandlerBase<AssetAddedEvent>
{
    private readonly ILogger<AssetAddedEventHandler> logger;

    public AssetAddedEventHandler(ILogger<AssetAddedEventHandler> logger)
    {
        this.logger = logger;
    }

    public override Task Handle(AssetAddedEvent concreteEvent, CancellationToken cancellationToken = default)
    {
        //handler code here...

        this.logger.LogInformation(concreteEvent.Description);
        
        return Task.CompletedTask;
    }
}