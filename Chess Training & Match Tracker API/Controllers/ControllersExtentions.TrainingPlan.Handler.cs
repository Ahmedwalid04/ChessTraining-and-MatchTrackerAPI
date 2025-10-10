using ChessTrainingApi.Models;
using ChessTrainingApi.Services;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    static async ValueTask<IResult> PostTrainingPlanAsync(ITrainingPlanServices trainingPlanService, TrainingPlan trainingPlan)
    {
        if (trainingPlan == null)
        {
            return Results.BadRequest();
        }
        await trainingPlanService.AddTrainingPlanAsync(trainingPlan);
        return Results.Created($"/trainingplans/{trainingPlan.Id}", trainingPlan);
    }
    static async ValueTask<IResult> PutTrainingPlanAsync(ITrainingPlanServices trainingPlanService, int trainingPlanId, TrainingPlan trainingPlan)
    {
        if (trainingPlan == null || trainingPlan.Id != trainingPlanId)
        {
            return Results.BadRequest();
        }
        var existingTrainingPlan = await trainingPlanService.RetrieveTrainingPlanByIdAsync(trainingPlanId);
        if (existingTrainingPlan is null)
        {
            return Results.NotFound();
        }
        await trainingPlanService.ModifyTrainingPlanAsync(trainingPlan);
        return Results.NoContent();
    }
    static async ValueTask<IResult> GetAllTrainingPlansAsync(ITrainingPlanServices trainingPlanService)
    {
        var trainingPlans = await trainingPlanService.RetrieveAllTrainingPlansAsync();
        return Results.Ok(trainingPlans);
    }
    static async ValueTask<IResult> GetTrainingPlanByIdAsync(ITrainingPlanServices trainingPlanService, int trainingPlanId)
    {
        var trainingPlan = await trainingPlanService.RetrieveTrainingPlanByIdAsync(trainingPlanId);
        return trainingPlan is not null ? Results.Ok(trainingPlan) : Results.NotFound();
    }
    static async ValueTask<IResult> DeleteTrainingPlanByIdAsync(ITrainingPlanServices trainingPlanService, int trainingPlanId)
    {
        var trainingPlan = await trainingPlanService.RetrieveTrainingPlanByIdAsync(trainingPlanId);
        if (trainingPlan is null)
        {
            return Results.NotFound();
        }
        await trainingPlanService.RemoveTrainingPlanByIdAsync(trainingPlanId);
        return Results.NoContent();
    }
}
