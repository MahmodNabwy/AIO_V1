using AIO.Contracts.IServices.Repositories.Auth.Roles;
using AIO.Core.Entities.Auth.Roles;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Auth.Roles
{
    public class RoleTranslationRepository : GenericRepository<RoleTranslation>, IRoleTranslationRepository
    {
        private readonly AIODBContext _db;
        public RoleTranslationRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

    }
}
