using HC_5643.Domain.Objects;
using HC_5643.Persistence;

namespace HC_5643.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class LibraryFindOneQuery
{
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Library> Library([Service] ApplicationDbContext database)
    {
        return database.Libraries;
    }
}