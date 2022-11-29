using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
	public void Configure(EntityTypeBuilder<Developer> builder)
	{
		builder.HasKey(x => x.id);
		builder.Property(x => x.name).IsRequired().HasMaxLength(50);	
		builder.Property(x => x.username).IsRequired().HasMaxLength(25).IsUnicode();
		builder.Property(x => x.password).IsRequired();
		builder.Property(x => x.score);
		builder.HasMany(x => x.courses);
	}
}
