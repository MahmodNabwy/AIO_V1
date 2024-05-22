using Boilerplate.Contracts.DTOs.Setter.PhotoLibrary;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.MediaUploaderService;

public interface IFileUploaderService
{
    public Task<IHolderOfDTO> UploadFileAsync(PhotoLibrarySetter uploadedFiles);
    public Task<IHolderOfDTO> GetAllImage(int directoryPath, int? fileType);

}