using ChessTrainingApi.Brokers;
using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public class UserServices (IStorageBroker storageBroker) : IUserServices
{
    public async ValueTask AddUserAsync(User user) =>
        await storageBroker.InsertUserAsync(user);
    public async ValueTask<IEnumerable<User>> RetrieveAllUsersAsync() =>
        await storageBroker.SelectAllUsersAsync();
    public async ValueTask<User> RetrieveUserByIdAsync(int userId) =>
        await storageBroker.SelectUserByIdAsync(userId);
    public async ValueTask ModifyUserAsync(User user) =>
        await storageBroker.UpdateUserAsync(user);
    public async ValueTask RemoveUserByIdAsync(int userId) =>
        await storageBroker.DeleteUserByIdAsync(userId);
}