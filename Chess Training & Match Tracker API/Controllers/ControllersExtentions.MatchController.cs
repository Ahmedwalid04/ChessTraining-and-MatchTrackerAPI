using ChessTrainingApi.Models;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    public static WebApplication MapMatchController(this WebApplication app)
    {
        var groupName = "Matches";
        app.MapPost("/matches", PostMatchAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PostMatchAsync))
            .WithDescription("Create a new match.")
            .Produces<Match>(200).Produces(204).ProducesProblem(400);
        app.MapPut("/matches/{matchId:int}", PutMatchAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PutMatchAsync))
            .WithDescription("Update an existing match by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        app.MapGet("/matches", GetAllMatchesAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAllMatchesAsync))
            .WithDescription("Retrieve all matches.")
            .Produces<List<Match>>(200).ProducesProblem(400);
        app.MapGet("/matches/{matchId:int}", GetMatchByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetMatchByIdAsync))
            .WithDescription("Retrieve a match by ID.")
            .Produces<Match>(200).ProducesProblem(400).ProducesProblem(404);
        app.MapDelete("/matches/{matchId:int}", DeleteMatchByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(DeleteMatchByIdAsync))
            .WithDescription("Delete a match by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        return app;
    }
}