using ChessTrainingApi.Models;
namespace ChessTrainingApi.Services;
public interface ITrainingPlanServices
{
    ValueTask AddTrainingPlanAsync(TrainingPlan trainingPlan);
    ValueTask<IEnumerable<TrainingPlan>> RetrieveAllTrainingPlansAsync();
    ValueTask<TrainingPlan> RetrieveTrainingPlanByIdAsync(int trainingPlanId);
    ValueTask ModifyTrainingPlanAsync(TrainingPlan trainingPlan);
    ValueTask RemoveTrainingPlanByIdAsync(int trainingPlanId);
}