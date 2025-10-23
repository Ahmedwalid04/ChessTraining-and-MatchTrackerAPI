namespace ChessTrainingApi.Models;
public record Puzzle : BaseEntity
{
    public string? FEN { get; set; }
    public string? Themes { get; set; }
    public int Rating { get; set; }
    public string? Solution { get; set; }
}