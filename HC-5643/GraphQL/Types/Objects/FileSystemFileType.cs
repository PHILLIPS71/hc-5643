using HC_5643.Domain.Objects;

namespace HC_5643.GraphQL.Types.Objects;

public class FileSystemFileType : ObjectType<FileSystemFile>
{
    protected override void Configure(IObjectTypeDescriptor<FileSystemFile> descriptor)
    {
    }
}