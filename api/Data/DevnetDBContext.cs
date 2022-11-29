using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DevnetDBContext : DbContext
{
    public DevnetDBContext(DbContextOptions<DevnetDBContext> options) : base(options) {}

    public DbSet<Developer> developer { get; set; }
    public DbSet<User> user { get; set; }
    public DbSet<Course> course { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());        
        builder.ApplyConfiguration(new CourseMap());        
        builder.ApplyConfiguration(new DeveloperMap());        
        base.OnModelCreating(builder);   
    }
}