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
    public async Task<IReadOnlyList<DataSet>> GetByParentId(int parentId)
    {
        return await dbContext.DataSets
            .Where(c => c.ParentId == parentId)
            .ToListAsync();
    }
}
