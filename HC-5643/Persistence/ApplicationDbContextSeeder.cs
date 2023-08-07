using HC_5643.Domain.Objects;
using HC_5643.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace HC_5643.Persistence;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedDatabaseAsync(this IServiceScope scope, CancellationToken cancellation = default)
    {
        var provider = scope.ServiceProvider;
        var database = provider.GetRequiredService<ApplicationDbContext>();
        
        if (await database.Libraries.AnyAsync(cancellation))
            return;

        var library = new Library
        {
            Id = 1,
            Name = "Family Guy",
            Slug = "family-guy",
            PathInfo = new PathInfo
            {
                Name = "Family Guy",
                FullName = "/media/tv-shows/Family Guy",
                Extension = null,
                DirectoryPath = "/media/tv-shows"
            },
            Entries = new List<FileSystemEntry>
            {
                new FileSystemDirectory
                {
                    Id = 1,
                    PathInfo = new PathInfo
                    {
                        Name = "Season 1",
                        FullName = "/media/tv-shows/Family Guy/Season 1",
                        Extension = null,
                        DirectoryPath = "/media/tv-shows/Family Guy"
                    }
                },
                new FileSystemFile
                {
                    Id = 2,
                    Size = 150202961,
                    PathInfo = new PathInfo
                    {
                        Name = "Family Guy - S01E01 - Death Has a Shadow.mp4",
                        FullName = "/media/tv-shows/Family Guy/Season 1/Family Guy - S01E01 - Death Has a Shadow.mp4",
                        Extension = ".mp4",
                        DirectoryPath = "/media/tv-shows/Family Guy/Season 1"
                    }
                },
                new FileSystemFile
                {
                    Id = 3,
                    Size = 159330233,
                    PathInfo = new PathInfo
                    {
                        Name = "Family Guy - S01E02 - I Never Met the Dead Man.mp4",
                        FullName =
                            "/media/tv-shows/Family Guy/Season 1/Family Guy - S01E02 - I Never Met the Dead Man.mp4",
                        Extension = ".mp4",
                        DirectoryPath = "/media/tv-shows/Family Guy/Season 1"
                    }
                },
                new FileSystemFile
                {
                    Id = 4,
                    Size = 138331702,
                    PathInfo = new PathInfo
                    {
                        Name = "Family Guy - S01E03 - Chitty Chitty Death Bang.mp4",
                        FullName = "/media/tv-shows/Family Guy/Season 1/Family Guy - S01E03 - Chitty Chitty Death Bang.mp4",
                        Extension = ".mp4",
                        DirectoryPath = "/media/tv-shows/Family Guy/Season 1"
                    }
                },
            }
        };

        database.Libraries.Add(library);
        await database.SaveChangesAsync(cancellation);
    }
}