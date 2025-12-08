using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.SetSchema;

namespace Application.Datasets;

public interface IDatasetService
{
    Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request);
    Task<GetDatasetResponse> GetDataset(int id);
    Task<SetSchemaResponse> SetSchema(int datasetId, SetSchemaRequest request);
}
