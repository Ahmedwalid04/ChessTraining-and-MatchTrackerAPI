using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public interface IPuzzleServices
{
    ValueTask AddPuzzleAsync(Puzzle puzzle);
    ValueTask<IEnumerable<Puzzle>> RetrieveAllPuzzlesAsync();
    ValueTask<Puzzle> RetrievePuzzleByIdAsync(int puzzleId);
    ValueTask<Puzzle> RetrieveRandomPuzzleAsync();
    ValueTask ModifyPuzzleAsync(Puzzle puzzle);
    ValueTask RemovePuzzleByIdAsync(int puzzleId);
}