using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public interface IUserServices
{
    ValueTask AddUserAsync(User user);
    ValueTask<IEnumerable<User>> RetrieveAllUsersAsync();
    ValueTask<User> RetrieveUserByIdAsync(int userId);
    ValueTask ModifyUserAsync(User user);
    ValueTask RemoveUserByIdAsync(int userId);
}