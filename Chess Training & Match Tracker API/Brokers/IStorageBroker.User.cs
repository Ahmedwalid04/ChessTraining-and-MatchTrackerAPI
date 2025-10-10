using ChessTrainingApi.Models;
namespace ChessTrainingApi.Brokers;
public partial interface IStorageBroker
{
    ValueTask InsertUserAsync(User user);
    ValueTask<IEnumerable<User>> SelectAllUsersAsync();
    ValueTask<User> SelectUserByIdAsync(int userId);
    ValueTask UpdateUserAsync(User user);
    ValueTask DeleteUserByIdAsync(int userId);
}