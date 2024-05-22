using Boilerplate.Contracts.DTOs.Auth.Setter;
using Boilerplate.Contracts.Filters.Auth;
using Boilerplate.Contracts.IServices.Custom;
using Boilerplate.Core.Entities.Auth;

namespace Boilerplate.Contracts.IServices.Repositories.Auth
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<IQueryable<User>> buildUserQueryAsync(UserFilter userFilter);
        Task<User> GetUserByIdAdminQuery(string id);
        public bool UpdateBatch(List<User> lUsers);
        public Task<List<User>> GetAllUsers();
        public Task<List<User>> GetOnlineUsers(List<string> Ids);
        Task<List<User>> GetAllEndUsers();
        Task<List<User>> GetAllAdminUsers();
        public List<User> BanUSersByIDs(List<UserSetterDTO> lPostedUsers);
        public List<User> SelectUsersByIDs(List<string> lUsersIDs);
        public List<string> SelectUserGroup(List<long> GroupsIds);
        public string GetNameById(string Id);
        Task<int> GetUsersCount();
        Task<List<long>> UserDepartmentIds(string userId);
        Task<bool> IsAdmin(string userId);
    }
}
