using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		// Register persistence services, DbContext, and configurations here
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseInMemoryDatabase("AuctionSystemDb");
		});
		
		services.AddScoped<ICatalogRepository, CatalogRepository>();
		services.AddScoped<IDatasetRepository, DatasetRepository>();
		return services;
	}
}