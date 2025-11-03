using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Configuration;

public sealed class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
	public void Configure(EntityTypeBuilder<Catalog> builder)
	{
		
	}
}