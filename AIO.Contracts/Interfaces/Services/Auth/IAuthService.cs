using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Auth.Setter.ForgetPassword;
using AIO.Contracts.DTOs.Auth.Setter.Roles.RoleUser;
using AIO.Contracts.Interfaces.Custom;

namespace AIO.Contracts.IServices.Services.Auth
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
