using Application.Schemas.Models.CreateSchema;
using Application.Schemas.Models.GetSchemaList;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Schemas;

internal sealed class SchemaService(ISchemaRepository schemaRepository) : ISchemaService
{
    public async Task<CreateSchemaResponse> CreateSchema(CreateSchemaRequest request)
    {
        var schema = new Schema(request.Name, request.JsonSchema);
        schemaRepository.Add(schema);
        await schemaRepository.SaveChanges();
        return new CreateSchemaResponse(schema.Id);
    }

    public async Task<GetSchemaListResponse> GetSchemaListAsync()
    {
        var schemas = await schemaRepository.GetAll();
        var schemaPairs = schemas
            .Select(s => new NameIdPair(s.Name, s.Id))
            .ToList();

        return new GetSchemaListResponse(schemaPairs);
    }
}
