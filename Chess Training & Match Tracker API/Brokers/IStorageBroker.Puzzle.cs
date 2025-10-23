using ChessTrainingApi.Models;
namespace ChessTrainingApi.Brokers;
public partial interface IStorageBroker
{
    ValueTask InsertPuzzleAsync(Puzzle puzzle);
    ValueTask<IEnumerable<Puzzle>> SelectAllPuzzlesAsync();
    ValueTask<Puzzle> SelectPuzzleByIdAsync(int puzzleId);
    ValueTask <Puzzle> SelectRandomPuzzleAsync();
    ValueTask UpdatePuzzleAsync(Puzzle puzzle);
    ValueTask DeletePuzzleByIdAsync(int puzzleId);
}