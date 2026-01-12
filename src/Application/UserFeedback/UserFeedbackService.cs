using Application.UserFeedback.Models;
using Domain.Repositories;
using Domain.Entities;

namespace Application.UserFeedback;

internal sealed class UserFeedbackService(IUserFeedbackRepository userFeedbackRepository) : IUserFeedbackService
{
    public async Task<CreateUserFeedbackResponse> CreateFeedback(CreateUserFeedbackRequest request)
    {
        var feedback = new Domain.Entities.UserFeedback(
            request.ContactPoint,
            request.Message,
            request.DatasetId);

        userFeedbackRepository.Add(feedback);
        await userFeedbackRepository.SaveChanges();

        return new CreateUserFeedbackResponse
        {
            UserFeedbackId = feedback.UserFeedbackId
        };
    }
    public async Task<GetUserFeedbackDetails> GetUserFeedback(int id)
    {
        var feedback = await userFeedbackRepository.GetById(id);

        if (feedback is null)
            return null!;

        return new GetUserFeedbackDetails
        {
            UserFeedbackId = feedback.UserFeedbackId,
            ContactPoint = feedback.ContactPoint,
            Message = feedback.Message,
            DatasetId = feedback.DatasetId
        };
    }
}
