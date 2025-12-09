using Application.Schemas.Models.CreateSchema;
using Application.Schemas.Models.GetSchemaList;
using Application.Schemas.Models.ModifySchema;

namespace Application.Schemas;

public interface ISchemaService
{
    Task<GetSchemaListResponse> GetSchemaListAsync();
    Task<CreateSchemaResponse> CreateSchema(CreateSchemaRequest request);
    Task ModifySchema(int id, ModifySchemaRequest body);
}
