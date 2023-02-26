namespace WebApplication1;

public class PersonCreatedEventHandler : DomainEventHandlerBase<PersonCreatedEvent>
{
    private readonly ILogger<PersonCreatedEventHandler> logger;

    public PersonCreatedEventHandler(ILogger<PersonCreatedEventHandler> logger)
    {
        this.logger = logger;
    }

    public override Task Handle(PersonCreatedEvent concreteEvent, CancellationToken cancellationToken = default)
    {
        //handler code here...

        this.logger.LogInformation(concreteEvent.Name);

        return Task.CompletedTask;
    }
}