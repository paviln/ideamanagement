using Microsoft.AspNetCore.Http;

namespace EskobInnovation.IdeaManagement.API.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }   
    }
}