using ChessTrainingApi.Models;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    public static WebApplication MapUserController(this WebApplication app)
    {
        var groupName = "Users";

        app.MapPost("/users", PostUserAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PostUserAsync))
            .WithDescription("Create a new user.")
            .Produces<User>(200).Produces(204).ProducesProblem(400);
        app.MapPut("/users/{userId:int}", PutUserAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PutUserAsync))
            .WithDescription("Update an existing user by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        app.MapGet("/users", GetAllUsersAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAllUsersAsync))
            .WithDescription("Retrieve all users.")
            .Produces<List<User>>(200).ProducesProblem(400);
        app.MapGet("/users/{userId:int}", GetUserByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetUserByIdAsync))
            .WithDescription("Retrieve a user by ID.")
            .Produces<User>(200).ProducesProblem(400).ProducesProblem(404);
        app.MapDelete("/users/{userId:int}", DeleteUserByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(DeleteUserByIdAsync))
            .WithDescription("Delete a user by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        return app;
    }
}