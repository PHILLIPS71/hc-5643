using HC_5643.Domain.Values;

namespace HC_5643.Domain.Objects;

public class Library
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public PathInfo PathInfo { get; set; } = null!;

    public ICollection<FileSystemEntry> Entries { get; set; } = new List<FileSystemEntry>();
}