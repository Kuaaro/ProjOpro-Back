using Application.Schemas.Models.GetSchemaList;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Schemas;

internal sealed class SchemaService(ISchemaRepository schemaRepository) : ISchemaService
{
    public async Task<GetSchemaListResponse> GetSchemaListAsync()
    {
        var schemas = await schemaRepository.GetAll();
        var schemaPairs = schemas
            .Select(s => new NameIdPair(s.Name, s.Id))
            .ToList();

        return new GetSchemaListResponse(schemaPairs);
    }
}
