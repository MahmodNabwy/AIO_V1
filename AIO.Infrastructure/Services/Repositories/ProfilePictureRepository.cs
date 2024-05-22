using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Core.Entities.Auth;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories
{
    internal class ProfilePictureRepository : GenericRepository<ProfilePicture>, IProfilePictureRepository
    {
        private readonly AIODBContext _db;
        public ProfilePictureRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
