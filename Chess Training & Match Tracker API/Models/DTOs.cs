namespace ChessTrainingApi.Models;
public record AuthResponse( string Token, User User); 
public record LoginRequest(string Username, string Password);
public record SolutionRequest(string Solution);
public record SolutionResponse(bool IsCorrect);