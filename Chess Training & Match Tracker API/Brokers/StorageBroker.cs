using Microsoft.Data.Sqlite;
namespace ChessTrainingApi.Brokers
{
    public partial class StorageBroker (IConfiguration configuration) : IStorageBroker
    {
        string? ConnectionString = configuration.GetConnectionString("DefaultConnection");
        SqliteConnection CreateConnection() =>new (ConnectionString);
    }
}