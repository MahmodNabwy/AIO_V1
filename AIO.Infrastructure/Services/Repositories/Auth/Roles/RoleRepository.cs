using AIO.Contracts.Filters.Auth;
using AIO.Contracts.IServices.Repositories.Auth.Roles;
using AIO.Core.Entities.Auth.Roles;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Auth.Roles
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AIODBContext _db;
        public RoleRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

        public IQueryable<object> buildRoleQuery(RoleFilter roleFilter)
        {
            var query = Query();
            if (roleFilter is not null)
            {
                try
                {
                    // Where
                    if (!string.IsNullOrEmpty(roleFilter.Id))
                        query = query.Where(x => x.Id == roleFilter.Id);

                    if (!string.IsNullOrEmpty(roleFilter.Name))
                        query = query.Where(x => x.Name.Contains(roleFilter.Name));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return query;
        }
    }
}
