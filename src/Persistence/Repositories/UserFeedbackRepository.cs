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

    public Task SaveChanges(CancellationToken cancellationToken)
        => dbContext.SaveChangesAsync(cancellationToken);
}
