using AIO.Contracts.IServices.Services.ThumbnailService;
using AIO.Contracts.models.ThumbnailModel;
using AIO.Shared.Helpers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AIO.Application.Services.ThumbnailService;

public class PDFThumbnailService : IThumbnailService<PdfThumbnailData>
{
    private readonly IHostEnvironment _environment;
    private String _resourcesPath;

    public PDFThumbnailService(IOptions<ResourcesPath> resourcesPath, IHostEnvironment environment)
    {
        _environment = environment;
        this._resourcesPath = resourcesPath.Value.Path.Replace(@"\", @"/");
    }


    public string GenerateThumbnail(PdfThumbnailData pdfThumbnailData)
    {

        string fileName = Guid.NewGuid().ToString() + ".jpg";
        string fileRelativePath = Path.Combine(pdfThumbnailData.relativePath, fileName);
        var absolutePath = Path.Combine(_environment.ContentRootPath, pdfThumbnailData.rootFolder, fileRelativePath);
        GhostscriptWrapper.GhostscriptWrapper.GeneratePageThumb(pdfThumbnailData.inputPath, absolutePath, 1, 100, 100);
        return fileName;
    }
}