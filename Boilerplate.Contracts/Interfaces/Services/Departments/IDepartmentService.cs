using Boilerplate.Contracts.DTOs.Setter.Departments.Department;
using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IHolderOfDTO> GetAllAdminAsync();
        Task<IHolderOfDTO> GetByIdAdminAsync(long id);
        IHolderOfDTO SearchAdminAsync(DepartmentAdminFilter filter);
        Task<IHolderOfDTO> SaveAsync(DepartmentSetterDTO setterDTO);
        Task<IHolderOfDTO> Update(DepartmentUpdateSetterDTO updateDTO);
        Task<IHolderOfDTO> Delete(long id);
        Task<IHolderOfDTO> DeleteSoftAsync(long id);
        Task<IHolderOfDTO> CancelDeleteSoftAsync(long id);
    }
}
