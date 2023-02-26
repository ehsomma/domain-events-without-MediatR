using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // If you want to load one by one.
        //builder.Services.AddScoped<IDomainEventHandler<PersonCreatedEvent>, PersonCreatedEventHandler>();
        //builder.Services.AddScoped<IDomainEventHandler<AssetAddedEvent>, AssetAddedEventHandler>();

        // If you want to load all handlers that implements IDomainEventHandler.
        // NOTE: It requires the Scrutor nuget package to use the Scan extension method.
        builder.Services.Scan(selector =>
        {
            selector.FromAssembliesOf(typeof(PersonCreatedEventHandler))
                .AddClasses(filter =>
                {
                    filter.AssignableTo(typeof(IDomainEventHandler<>));
                })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });


        builder.Services.TryAddSingleton<IEventDispatcher, DomainEventDispatcher>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
