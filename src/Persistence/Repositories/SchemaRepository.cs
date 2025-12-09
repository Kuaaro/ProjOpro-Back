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

    public void Add(Schema schema)
        => dbContext.Schemas.Add(schema);

    public async Task<List<Schema>> GetAll()
    {
        return await dbContext.Schemas
            .ToListAsync();
    }

    public Task<Schema?> GetById(int id)
    {
        return dbContext.Schemas
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}

