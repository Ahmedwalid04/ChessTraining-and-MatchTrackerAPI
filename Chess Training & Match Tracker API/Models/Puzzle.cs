namespace ChessTrainingApi.Models;
public record Puzzle : BaseEntity
{
    public string FEN { get; set; }
    public string Theme { get; set; }
    public string Solution { get; set; }
}