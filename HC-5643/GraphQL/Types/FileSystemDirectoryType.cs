using HC_5643.Persistence.Entities;

namespace HC_5643.GraphQL.Types
{
    public class FileSystemDirectoryType : ObjectType<FileSystemDirectory>
    {
        protected override void Configure(IObjectTypeDescriptor<FileSystemDirectory> descriptor)
        {
            descriptor
                .Field(p => p.Nodes)
                .UsePaging()
                .UseFiltering()
                .UseSorting();
        }
    }
}
