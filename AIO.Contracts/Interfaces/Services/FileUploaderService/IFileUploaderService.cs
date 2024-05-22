using AIO.Contracts.DTOs.Setter.PhotoLibrary;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.MediaUploaderService;

public interface IFileUploaderService
{
    public Task<IHolderOfDTO> UploadFileAsync(PhotoLibrarySetter uploadedFiles);
    public Task<IHolderOfDTO> GetAllImage(int directoryPath, int? fileType);

}