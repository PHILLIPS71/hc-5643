using HC_5643.Domain.Objects;

namespace HC_5643.GraphQL.Types.Unions;

public class FileSystemEntryType : UnionType<FileSystemEntry>
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Type<ObjectType<FileSystemDirectory>>();
        descriptor.Type<ObjectType<FileSystemFile>>();
    }
}