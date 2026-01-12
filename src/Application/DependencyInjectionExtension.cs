using Application.Catalogs;
using Application.Datasets;
using Application.Schemas;
using Application.Sensors;
using Application.UserFeedback;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// Register application services, validators, and configurations here
		services.AddScoped<ICatalogService, CatalogService>();
		services.AddScoped<IDatasetService, DatasetService>();
		services.AddScoped<ISchemaService, SchemaService>();
		services.AddScoped<ISensorService, SensorService>();
		services.AddScoped<IUserFeedbackService, UserFeedbackService>();
        return services;
	}
}