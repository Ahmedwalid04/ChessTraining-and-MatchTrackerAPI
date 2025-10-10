using ChessTrainingApi.Brokers;
using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public class MatchServices(IStorageBroker storageBroker) : IMatchServices
{
    public async ValueTask AddMatchAsync(Match match) =>
        await storageBroker.InsertMatchAsync(match);
    public async ValueTask<IEnumerable<Match>> RetrieveAllMatchesAsync() =>
        await storageBroker.SelectAllMatchesAsync();
    public async ValueTask<Match> RetrieveMatchByIdAsync(int matchId) =>
        await storageBroker.SelectMatchByIdAsync(matchId);
    public async ValueTask ModifyMatchAsync(Match match) =>
        await storageBroker.UpdateMatchAsync(match);
    public async ValueTask RemoveMatchByIdAsync(int matchId) =>
        await storageBroker.DeleteMatchByIdAsync(matchId);
}