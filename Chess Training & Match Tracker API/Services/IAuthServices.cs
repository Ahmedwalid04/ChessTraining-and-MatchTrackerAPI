using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public interface IAuthServices
{
    ValueTask<User> RegisterAsync(User user);
    ValueTask<AuthResponse> LoginAsync(string username, string password);
}