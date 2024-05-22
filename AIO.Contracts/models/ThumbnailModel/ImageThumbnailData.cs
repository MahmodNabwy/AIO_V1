using Microsoft.AspNetCore.Http;

namespace AIO.Contracts.models.ThumbnailModel;

public class ImageThumbnailData 
{
    public IFormFile file;
    public string relativePath;
    public string extention;
    public string rootFolder;
}