using Domain.Entities;

namespace Domain.Repositories;

public interface IUserFeedbackRepository
{
    void Add(UserFeedback userFeedback);
    Task<UserFeedback?> GetById(int userFeedbackId);
    Task<List<UserFeedback>> GetByDatasetId(int datasetId);
    void Delete(UserFeedback feedback);
    Task SaveChanges(CancellationToken cancellationToken = default);
}
