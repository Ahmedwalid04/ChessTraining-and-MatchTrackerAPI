namespace ChessTrainingApi.Controllers;
using ChessTrainingApi.Models;
using Microsoft.AspNetCore.Authorization;

public partial class ControllersExtentions
{
    public static WebApplication MapAuthController(this WebApplication app)
    {
        var groupName = "Authentication";

        app.MapPost("/auth/register", RegisterAsync)
            .WithTags(groupName)
            .WithSummary(nameof(RegisterAsync))
            .WithDescription("Register a new user.")
            .Produces<User>(201)
            .ProducesProblem(400);

        app.MapPost("/auth/login", LoginAsync)
            .WithTags(groupName)
            .WithSummary(nameof(LoginAsync))
            .WithDescription("Login and get JWT token.")
            .Produces<AuthResponse>(200)
            .ProducesProblem(400);
        return app;
    }
}
