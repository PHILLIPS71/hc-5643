using HC_5643.Domain.Values;

namespace HC_5643.Domain.Objects;

public abstract class FileSystemEntry
{
    public int Id { get; set; }

    public PathInfo PathInfo { get; set; } = null!;

    public FileSystemDirectory? ParentDirectory { get; set; }
}