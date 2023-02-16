using HC_5643.Persistence.Entities;

namespace HC_5643.GraphQL.Types
{
    public class FileSystemNodeType : UnionType<FileSystemNode>
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Type<FileSystemFileType>();
            descriptor.Type<FileSystemDirectoryType>();
        }
    }
}
