using AIO.Contracts.DTOs.Setter.AppSettings;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.AppSettings;

public interface IAppSettingService
{
    Task<IHolderOfDTO> GetAllAsync();
    Task<IHolderOfDTO> GetByIdAsync(long id);
    Task<IHolderOfDTO> SaveAsync(AppSettingSetterDTO AppSettingSetterDTO);
    Task<IHolderOfDTO> UpdateAsync(AppSettingUpdateSetterDTO AppSettingSetterDTO);
}
