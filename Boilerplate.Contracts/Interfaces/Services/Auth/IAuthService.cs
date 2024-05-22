using Boilerplate.Contracts.DTOs.Auth.Setter;
using Boilerplate.Contracts.DTOs.Auth.Setter.ForgetPassword;
using Boilerplate.Contracts.DTOs.Auth.Setter.Roles.RoleUser;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.Auth
{
    public interface IAuthService
    {
        Task<IHolderOfDTO> RegisterUserAsync(UserRegisterSetterDTO userRegisterSetterDTO);
        Task<IHolderOfDTO> AutoLoginAsync();
        Task<IHolderOfDTO> AutoLoginAdminAsync();
        Task<IHolderOfDTO> LoginAsync(UserLoginSetterDTO setterDTO);
        Task<IHolderOfDTO> LoginAdminAsync(UserLoginSetterDTO setterDTO);
        Task<IHolderOfDTO> RefreshTokensAsync(string refreshToken);
        Task<IHolderOfDTO> ChangePasswordAsync(ChangePasswordSetterDTO setterDTO);
        Task<IHolderOfDTO> ForgotPasswordAsync(ForgetPasswordSetterDTO setterDTO);
        Task<IHolderOfDTO> EnterResetCodeAsync(ResetCodeSetterDTO setterDTO);
        Task<IHolderOfDTO> ResetPasswordAsync(ResetPasswordSetterDTO setterDTO);
        Task<IHolderOfDTO> AddUserToRoleAsync(RoleUserSetterDTO userRoleSetterDTO);
        Task<IHolderOfDTO> GetRoleUsersAsync(string roleName);
        Task<IHolderOfDTO> EmailConfirmationAsync(EmailConfirmationSetterDTO emailConfirmationSetterDTO);
        Task<IHolderOfDTO> ResendEmailConfirmationCodeAsync(PersonalKeySetterDTO personalKeySetterDTO);
        Task<IHolderOfDTO> AutoLoginAsync(string refreshToken);
    }
}
