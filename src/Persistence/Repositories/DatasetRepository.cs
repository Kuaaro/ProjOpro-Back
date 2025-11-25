using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

internal sealed class DatasetRepository(ApplicationDbContext dbContext) : IDatasetRepository
{
    public void Add(DataSet dataset)
    {
        dbContext.DataSets.Add(dataset);
    }

    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<DataSet?> GetById(int id)
    {
        return dbContext.DataSets
            .Include(d => d.Distribution)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<DataSet?> GetByName(string name)
    {
        return dbContext.DataSets
            .Include(d => d.Distribution)
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<IReadOnlyList<DataSet>> GetByParentId(int parentId)
    {
        return await dbContext.DataSets
            .Where(c => c.ParentId == parentId)
            .ToListAsync();
    }
}
