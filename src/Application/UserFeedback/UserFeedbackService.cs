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
    public async Task<GetUserFeedbackList> GetUserFeedbackList(int datasetId)
    {
        var feedbacks = await userFeedbackRepository.GetByDatasetId(datasetId);

        return new GetUserFeedbackList
        {
            NameIdPairs = feedbacks.Select(f => new NameIdPair
            {
                Id = f.UserFeedbackId,
                Name = f.ContactPoint
            }).ToList()
        };
    }

    public async Task DeleteUserFeedback(int userFeedbackId)
    {
        var feedback = await userFeedbackRepository.GetById(userFeedbackId);

        if (feedback is null)
            return;

        userFeedbackRepository.Delete(feedback);
        await userFeedbackRepository.SaveChanges();
    }
}
