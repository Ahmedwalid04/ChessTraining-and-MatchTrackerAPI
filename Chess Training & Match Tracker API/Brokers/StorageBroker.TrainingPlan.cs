using ChessTrainingApi.Models;
using Dapper;
namespace ChessTrainingApi.Brokers;
public partial class StorageBroker
{
    public async ValueTask InsertTrainingPlanAsync(TrainingPlan trainingPlan)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"INSERT INTO TrainingPlan (Id, UserId, FocusArea, CreatedAt)
              VALUES (@Id, @UserId, @FocusArea, @CreatedAt);", trainingPlan);
    }
    public async ValueTask<IEnumerable<TrainingPlan>> SelectAllTrainingPlansAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TrainingPlan>(@"SELECT * FROM TrainingPlan;");
    }
    public async ValueTask<TrainingPlan> SelectTrainingPlanByIdAsync(int trainingPlanId)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<TrainingPlan>(
            @"SELECT * FROM TrainingPlan WHERE Id = @trainingPlanId;", new { trainingPlanId });
    }
    public async ValueTask UpdateTrainingPlanAsync(TrainingPlan trainingPlan)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"UPDATE TrainingPlan 
              SET UserId = @UserId,
                  FocusArea = @FocusArea,
                  CreatedAt = @CreatedAt
              WHERE Id = @Id;", trainingPlan);
    }
    public async ValueTask DeleteTrainingPlanByIdAsync(int trainingPlanId)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(
            @"DELETE FROM TrainingPlan WHERE Id = @trainingPlanId;", new { trainingPlanId });
    }

}