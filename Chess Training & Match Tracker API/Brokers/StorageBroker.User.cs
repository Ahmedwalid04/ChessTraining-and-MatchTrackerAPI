using ChessTrainingApi.Models;
using Dapper;
namespace ChessTrainingApi.Brokers;
public partial class StorageBroker
{
    public async ValueTask InsertUserAsync(User user)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"INSERT INTO User (Id, Username, Password, Rating)
              VALUES (@Id, @Username, @Password, @Rating);", user);
    }
    public async ValueTask<IEnumerable<User>> SelectAllUsersAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<User>(@"SELECT * FROM User;");
    }
    public async ValueTask<User> SelectUserByIdAsync(int userId)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(
            @"SELECT * FROM User WHERE Id = @userId;", new { userId });
    }
    public async ValueTask UpdateUserAsync(User user)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE User 
              SET Username = @Username,
                  Password = @Password,
                  Rating = @Rating
              WHERE Id = @Id;", user);
    }
    public async ValueTask DeleteUserByIdAsync(int userId)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"DELETE FROM User WHERE Id = @userId;", new { userId });
    }
}