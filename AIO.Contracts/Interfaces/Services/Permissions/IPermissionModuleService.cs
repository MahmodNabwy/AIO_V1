using AIO.Contracts.DTOs.Setter;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Permissions
{
    public interface IPermissionModuleService
    {
        public Task<IHolderOfDTO> GetAllAsync();
        public Task<IHolderOfDTO> GetByIdAsync(long id);
        public Task<IHolderOfDTO> SaveAsync(PermissionModuleSetterDTO PermissionModuleSetterDTO);
        public IHolderOfDTO Update(PermissionModuleUpdateSetterDTO PermissionModuleSetterDTO);
        public IHolderOfDTO Delete(long id);
    }
}
