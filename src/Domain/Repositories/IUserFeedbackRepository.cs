using Domain.Entities;

namespace Domain.Repositories;

public interface IUserFeedbackRepository
{
    void Add(UserFeedback userFeedback);
    Task<UserFeedback?> GetById(int userFeedbackId);
	Task SaveChanges(CancellationToken cancellationToken = default);
}
