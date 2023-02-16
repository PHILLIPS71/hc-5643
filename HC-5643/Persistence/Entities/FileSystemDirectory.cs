namespace HC_5643.Persistence.Entities
{
    public class FileSystemDirectory : FileSystemNode
    {
        public virtual ICollection<FileSystemNode>? Nodes { get; set; }
    }
}
