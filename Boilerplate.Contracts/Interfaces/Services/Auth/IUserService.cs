using Boilerplate.Contracts.DTOs.Auth.Setter;
using Boilerplate.Contracts.DTOs.Setter.Files;
using Boilerplate.Contracts.Filters.Auth;
using Boilerplate.Contracts.Interfaces.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Contracts.IServices.Services.Auth
{
    public interface IUserService
    {
        Task<IHolderOfDTO> SearchAsync(UserFilter userFilter);
        Task<IHolderOfDTO> GetAllAsync();
        Task<IHolderOfDTO> GetAllAdminUsersAsync();
        Task<IHolderOfDTO> GetAllEndUsersAsync();
        Task<IHolderOfDTO> GetOnlineUsers(List<string> Ids);
        Task<IHolderOfDTO> GetByIdAsync(string id);
        // public Task<IHolderOfDTO> GetByRefreshTokenAsync(string token);
        Task<IHolderOfDTO> UpdateAsync(UserUpdateSetterDTO userSetterDTO);
        // public IHolderOfDTO Delete(string id);
        Task<IHolderOfDTO> Delete(string id);
        Task<IHolderOfDTO> ProfilePictureAsync(FileSetterDTO fileSetterDTO);
        // public Task<IHolderOfDTO> ProfilePictureRefreshTokenAsync(FileSetterDTO fileSetterDTO);
        Task<IHolderOfDTO> DeleteProfilePictureAsync(string id);
        Task<IHolderOfDTO> DeleteProfilePictureRefreshTokenAsync(string token);
        // public IHolderOfDTO BanUSersByIDs(List<UserSetterDTO> lPostedUsers);
        Task<IHolderOfDTO> GetProfilePic();
        Task<IHolderOfDTO> GetSecurityQuestionByUsername(string username);
        Task<IHolderOfDTO> CheckSecurityQuestionAnswer(string username, string securityAnswer);
        Task<IHolderOfDTO> SetUserProfilePicture(IFormFile file);
        Task<IHolderOfDTO> BanUser(string id);
        Task<IHolderOfDTO> ActiveUser(string id);
        Task<IHolderOfDTO> UnlockedUser(string UserId);
        // public Task<IHolderOfDTO> BannedUser();
        IHolderOfDTO FailedToAddOrUpdateUser(IdentityResult resultUser);
        Task<IHolderOfDTO> CheckBeforAddNewUser(string email, string userName);
        Task<IHolderOfDTO> AddNewEmployeeAsync(UserSetterDTO setterDTO);
        //  Task AddHistoricalDataOfUser(User user);
    }
}
