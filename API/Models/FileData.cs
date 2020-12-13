namespace EskobInnovation.IdeaManagement.API.Models
{
    public class FileData
    {
        public int FileDataId { get; set; }
        public byte[] Data { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
    }
}