using HC_5643.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC_5643.Persistence.Configurations
{
    public class FileSystemNodeConfiguration : IEntityTypeConfiguration<FileSystemNode>
    {
        public void Configure(EntityTypeBuilder<FileSystemNode> builder)
        {
            builder
                .UseTpcMappingStrategy();
        }
    }
}
