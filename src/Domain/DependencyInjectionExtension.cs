using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddDomain(this IServiceCollection services)
	{
		// Register domain services, entities, and configurations here
		return services;
	}
}