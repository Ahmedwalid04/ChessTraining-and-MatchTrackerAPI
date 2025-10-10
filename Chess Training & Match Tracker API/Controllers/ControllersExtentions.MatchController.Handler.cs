using ChessTrainingApi.Models;
using ChessTrainingApi.Services;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    static async ValueTask<IResult> PostMatchAsync(IMatchServices matchService, Match match)
    {
        if (match == null)
        {
            return Results.BadRequest();
        }
        await matchService.AddMatchAsync(match);
        return Results.Created($"/matches/{match.Id}", match);
    }
    static async ValueTask<IResult> PutMatchAsync(IMatchServices matchService, int matchId, Match match)
    {
        if (match == null || match.Id != matchId)
        {
            return Results.BadRequest();
        }
        var existingMatch = await matchService.RetrieveMatchByIdAsync(matchId);
        if (existingMatch is null)
        {
            return Results.NotFound();
        }
        await matchService.ModifyMatchAsync(match);
        return Results.NoContent();
    }
    static async ValueTask<IResult> GetAllMatchesAsync(IMatchServices matchService)
    {
        var matches = await matchService.RetrieveAllMatchesAsync();
        return Results.Ok(matches);
    }
    static async ValueTask<IResult> GetMatchByIdAsync(IMatchServices matchService, int matchId)
    {
        var match = await matchService.RetrieveMatchByIdAsync(matchId);
        return match is not null ? Results.Ok(match) : Results.NotFound();
    }
    static async ValueTask<IResult> DeleteMatchByIdAsync(IMatchServices matchService, int matchId)
    {
        var match = await matchService.RetrieveMatchByIdAsync(matchId);
        if (match is null)
        {
            return Results.NotFound();
        }
        await matchService.RemoveMatchByIdAsync(matchId);
        return Results.NoContent();
    }
}