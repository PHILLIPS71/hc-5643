using HC_5643.Domain.Objects;
using HC_5643.GraphQL.Types.Unions;
using HC_5643.Persistence;

namespace HC_5643.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class FindManyFileSystemEntriesQuery
{
    [GraphQLType<ListType<FileSystemEntryType>>]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<FileSystemEntry> FileSystemEntries([Service] ApplicationDbContext database)
    {
        return database.Entries;
    }
}
