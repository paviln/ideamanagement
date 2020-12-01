using Microsoft.AspNetCore.Http;

namespace Panel.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }   
    }
}