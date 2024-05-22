using Microsoft.AspNetCore.Http;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.Files
{
    public class UploadFileSetterDTO
    {
        public IFormFile File { get; set; }
        public string[] FilePathList { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }


    }
}
