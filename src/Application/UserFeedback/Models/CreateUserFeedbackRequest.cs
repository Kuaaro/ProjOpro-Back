namespace Application.UserFeedback.Models;
public class CreateUserFeedbackRequest
{
    public string ContactPoint { get; set; } = "";
    public string Message { get; set; } = "";
    public int DatasetId { get; set; }
}
