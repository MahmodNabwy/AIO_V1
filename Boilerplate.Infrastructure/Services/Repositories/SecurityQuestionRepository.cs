using Boilerplate.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using Boilerplate.Core.Entities.SecurityQuestions;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories
{
    internal class SecurityQuestionRepository : GenericRepository<SecurityQuestion>, ISecurityQuestionRepository
    {
        private readonly BoilerplateDBContext _db;
        public SecurityQuestionRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }


    }
}
