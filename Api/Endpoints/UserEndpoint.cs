using Api.Providers;
using Carter;

namespace Api.Endpoints;

public class UserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users");
        
        group.MapGet("/", GetUsers)
            .Produces<List<User>>(200);
        group.MapGet("/{id:int}", GetUser)
            .Produces<User>(200);
        group.MapPost("/", AddUser)
            .Produces<User>(200);
        group.MapDelete("/{id:int}", RemoveUser);
        group.MapPut("/{id:int}", UpdateUser)
            .Produces<User>(200);
    }
    
    private static IResult GetUsers(UserDataProvider provider) => Results.Ok(provider.GetUsers());
    
    private static IResult GetUser(UserDataProvider provider, int id) => Results.Ok(provider.GetUser(id));
    
    private static IResult AddUser(UserDataProvider provider, UserDto user) => Results.Ok(provider.AddUser(user));

    private static IResult RemoveUser(UserDataProvider provider, int id)
    {
        provider.RemoveUser(id);
        return Results.Ok();
    }
    
    private static IResult UpdateUser(UserDataProvider provider, UserDto user, int id) => Results.Ok(provider.UpdateUser(user, id));
}