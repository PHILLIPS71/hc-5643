using HC_5643.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations
{
    public class FileSystemDirectoryConfiguration : IEntityTypeConfiguration<FileSystemDirectory>
    {
        public void Configure(EntityTypeBuilder<FileSystemDirectory> builder)
        {
            builder
                .HasIndex(p => p.Path)
                .IsUnique();

            builder
                .HasMany(p => p.Nodes)
                .WithOne(p => p.Parent)
                .HasForeignKey(p => p.ParentId);
        }
    }
}
