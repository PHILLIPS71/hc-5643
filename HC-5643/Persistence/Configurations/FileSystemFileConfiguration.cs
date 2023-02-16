using HC_5643.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations
{
    public class FileSystemFileConfiguration : IEntityTypeConfiguration<FileSystemFile>
    {
        public void Configure(EntityTypeBuilder<FileSystemFile> builder)
        {
            builder
                .HasIndex(p => p.Path)
                .IsUnique();
        }
    }
}
