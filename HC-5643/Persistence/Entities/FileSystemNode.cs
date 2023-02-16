namespace HC_5643.Persistence.Entities
{
    public abstract class FileSystemNode
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }
        public virtual FileSystemDirectory? Parent { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
