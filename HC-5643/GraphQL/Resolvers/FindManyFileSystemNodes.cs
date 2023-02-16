using HC_5643.GraphQL.Types;
using HC_5643.Persistence;
using HC_5643.Persistence.Entities;

namespace HC_5643.GraphQL.Resolvers
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class FindManyFileSystemNodes
    {
        [GraphQLType(typeof(FileSystemNodeType))]
        [UsePaging]
        [UseProjection] // without any ObjectTypes configured projection casues https://github.com/ChilliCream/hotchocolate/issues/1658 
        [UseFiltering]
        [UseSorting]
        public IQueryable<FileSystemNode> FileSystemNodes(ApplicationDbContext database)
        {
            return database.FileSystemNodes;
        }
    }
}
