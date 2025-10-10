namespace ChessTrainingApi.Models;
public record User : BaseEntity
{ 

    public string Username { get; set; }
    public string Password { get; set; }
    public int Rating { get; set; }

}