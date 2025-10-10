using ChessTrainingApi.Brokers;
using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public class TrainingPlanServices (IStorageBroker storageBroker) : ITrainingPlanServices
{
    public async ValueTask AddTrainingPlanAsync(TrainingPlan trainingPlan) =>
        await storageBroker.InsertTrainingPlanAsync(trainingPlan);
    public async ValueTask<IEnumerable<TrainingPlan>> RetrieveAllTrainingPlansAsync() =>
        await storageBroker.SelectAllTrainingPlansAsync();
    public async ValueTask<TrainingPlan> RetrieveTrainingPlanByIdAsync(int trainingPlanId) =>
        await storageBroker.SelectTrainingPlanByIdAsync(trainingPlanId);
    public async ValueTask ModifyTrainingPlanAsync(TrainingPlan trainingPlan) =>
        await storageBroker.UpdateTrainingPlanAsync(trainingPlan);
    public async ValueTask RemoveTrainingPlanByIdAsync(int trainingPlanId) =>
        await storageBroker.DeleteTrainingPlanByIdAsync(trainingPlanId);
}