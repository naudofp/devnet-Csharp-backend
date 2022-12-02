using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Developer = devnet_Csharp_backend.api.Models.Developer;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
	public void Configure(EntityTypeBuilder<Developer> builder)
	{
		builder.Ignore(x => x.score);
		builder.HasMany(x => x.courses);
	}
}
