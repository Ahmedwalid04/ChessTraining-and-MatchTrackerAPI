namespace ChessTrainingApi.Models;
public record Match : BaseEntity
{
    public int player1Id { get; set; }
    public int Player2Id { get; set; }
    public string PGN { get; set; }
    public string PlayedAt { get; set; }

}
