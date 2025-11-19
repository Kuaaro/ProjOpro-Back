using Application.Schemas.Models.GetSchemaList;

namespace Application.Schemas;

public interface ISchemaService
{
    Task<GetSchemaListResponse> GetSchemaListAsync();
}
