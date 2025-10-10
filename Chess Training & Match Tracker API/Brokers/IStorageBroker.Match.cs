using ChessTrainingApi.Models;

namespace ChessTrainingApi.Brokers; 
public partial interface IStorageBroker
{
    ValueTask InsertMatchAsync(Match match);
    ValueTask<IEnumerable<Match>> SelectAllMatchesAsync();
    ValueTask<Match> SelectMatchByIdAsync(int matchId);
    ValueTask UpdateMatchAsync(Match match);
    ValueTask DeleteMatchByIdAsync(int matchId);
}