namespace WebApplication1;

public class PersonCreatedEvent : IDomainEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
}
