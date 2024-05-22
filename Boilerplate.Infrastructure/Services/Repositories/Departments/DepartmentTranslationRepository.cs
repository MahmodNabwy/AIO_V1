using Boilerplate.Contracts.IServices.Repositories.Departments;
using Boilerplate.Core.Entities.Departments;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories.Departments
{
    internal class DepartmentTranslationRepository : GenericRepository<DepartmentTranslation>, IDepartmentTranslationRepository
    {
        private readonly BoilerplateDBContext _db;
        public DepartmentTranslationRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }


    }
}
