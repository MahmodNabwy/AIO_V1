using Boilerplate.Contracts.DTOs.Auth.Setter;
using Boilerplate.Contracts.Enums;
using Boilerplate.Contracts.Filters.Auth;
using Boilerplate.Contracts.IServices.Repositories.Auth;
using Boilerplate.Core.Entities.Auth;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;
using Boilerplate.Shared.Consts;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Services.Repositories.Auth
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly BoilerplateDBContext _db;

        public UserRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }
        public async Task<User> GetUserByIdAdminQuery(string id)
        {
            var query = _db.Users
                .AsNoTracking()
                .Where(q => q.Id == id)
                 .Include(q => q.UserRoles).ThenInclude(q => q.Role).ThenInclude(q => q.RoleTranslations)
                 .Include(q => q.UserGroups).ThenInclude(q => q.Department).ThenInclude(q => q.DepartmentTranslations)
                 .AsQueryable();

            return query.FirstOrDefault();
        }
        public async Task<IQueryable<User>> buildUserQueryAsync(UserFilter userFilter)
        {
            var query = _db.Users
                .AsNoTracking()
                 .Include(q => q.UserRoles).ThenInclude(q => q.Role).ThenInclude(q => q.RoleTranslations)
                 .Include(q => q.UserGroups).ThenInclude(q => q.Department).ThenInclude(q => q.DepartmentTranslations)
                 .AsQueryable();

            if (userFilter is not null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(userFilter.Id))
                        query = query.Where(x => x.Id == userFilter.Id);

                    if (!string.IsNullOrEmpty(userFilter.FullName))
                        query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(userFilter.FullName));

                    if (!string.IsNullOrEmpty(userFilter.Username))
                        query = query.Where(x => x.UserName.Contains(userFilter.Username));

                    if (!string.IsNullOrEmpty(userFilter.Email))
                        query = query.Where(x => x.Email.Contains(userFilter.Email));

                    if (!string.IsNullOrEmpty(userFilter.PhoneNumber))
                        query = query.Where(x => x.PhoneNumber.Contains(userFilter.PhoneNumber));

                    if (userFilter.Gender != null)
                        query = query.Where(x => x.Gender == (Gender)userFilter.Gender);

                    if (userFilter.IsBanned != null)
                        query = query.Where(x => x.IsBanned == userFilter.IsBanned);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //var finalQuery = query.Select(x => new User()
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    UserName = x.UserName,
            //    Email = x.Email,
            //    PhoneNumber = x.PhoneNumber,
            //    AccessFailedCount = x.AccessFailedCount,
            //    Path = x.Path,
            //    Gender = x.Gender,
            //    IsBanned = x.IsBanned

            //});
            //finalQuery = finalQuery.Distinct();
            return query;
        }
        public string GetNameById(string Id)
        {
            var Name = _db.Users.Where(u => u.Id == Id && !u.IsBanned).Select(q => q.FullName).First();
            return Name;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var lUsers = await _db.Users
                .AsNoTracking()
                .Include(q => q.UserGroups).ThenInclude(q => q.Department).ThenInclude(q => q.DepartmentTranslations)
                .Include(q => q.UserRoles).ThenInclude(q => q.Role).ThenInclude(q => q.RoleTranslations)
                .ToListAsync();
            return lUsers;
        }
        public async Task<List<User>> GetAllEndUsers()
        {
            var lUsers = await _db.Users
                // .Where(q => q.SubscriptionTypeId != null)
                .AsNoTracking()
                .ToListAsync();
            return lUsers;
        }
        public async Task<List<User>> GetAllAdminUsers()
        {
            var lUsers = await _db.Users
                //.Where(q => q.SubscriptionTypeId == null).AsNoTracking()
                // .Include(q => q.UserGroups).ThenInclude(q => q.Department).ThenInclude(q => q.DepartmentTranslations)
                .ToListAsync();
            return lUsers;
        }
        public async Task<List<User>> GetOnlineUsers(List<string> Ids)
        {
            var lUsers = await _db.Users.AsNoTracking().Where(q => Ids.Contains(q.Id))
                .Include(q => q.UserGroups)
                .ThenInclude(q => q.Department)
                .Include(q => q.UserRoles)
                .ToListAsync();
            return lUsers;
        }
        public async Task<bool> IsAdmin(string userId)
        {
            var userRole = _db.UserRoles.Where(q => q.UserId == userId && (q.RoleId == RoleIds.SuperAdmin || q.RoleId == RoleIds.Admin));
            return userRole.Count() > 0 ? true : false;
        }

        public bool UpdateBatch(List<User> lUsers)
        {
            try
            {
                foreach (User oUser in lUsers)
                {
                    _db.Entry(oUser).State = EntityState.Modified;
                }
                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<User> SelectUsersByIDs(List<string> lUsersIDs)
        {
            List<User> lUsers = new List<User>();

            try
            {
                lUsers = _db.Users.Where(u => lUsersIDs.Contains(u.Id)).ToList();
            }
            catch (Exception)
            {

            }

            return lUsers;
        }

        public List<User> BanUSersByIDs(List<UserSetterDTO> lPostedUsers)
        {
            throw new NotImplementedException();
        }
        public List<string> SelectUserGroup(List<long> GroupsIds)
        {
            var UsersIds = _db.DepartmentUsers.Where(q => GroupsIds.Contains(q.DepartmentId)).Select(x => x.UserId).Distinct().ToList();
            return UsersIds;
        }

        public async Task<int> GetUsersCount()
        {
            var count = await _db.Users.AsNoTracking()
                                       .Where(q => !q.IsBanned && q.IsVerified)
                                       .CountAsync();
            return count;
        }

        public async Task<List<long>> UserDepartmentIds(string userId)
        {
            var departments = _db.DepartmentUsers.Where(q => q.UserId == userId).Select(x => x.DepartmentId).Distinct().ToList();
            var childDepartment = _db.Departments.Where(q => departments.Contains(q.ParentId.Value)).Select(x => x.Id).Distinct().ToList();
            departments.AddRange(childDepartment);
            return departments.Distinct().ToList();
        }


    }
}
