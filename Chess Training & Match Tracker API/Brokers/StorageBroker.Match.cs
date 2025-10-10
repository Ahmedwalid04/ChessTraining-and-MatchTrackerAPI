using ChessTrainingApi.Models;
using Dapper;
namespace ChessTrainingApi.Brokers;
public partial class StorageBroker 
{
    public async ValueTask InsertMatchAsync(Match match)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"INSERT INTO Match (Id, player1Id, Player2Id, PGN, PlayedAt)
              VALUES (@Id, @Player1Id, @Player2Id, @PGN, @PlayedAt);",match);
    }
    public async ValueTask<IEnumerable<Match>> SelectAllMatchesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<Match>(@"SELECT * FROM Match;");
    }
    public async ValueTask<Match> SelectMatchByIdAsync(int matchId)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Match>(
            @"SELECT * FROM Match WHERE Id = @matchId;", new { matchId });
    }
    public async ValueTask UpdateMatchAsync(Match match)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE Match 
              SET player1Id = @Player1Id,
                  Player2Id = @Player2Id,
                  PGN = @PGN,
                  PlayedAt = @PlayedAt
              WHERE Id = @Id;", match);
    }
    public async ValueTask DeleteMatchByIdAsync(int matchId)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"DELETE FROM Match WHERE Id = @matchId;", new { matchId });
    }
}