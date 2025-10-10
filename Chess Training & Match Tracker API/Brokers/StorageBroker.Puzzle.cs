using ChessTrainingApi.Models;
using Dapper;
namespace ChessTrainingApi.Brokers;
public partial class StorageBroker
{
    public async ValueTask InsertPuzzleAsync(Puzzle puzzle)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"INSERT INTO Puzzle (Id, FEN, Solution, Theme)
              VALUES (@Id, @FEN, @Solution, @Theme);", puzzle);
    }
    public async ValueTask<IEnumerable<Puzzle>> SelectAllPuzzlesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<Puzzle>(@"SELECT * FROM Puzzle;");
    }
    public async ValueTask<Puzzle> SelectPuzzleByIdAsync(int puzzleId)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Puzzle>(
            @"SELECT * FROM Puzzle WHERE Id = @puzzleId;", new { puzzleId });
    }
    public async ValueTask UpdatePuzzleAsync(Puzzle puzzle)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE Puzzle 
              SET FEN = @FEN,
                  Solution = @Solution,
                  Theme = @Theme
              WHERE Id = @Id;", puzzle);
    }
    public async ValueTask DeletePuzzleByIdAsync(int puzzleId)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"DELETE FROM Puzzle WHERE Id = @puzzleId;", new { puzzleId });
    }
}