using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseMap : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.name).IsRequired().HasMaxLength(35);
        builder.Property(x => x.addScore);
        builder.HasMany(x => x.developers);
    }
}
