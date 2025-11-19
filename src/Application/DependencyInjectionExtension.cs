using Application.Catalogs;
using Application.Schemas;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// Register application services, validators, and configurations here
		services.AddScoped<ICatalogService, CatalogService>();
		services.AddScoped<ISchemaService, SchemaService>();
		return services;
	}
}