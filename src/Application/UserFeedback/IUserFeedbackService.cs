using Application.Catalogs.Models.CreateCatalog;
using Application.Catalogs.Models.GetCatalogChildren;
using Application.UserFeedback.Models;

namespace Application.UserFeedback;

public interface IUserFeedbackService
{
    Task<CreateUserFeedbackResponse> CreateFeedback(CreateUserFeedbackRequest request);
    Task<GetUserFeedbackDetails> GetUserFeedback(int id);
    Task<GetUserFeedbackList> GetUserFeedbackList(int datasetId);
    Task DeleteUserFeedback(int userFeedbackId);
}
