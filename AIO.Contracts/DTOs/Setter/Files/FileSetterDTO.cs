using Microsoft.AspNetCore.Http;

namespace AIO.Contracts.DTOs.Setter.Files
{
    public class FileSetterDTO
    {
        public string? id { get; set; }
        public IFormFile? file { get; set; }
        public string? filePath { get; set; }

    }
}
