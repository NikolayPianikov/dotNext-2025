using MinimalWebAPI;

using var composition = new Composition();
var builder = WebApplication.CreateBuilder(args);

// Uses Composition as an alternative IServiceProviderFactory
builder.Host.UseServiceProviderFactory(composition);

var app = builder.Build();

internal partial class Program()
{
    private void Run(WebApplication app)
    {
        app.MapGet("/", () => {
            return new ClockResult("Title", "Date", "Time");
        });

        app.Run();
    }
}