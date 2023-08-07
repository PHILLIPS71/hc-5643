using HC_5643.Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations;

public class FileSystemEntryConfiguration : IEntityTypeConfiguration<FileSystemEntry>
{
    public void Configure(EntityTypeBuilder<FileSystemEntry> builder)
    {
        builder
            .UseTpcMappingStrategy();
    }
}