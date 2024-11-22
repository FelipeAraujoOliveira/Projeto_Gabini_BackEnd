namespace Core.Models
{
    public class FileData
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}