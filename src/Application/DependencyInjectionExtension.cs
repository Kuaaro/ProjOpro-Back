using Application.Catalogs;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// Register application services, validators, and configurations here
		services.AddScoped<ICatalogService, CatalogService>();
		return services;
	}
}