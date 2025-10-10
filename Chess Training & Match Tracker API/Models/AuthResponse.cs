namespace ChessTrainingApi.Models;
public record AuthResponse
{
    public string Token { get; set; }
    public User User { get; set; }
}