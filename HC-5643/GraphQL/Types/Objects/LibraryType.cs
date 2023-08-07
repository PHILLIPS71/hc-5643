using HC_5643.Domain.Objects;
using HC_5643.GraphQL.Types.Unions;

namespace HC_5643.GraphQL.Types.Objects;

public class LibraryType : ObjectType<Library>
{
    protected override void Configure(IObjectTypeDescriptor<Library> descriptor)
    {
        descriptor
            .Field(p => p.Entries)
            .Type<ListType<FileSystemEntryType>>()
            .UseProjection()
            .UseFiltering()
            .UseSorting();
    }
}