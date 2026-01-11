using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database;

internal sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Catalog> Catalogs { get; set; }

	public DbSet<DataSet> DataSets { get; set; }

	public DbSet<Distribution> Distributions { get; set; }

	public DbSet<Schema> Schemas { get; set; }

	public DbSet<SensorRouter> SensorRouters { get; set; }

	public DbSet<DataEntry> DataEntries { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}