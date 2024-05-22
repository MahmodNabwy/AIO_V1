using AIO.Contracts.DTOs.Setter.Languages.Language;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Languages
{
    public interface ILanguageService
    {
        Task<IHolderOfDTO> GetAllAsync();
        Task<IHolderOfDTO> GetAllAdminAsync();
        Task<IHolderOfDTO> GetByIdAsync(long id);
        Task<IHolderOfDTO> GetByIdAdminAsync(long id);
        Task<IHolderOfDTO> SaveAsync(LanguageSetterDTO LanguageSetterDTO);
        Task<IHolderOfDTO> Update(LanguageUpdateSetterDTO LanguageSetterDTO);
        IHolderOfDTO Delete(long id);
        Task<IHolderOfDTO> DeleteSoftAsync(long id);
        Task<IHolderOfDTO> CancelDeleteSoftAsync(long id);

    }
}
