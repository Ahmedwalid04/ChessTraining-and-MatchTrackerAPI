using ChessTrainingApi.Models;
using ChessTrainingApi.Services;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
   public static async ValueTask<IResult> PostPuzzleAsync(IPuzzleServices puzzleService, Puzzle puzzle)
    {
        if (puzzle == null)
        {
            return Results.BadRequest();
        }
        await puzzleService.AddPuzzleAsync(puzzle);
        return Results.Created($"/puzzles/{puzzle.Id}", puzzle);
    }
    public static async ValueTask<IResult> PutPuzzleAsync(IPuzzleServices puzzleService, int puzzleId, Puzzle puzzle)
    {
        if (puzzle == null || puzzle.Id != puzzleId)
        {
            return Results.BadRequest();
        }
        var existingPuzzle = await puzzleService.RetrievePuzzleByIdAsync(puzzleId);
        if (existingPuzzle is null)
        {
            return Results.NotFound();
        }
        await puzzleService.ModifyPuzzleAsync(puzzle);
        return Results.NoContent();
    }
   public static async ValueTask<IResult> GetAllPuzzlesAsync(IPuzzleServices puzzleService)
    {
        var puzzles = await puzzleService.RetrieveAllPuzzlesAsync();
        return Results.Ok(puzzles);
    }
   public static async ValueTask<IResult> GetPuzzleByIdAsync(IPuzzleServices puzzleService, int puzzleId)
    {
        var puzzle = await puzzleService.RetrievePuzzleByIdAsync(puzzleId);
        return puzzle is not null ? Results.Ok(puzzle) : Results.NotFound();
    }
    public static async ValueTask<IResult> GetRandomPuzzleAsync(IPuzzleServices puzzleService)
    {
        var puzzles = await puzzleService.RetrieveRandomPuzzleAsync();
        return Results.Ok(puzzles);
    }
    public static async ValueTask<IResult> DeletePuzzleByIdAsync(IPuzzleServices puzzleService, int puzzleId)
    {
        var puzzle = await puzzleService.RetrievePuzzleByIdAsync(puzzleId);
        if (puzzle is null)
        {
            return Results.NotFound();
        }
        await puzzleService.RemovePuzzleByIdAsync(puzzleId);
        return Results.NoContent();
    }
    public static async ValueTask<IResult> SubmitPuzzleSolution(IPuzzleServices puzzleService,int puzzleId,SolutionRequest request)      
    {
        var puzzle = await puzzleService.RetrievePuzzleByIdAsync(puzzleId);
        if (puzzle is null)
        {
            return Results.NotFound();
        }
        var solution = request.Solution;
        if (string.IsNullOrEmpty(solution))
        {
            return Results.BadRequest("Solution cannot be empty.");
        }
        if (puzzle.Solution == solution)
        {
            return Results.Ok("Correct Solution");
        }
        return Results.BadRequest("Incorrect Solution."); 
    }
}