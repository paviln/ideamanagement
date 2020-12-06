namespace EskobInnovation.IdeaManagement.API.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
    }
}