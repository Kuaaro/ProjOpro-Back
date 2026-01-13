using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class UserFeedbackRepository(ApplicationDbContext dbContext) : IUserFeedbackRepository
{
    public void Add(UserFeedback userFeedback)
        => dbContext.UserFeedbacks.Add(userFeedback);

    public Task<UserFeedback?> GetById(int id)
    {
        return dbContext.UserFeedbacks
            .FirstOrDefaultAsync(c => c.UserFeedbackId == id);
    }

    public Task<List<UserFeedback>> GetByDatasetId(int datasetId)
    {
        return dbContext.UserFeedbacks
            .Where(c => c.DatasetId == datasetId)
            .ToListAsync();
    }

    public void Delete(UserFeedback userFeedback)
        => dbContext.UserFeedbacks.Remove(userFeedback);

    public Task SaveChanges(CancellationToken cancellationToken)
        => dbContext.SaveChangesAsync(cancellationToken);
}
