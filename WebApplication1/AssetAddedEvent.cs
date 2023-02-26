namespace WebApplication1;

public class AssetAddedEvent : IDomainEvent
{
    public string Id { get; set; }

    public string Description { get; set; }
}
