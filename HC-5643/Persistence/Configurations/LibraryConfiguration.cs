using HC_5643.Domain.Objects;
using HC_5643.Domain.Values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations;

public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder
            .HasIndex(p => p.Slug)
            .IsUnique();

        builder
            .OwnsOne<PathInfo>(p => p.PathInfo);

        builder
            .HasMany(p => p.Entries)
            .WithOne()
            .IsRequired();
    }
}