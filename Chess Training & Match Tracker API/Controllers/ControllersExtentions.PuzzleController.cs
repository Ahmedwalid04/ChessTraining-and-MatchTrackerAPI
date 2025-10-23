using ChessTrainingApi.Models;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    public static WebApplication MapPuzzleController(this WebApplication app)
    {
        var groupName = "Puzzles";
        app.MapPost("/puzzles", PostPuzzleAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PostPuzzleAsync))
            .WithDescription("Create a new puzzle.")
            .Produces<Puzzle>(200).Produces(204).ProducesProblem(400);
        app.MapPut("/puzzles/{puzzleId:int}", PutPuzzleAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PutPuzzleAsync))
            .WithDescription("Update an existing puzzle by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        app.MapGet("/puzzles", GetAllPuzzlesAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAllPuzzlesAsync))
            .WithDescription("Retrieve all puzzles.")
            .Produces<List<Puzzle>>(200).ProducesProblem(400);
        app.MapGet("/puzzles/{puzzleId:int}", GetPuzzleByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetPuzzleByIdAsync))
            .WithDescription("Retrieve a puzzle by ID.")
            .Produces<Puzzle>(200).ProducesProblem(400).ProducesProblem(404);
        app.MapGet("/puzzles/random", GetRandomPuzzleAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetRandomPuzzleAsync))
            .WithDescription("Retrieve a random puzzle.")
            .Produces<Puzzle>(200).ProducesProblem(400);
        app.MapDelete("/puzzles/{puzzleId:int}", DeletePuzzleByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(DeletePuzzleByIdAsync))
            .WithDescription("Delete a puzzle by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        app.MapPost("/puzzles/{puzzleId:int}/submit", SubmitPuzzleSolution)
            .WithTags(groupName)
            .WithSummary(nameof(SubmitPuzzleSolution))
            .WithDescription("Submit a solution for a puzzle.")
            .Produces<SolutionResponse>(200).ProducesProblem(400).ProducesProblem(404);
        return app;
    }
}