using Boilerplate.Contracts.DTOs.Setter.AppSettings;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.AppSettings;

public interface IAppSettingService
{
    Task<IHolderOfDTO> GetAllAsync();
    Task<IHolderOfDTO> GetByIdAsync(long id);
    Task<IHolderOfDTO> SaveAsync(AppSettingSetterDTO AppSettingSetterDTO);
    Task<IHolderOfDTO> UpdateAsync(AppSettingUpdateSetterDTO AppSettingSetterDTO);
}
