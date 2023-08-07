using HC_5643.Domain.Objects;
using HC_5643.Domain.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations;

public class FileSystemDirectoryConfiguration : IEntityTypeConfiguration<FileSystemDirectory>
{
    public void Configure(EntityTypeBuilder<FileSystemDirectory> builder)
    {
        builder
            .OwnsOne<PathInfo>(p => p.PathInfo);
    }
}