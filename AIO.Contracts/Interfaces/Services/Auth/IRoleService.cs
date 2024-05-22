using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Auth.Setter.Roles.Role;
using AIO.Contracts.DTOs.Auth.Setter.Roles.RoleUser;
using AIO.Contracts.Filters.Auth;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Auth
{
    public interface IRoleService
    {
        Task<IHolderOfDTO> GetAllAsync();
        Task<IHolderOfDTO> SearchAsync(RoleFilter filter);
        Task<IHolderOfDTO> RoleWithPermissions();
        Task<IHolderOfDTO> UpdateRoleWithPermissionAsync(RoleWithPermissionSetterDTO RoleSetterDTO);
        Task<IHolderOfDTO> AddUserToRoleAsync(RoleUsersRequest UserRolesRequest);
        Task<IHolderOfDTO> GetByIdAsync(string id);
        Task<IHolderOfDTO> UpdateAsync(RoleUpdateSetterDTO RoleSetterDTO);
        Task<IHolderOfDTO> SaveAsync(RoleSetterDTO RoleSetter);
        Task<IHolderOfDTO> Delete(string id);
    }
}
