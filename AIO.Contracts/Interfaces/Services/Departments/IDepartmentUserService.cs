using AIO.Contracts.DTOs.Setter.Departments.DepartmentUser;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Departments
{
    public interface IDepartmentUserService
    {
        Task<IHolderOfDTO> GetAllAdminAsync();
        Task<IHolderOfDTO> GetByIdAdminAsync(long id);
        Task<IHolderOfDTO> SaveAsync(DepartmentUserSetterDTO setterDTO);
        Task<IHolderOfDTO> SaveBatchAsync(DepartmentUserBatchSetterDTO setterDTO);
        Task<IHolderOfDTO> Update(DepartmentUserUpdateSetterDTO updateDTO);
        Task<IHolderOfDTO> Delete(long id);
        Task<IHolderOfDTO> DeleteSoftAsync(long id);
        Task<IHolderOfDTO> CancelDeleteSoftAsync(long id);
    }
}
