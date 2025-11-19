using Domain.Entities;

namespace Domain.Repositories;

public interface IDatasetRepository
{
    Task<IReadOnlyList<DataSet>> GetByParentId(int parentId);
}
