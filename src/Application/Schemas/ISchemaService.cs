using Application.Schemas.Models.CreateSchema;
using Application.Schemas.Models.GetSchemaList;

namespace Application.Schemas;

public interface ISchemaService
{
    Task<GetSchemaListResponse> GetSchemaListAsync();
    Task<CreateSchemaResponse> CreateSchema(CreateSchemaRequest request);
}
