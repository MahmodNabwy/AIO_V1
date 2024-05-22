using Boilerplate.Contracts.IServices.Repositories.Auth;
using Boilerplate.Core.Entities.Auth;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories
{
    internal class ProfilePictureRepository : GenericRepository<ProfilePicture>, IProfilePictureRepository
    {
        private readonly BoilerplateDBContext _db;
        public ProfilePictureRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }


    }
}
