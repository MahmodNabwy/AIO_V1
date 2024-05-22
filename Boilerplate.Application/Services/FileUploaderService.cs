using AutoMapper;
using Boilerplate.Contracts.DTOs.Getter.FileLibrary;
using Boilerplate.Contracts.DTOs.Setter.PhotoLibrary;
using Boilerplate.Contracts.Helpers;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.MediaUploaderService;
using Boilerplate.Contracts.IServices.Services.ThumbnailService;
using Boilerplate.Contracts.models.ThumbnailModel;
using Boilerplate.Core.Bases;
using Boilerplate.Core.Entities.FilesLibrary;
using Boilerplate.Core.IServices.Custom;
using Boilerplate.Shared.Consts;
using Boilerplate.Shared.Helpers;
using Boilerplate.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Drawing.Imaging;

namespace Boilerplate.Application.Services;

public class FileUploaderService : BaseService<FileUploaderService>, IFileUploaderService
{
    private readonly IHostEnvironment _environment;
    private readonly IThumbnailService<PdfThumbnailData> _pdfThumbnailService;
    private readonly IThumbnailService<ImageThumbnailData> _imgThumbnailService;
    private String _resourcesPath;

    public FileUploaderService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO,
        IOptions<ResourcesPath> resourcesPath, ILogger<FileUploaderService> logger, ICulture culture,
        IHostEnvironment environment, IHttpContextAccessor HttpContextAccessor,
        IThumbnailService<PdfThumbnailData> pdfThumbnailService,
        IThumbnailService<ImageThumbnailData> imgThumbnailService
    ) :
        base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, HttpContextAccessor)
    {
        _environment = environment;
        _pdfThumbnailService = pdfThumbnailService;
        _imgThumbnailService = imgThumbnailService;
        this._resourcesPath = resourcesPath.Value.Path.Replace(@"\", @"/");
    }

    public async Task<IHolderOfDTO> GetAllImage(int directoryPath, int? fileType)
    {
        try
        {
            var getDirectoryPath = PhotoDirectories.GetPhotoDirectory(directoryPath);
            var fileTypeDir = getFileTypeDir(fileType);
            List<bool> lIndicators = new List<bool>();
            var result = await _unitOfWork.FileUploader.FindAllFilterAsync(att =>
                att.directory == getDirectoryPath && (fileType == null || att.FileType == fileTypeDir));
            var mappedItems = _mapper.Map<IEnumerable<FileLibraryGetterDTO>>(result.ToList());
            _holderOfDTO.Add(Res.Response, mappedItems);
            var state = lIndicators.All(x => x);
            _holderOfDTO.Add(Res.state, state);
            return _holderOfDTO;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IHolderOfDTO> UploadFileAsync(PhotoLibrarySetter uploadedFiles)
    {
        string rootFolder = _resourcesPath;
        var holder = new HolderOfDTO();
        List<bool> lIndicator = new List<bool>();
        List<FilesLibrary> repoFiles = new List<FilesLibrary>();

        try
        {
            var directoryPath = PhotoDirectories.GetPhotoDirectory((int)uploadedFiles.Directory);
            foreach (IFormFile file in uploadedFiles.Files)
            {
                string extention = Path.GetExtension(file.FileName).ToLower();
                string fileCategory = FileCategory(extention);
                if (!Directory.Exists(Path.Combine(rootFolder, directoryPath, fileCategory)))
                    Directory.CreateDirectory(Path.Combine(rootFolder, directoryPath, fileCategory));

                string fileName = Guid.NewGuid().ToString() + extention;
                var relativePath = Path.Combine(directoryPath, fileCategory);
                string fileRelativePath = Path.Combine(relativePath, fileName);
                var absolutePath = Path.Combine(_environment.ContentRootPath, rootFolder, fileRelativePath);

                using var fileStream = new FileStream(absolutePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
                fileStream.Close();
                var size = file.Length.ToString();
                var type = file.ContentType;
                string thumbnail = "";

                if (getTypeExtenstions(FileTypes.Image).Contains(extention))
                {
                    thumbnail = _imgThumbnailService.GenerateThumbnail(new ImageThumbnailData
                    {
                        file = file,
                        relativePath = relativePath,
                        extention = extention,
                        rootFolder = rootFolder
                    });
                }
                else if (getTypeExtenstions(FileTypes.Pdf).Contains(extention))
                {
                    thumbnail = _pdfThumbnailService.GenerateThumbnail(new PdfThumbnailData
                    {
                        file = file,
                        relativePath = relativePath,
                        extention = extention,
                        rootFolder = rootFolder,
                        inputPath = absolutePath
                    });
                }


                repoFiles.Add(new FilesLibrary
                {
                    File = fileName,
                    FileName = file.FileName,
                    directory = directoryPath,
                    FileType = fileCategory,
                    Thumbnail = thumbnail
                });
            }

            if (repoFiles.Count > 0)
            {
                await _unitOfWork.FileUploader.AddRangeAsync(repoFiles);
                lIndicator.Add(_unitOfWork.Complete() > 0);
                var mappedItems = _mapper.Map<IEnumerable<FileLibraryGetterDTO>>(repoFiles);

                holder.Add(Res.filePath, mappedItems);
            }
        }
        catch (Exception ex)
        {
            DeleteList(repoFiles.Select(att => Path.Combine(att.directory, att.File)).ToList());
            holder.Add(Res.message, ex.Message);
            holder.Add(Res.error, ex.InnerException);
            lIndicator.Add(false);
        }

        holder.Add(Res.state, lIndicator.All(x => x));
        return holder;
    }

    private string GenerateThumbnail(IFormFile file, string relativePath, string extention, string rootFolder)
    {
        var img = Image.FromStream(file.OpenReadStream());
        var resizedImg = new Bitmap(img, new Size(300, 300));
        using var imageStream = new MemoryStream();
        string fileName = Guid.NewGuid().ToString() + extention;
        string fileRelativePath = Path.Combine(relativePath, fileName);
        var absolutePath = Path.Combine(_environment.ContentRootPath, rootFolder, fileRelativePath);
        resizedImg.Save(absolutePath, ImageFormat.Png);
        return fileName;
    }

    private string GenerateNonImageThumbnail(IFormFile file, string relativePath, string rootFolder, string inputPath)
    {
        string fileName = Guid.NewGuid().ToString() + ".jpg";
        string fileRelativePath = Path.Combine(relativePath, fileName);
        var absolutePath = Path.Combine(_environment.ContentRootPath, rootFolder, fileRelativePath);
        GhostscriptWrapper.GhostscriptWrapper.GeneratePageThumb(inputPath, absolutePath, 1, 100, 100);
        return fileName;
    }

    private string FileCategory(string extention)
    {
        if (new List<string> { ".jpg", ".jpeg", ".png", ".gif" }.Contains(extention))
        {
            return FileTypes.Image;
        }

        if (new List<string> { ".pdf" }.Contains(extention))
        {
            return FileTypes.Pdf;
        }

        return FileTypes.Data;
    }

    private List<string> getTypeExtenstions(string fileType)
    {
        switch (fileType)
        {
            case FileTypes.Image:
                return new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
                break;
            case FileTypes.Excel:
                return new List<string> { ".xlsx" };
                break;
            case FileTypes.Pdf:
                return new List<string> { ".pdf" };
                break;
            default:
                return new List<string>();
                break;
        }
    }

    private string? getFileTypeDir(int? fileType)
    {
        if (fileType == null) return null;
        switch (fileType)
        {
            case 1: return "Image";
            case 2: return "Pdf";
            case 3: return "Excel";
            default: return "Data";
        }
    }

    protected void DeleteList(List<string> filePath)
    {
        foreach (string file in filePath)
        {
            if (!string.IsNullOrEmpty(file))
            {
                var fileDir = _resourcesPath + file;
                if (File.Exists(fileDir))
                    File.Delete(fileDir);
            }
        }
    }

    protected bool DeleteFile(string filePath)
    {
        List<bool> lIndicator = new List<bool>();
        try
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var fileDir = _resourcesPath + filePath;
                if (File.Exists(fileDir))
                    File.Delete(fileDir);
            }

            lIndicator.Add(true);
        }
        catch (Exception ex)
        {
            lIndicator.Add(false);
        }

        return lIndicator.All(x => x);
    }
}