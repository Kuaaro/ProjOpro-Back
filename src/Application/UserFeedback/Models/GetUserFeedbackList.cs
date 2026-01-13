namespace Application.UserFeedback.Models;


public sealed class GetUserFeedbackList
{
    public List<NameIdPair> NameIdPairs { get; set; } = [];
}