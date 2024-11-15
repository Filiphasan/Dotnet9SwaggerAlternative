using Carter;

namespace Api.Endpoints;

public class SampleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/samples")
            .WithTags("Samples");

        group.MapGet("/", () => "Hello World!");
    }
}