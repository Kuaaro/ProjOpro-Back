using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class SchemaRepository(ApplicationDbContext dbContext)
: ISchemaRepository
{
    public Task SaveChanges(CancellationToken cancellationToken)
        => dbContext.SaveChangesAsync(cancellationToken);

    public async Task<List<Schema>> GetAll()
    {
        return await dbContext.Schemas
            .ToListAsync();
    }
}

