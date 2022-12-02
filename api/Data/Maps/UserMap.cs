using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.username).IsRequired().HasMaxLength(25);
        builder.Property(x => x.password).IsRequired();
    }
}

