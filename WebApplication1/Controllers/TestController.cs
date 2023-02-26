using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IEventDispatcher _dispatcher;

    public TestController(ILogger<TestController> logger, IEventDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route("testPostAsync")]
    public Task<string> PostAsync(string value)
    {
        _dispatcher.Dispatch(new PersonCreatedEvent() { Id = "P1", Name = "Esteban" });
        _dispatcher.Dispatch(new PersonCreatedEvent() { Id = "P2", Name = "Mike" });
        _dispatcher.Dispatch(new AssetAddedEvent() { Id = "A1", Description = "Mi asset 1" });

        return Task.FromResult("ok");
    }
}
