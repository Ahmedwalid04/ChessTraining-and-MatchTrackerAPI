using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public interface IMatchServices
{
    ValueTask AddMatchAsync(Match match);
    ValueTask<IEnumerable<Match>> RetrieveAllMatchesAsync();
    ValueTask<Match> RetrieveMatchByIdAsync(int matchId);
    ValueTask ModifyMatchAsync(Match match);
    ValueTask RemoveMatchByIdAsync(int matchId);
}