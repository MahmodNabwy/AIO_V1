using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Core.Entities.Auth;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Auth
{
    public class LicenceRepository : GenericRepository<Licence>, ILicenceRepository
    {
        private readonly AIODBContext _db;
        public LicenceRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

    }
}
