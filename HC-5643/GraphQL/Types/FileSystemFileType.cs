using HC_5643.Persistence.Entities;

namespace HC_5643.GraphQL.Types
{
    public class FileSystemFileType : ObjectType<FileSystemFile>
    {
        protected override void Configure(IObjectTypeDescriptor<FileSystemFile> descriptor)
        {
        }
    }
}
