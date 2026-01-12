namespace Domain.Entities;

public sealed class UserFeedback(string contactPoint, string message, int datasetId)
{
    public int UserFeedbackId { get; set; }
    public string ContactPoint { get; set; } = contactPoint;
    public string Message { get; set; } = message;
    public int DatasetId { get; set; } = datasetId;
}
