using ChessTrainingApi.Models;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    public static WebApplication MapTrainingPlanController(this WebApplication app)
    {
        var groupName = "TrainingPlans";
        app.MapPost("/trainingplans", PostTrainingPlanAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PostTrainingPlanAsync))
            .WithDescription("Create a new training plan.")
            .Produces<TrainingPlan>(200).Produces(204).ProducesProblem(400);
        app.MapPut("/trainingplans/{trainingPlanId:int}", PutTrainingPlanAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PutTrainingPlanAsync))
            .WithDescription("Update an existing training plan by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        app.MapGet("/trainingplans", GetAllTrainingPlansAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAllTrainingPlansAsync))
            .WithDescription("Retrieve all training plans.")
            .Produces<List<TrainingPlan>>(200).ProducesProblem(400);
        app.MapGet("/trainingplans/{trainingPlanId:int}", GetTrainingPlanByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetTrainingPlanByIdAsync))
            .WithDescription("Retrieve a training plan by ID.")
            .Produces<TrainingPlan>(200).ProducesProblem(400).ProducesProblem(404);
        app.MapDelete("/trainingplans/{trainingPlanId:int}", DeleteTrainingPlanByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(DeleteTrainingPlanByIdAsync))
            .WithDescription("Delete a training plan by ID.")
            .Produces(204).ProducesProblem(400).ProducesProblem(404);
        return app;
    }
}