using AIO.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using AIO.Core.Entities.SecurityQuestions;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories
{
    internal class UserSecurityQuestionRepository : GenericRepository<UserSecurityQuestion>, IUserSecurityQuestionRepository
    {
        private readonly AIODBContext _db;
        public UserSecurityQuestionRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }
    }
}
