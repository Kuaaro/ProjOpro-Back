using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;

namespace Application.Datasets;

public interface IDatasetService
{
    Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request);
    Task<GetDatasetResponse> GetDataset(int id);
}
