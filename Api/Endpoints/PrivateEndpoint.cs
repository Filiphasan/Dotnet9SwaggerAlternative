using Carter;

namespace Api.Endpoints;

public class PrivateEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/privates")
            .WithTags("Privates")
            .RequireAuthorization();
        
        group.MapGet("/", () => "This is a private endpoint!");
    }
}