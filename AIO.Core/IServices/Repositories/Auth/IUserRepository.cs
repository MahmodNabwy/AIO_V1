using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.Filters.Auth;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Auth;

namespace AIO.Contracts.IServices.Repositories.Auth
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
        public List<string> SelectUserGroup(List<int> GroupsIds);
        public string GetNameById(string Id);
        Task<int> GetUsersCount();
        Task<List<int>> UserDepartmentIds(string userId);
        Task<bool> IsAdmin(string userId);
    }
}
