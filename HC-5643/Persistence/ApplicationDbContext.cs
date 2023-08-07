using HC_5643.Domain.Objects;
using Microsoft.EntityFrameworkCore;

namespace HC_5643.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Library> Libraries => Set<Library>();

    public DbSet<FileSystemEntry> Entries => Set<FileSystemEntry>();
    public DbSet<FileSystemFile> Files => Set<FileSystemFile>();
    public DbSet<FileSystemDirectory> Directories => Set<FileSystemDirectory>();
}