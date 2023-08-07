namespace HC_5643.Domain.Values;

public class PathInfo
{
    public string Name { get; init; } = null!;

    public string FullName { get; init; } = null!;

    public string? Extension { get; init; }

    public string? DirectoryPath { get; init; }
}