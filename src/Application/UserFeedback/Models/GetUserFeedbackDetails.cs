namespace Application.UserFeedback.Models;

public class GetUserFeedbackDetails
{
    public int UserFeedbackId { get; set; }
    public string ContactPoint { get; set; } = default!;
    public string Message { get; set; } = default!;
    public int DatasetId { get; set; }
}
