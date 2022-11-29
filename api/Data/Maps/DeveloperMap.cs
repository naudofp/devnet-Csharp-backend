using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
	public void Configure(EntityTypeBuilder<Developer> builder)
	{
		builder.Property(x => x.score);
		builder.HasMany(x => x.courses);
	}
}
