using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Datasets;

internal sealed class DatasetService(IDatasetRepository datasetRepository, ISchemaRepository schemaRepository) : IDatasetService
{
    public async Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request)
    {
        var dataset = await datasetRepository.GetByName(request.Name);

        if (dataset is null)
        {
            dataset = new DataSet
            {
                Name = request.Name,
                Description = request.Description,
                ContactPoint = request.ContactPoint,
                Keywords = request.Keywords?.ToList() ?? new List<string>(),
                Distribution = new List<Distribution>(),
                ParentId = request.ParentId,
                SchemaId = request.SchemaId
            };

            datasetRepository.Add(dataset);
        }
        else
        {
            dataset.Name = request.Name;
            dataset.Description = request.Description;
            dataset.ContactPoint = request.ContactPoint;
            dataset.Keywords = request.Keywords?.ToList() ?? new List<string>();
            dataset.SchemaId = request.SchemaId;
        }

        if (request.Distributions is not null)
        {
            foreach (var d in request.Distributions)
            {
                var distribution = new Distribution
                {
                    AccessUrl = d.AccessUrl,
                    Description = d.Description,
                    Format = d.Format,
                    IsAvailable = d.Availability,
                    DataSet = dataset
                };

                dataset.Distribution.Add(distribution);
            }
        }

        await datasetRepository.SaveChanges();

        return new CreateDatasetResponse(dataset.Id);
    }

    public async Task<GetDatasetResponse> GetDataset(int id)
    {
        var dataset = await datasetRepository.GetById(id);

        var distributionDtos = dataset.Distribution
            .Select(d => new Models.GetDataset.DistributionFull(
                d.Id,           
                d.AccessUrl,             
                d.Description,  
                d.Format,   
                d.IsAvailable  
            ))
            .ToList();

        return new GetDatasetResponse(
            dataset.Name,
            dataset.Description,
            dataset.ContactPoint,
            dataset.Keywords.ToList(),
            distributionDtos,
            dataset.SchemaId
        );

    }

    public async Task ModifyDataset(int id, ModifyDatasetRequest request)
    {
        var dataset = await datasetRepository.GetById(id);
        
        if (dataset is null)
        {
            throw new InvalidOperationException($"Dataset with id {id} not found.");
        }

        var schema = await schemaRepository.GetById(request.SchemaId);
        
        if (schema is null)
        {
            throw new InvalidOperationException($"Schema with id {request.SchemaId} not found.");
        }

        dataset.Name = request.Name;
        dataset.Description = request.Description;
        dataset.ContactPoint = request.ContactPoint;
        dataset.Keywords = request.Keywords?.ToList() ?? new List<string>();
        dataset.SchemaId = request.SchemaId;

        dataset.Distribution.Clear();
        if (request.Distributions is not null)
        {
            foreach (var d in request.Distributions)
            {
                var distribution = new Distribution
                {
                    AccessUrl = d.AccessUrl,
                    Description = d.Description,
                    Format = d.Format,
                    IsAvailable = d.Availability,
                    DataSet = dataset
                };

                dataset.Distribution.Add(distribution);
            }
        }

        await datasetRepository.SaveChanges();
    }

}
