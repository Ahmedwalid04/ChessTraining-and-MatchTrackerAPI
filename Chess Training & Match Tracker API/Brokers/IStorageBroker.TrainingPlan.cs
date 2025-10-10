using ChessTrainingApi.Models;
namespace ChessTrainingApi.Brokers;
public partial interface IStorageBroker
{
    ValueTask InsertTrainingPlanAsync(TrainingPlan trainingPlan);
    ValueTask<IEnumerable<TrainingPlan>> SelectAllTrainingPlansAsync();
    ValueTask<TrainingPlan> SelectTrainingPlanByIdAsync(int trainingPlanId);
    ValueTask UpdateTrainingPlanAsync(TrainingPlan trainingPlan);
    ValueTask DeleteTrainingPlanByIdAsync(int trainingPlanId);
}