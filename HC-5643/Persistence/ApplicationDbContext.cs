using HC_5643.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace HC_5643.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<FileSystemNode> FileSystemNodes => Set<FileSystemNode>();
        public DbSet<FileSystemFile> FileSystemFiles => Set<FileSystemFile>();
        public DbSet<FileSystemDirectory> FileSystemDirectories => Set<FileSystemDirectory>();
    }
}
