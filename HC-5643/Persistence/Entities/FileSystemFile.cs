namespace HC_5643.Persistence.Entities
{
    public class FileSystemFile : FileSystemNode
    {
        public long Size { get; set; }

        public DateTime? ProbedAt { get; set; }
    }
}
