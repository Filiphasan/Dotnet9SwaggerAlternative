using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models;
using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Endpoints;

public class AuthEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auths")
            .WithTags("Auth");

        group.MapPost("/login", Login)
            .Produces<string>();
    }

    private static IResult Login(LoginDto loginDto, JwtSettingModel jwtSettings)
    {
        // Create Token
        if (loginDto.Username != "test" || loginDto.Password != "test")
        {
            return Results.BadRequest("Invalid Username or Password");
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claimList = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, loginDto.Username?? ""),
        };
        var jwtToken = new JwtSecurityToken(claims: claimList, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return Results.Ok(token);
    }
}