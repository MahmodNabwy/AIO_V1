using Boilerplate.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using Boilerplate.Core.Entities.SecurityQuestions;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories
{
    internal class UserSecurityQuestionRepository : GenericRepository<UserSecurityQuestion>, IUserSecurityQuestionRepository
    {
        private readonly BoilerplateDBContext _db;
        public UserSecurityQuestionRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }
    }
}
