using Microsoft.EntityFrameworkCore;
using Developer = devnet_Csharp_backend.api.Models.Developer;

namespace devnet_Csharp_backend.api.Data 
{
    public class DevnetDBContext : DbContext
    {
        public DevnetDBContext(DbContextOptions<DevnetDBContext> options) : base(options) {}

        public DbSet<Developer> developer { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Course> course { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(x => x.username).IsUnique(true);
        
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new CourseMap());        
            builder.ApplyConfiguration(new DeveloperMap());        
            base.OnModelCreating(builder);   
        }
    }
}