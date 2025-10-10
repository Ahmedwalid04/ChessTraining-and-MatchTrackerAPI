using ChessTrainingApi.Brokers;
using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public class PuzzleServices (IStorageBroker storageBroker) : IPuzzleServices
{
    public async ValueTask AddPuzzleAsync(Puzzle puzzle) =>
        await storageBroker.InsertPuzzleAsync(puzzle);
    public async ValueTask<IEnumerable<Puzzle>> RetrieveAllPuzzlesAsync() =>
        await storageBroker.SelectAllPuzzlesAsync();
    public async ValueTask<Puzzle> RetrievePuzzleByIdAsync(int puzzleId) =>
        await storageBroker.SelectPuzzleByIdAsync(puzzleId);
    public async ValueTask ModifyPuzzleAsync(Puzzle puzzle) =>
        await storageBroker.UpdatePuzzleAsync(puzzle);
    public async ValueTask RemovePuzzleByIdAsync(int puzzleId) =>
        await storageBroker.DeletePuzzleByIdAsync(puzzleId);
}