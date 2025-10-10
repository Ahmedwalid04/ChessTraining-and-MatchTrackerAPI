namespace ChessTrainingApi.Models;
public record TrainingPlan : BaseEntity
{
    public int UserId { get; set; }
    
    public string FocusArea { get; set; }

    public DateTime CreatedAt { get; set; }

}