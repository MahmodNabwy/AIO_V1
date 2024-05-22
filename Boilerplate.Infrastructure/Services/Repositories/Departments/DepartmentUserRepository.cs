using Boilerplate.Contracts.IServices.Repositories.Departments;
using Boilerplate.Core.Entities.Departments;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories.Departments
{
    internal class DepartmentUserRepository : GenericRepository<DepartmentUser>, IDepartmentUserRepository
    {
        private readonly BoilerplateDBContext _db;
        public DepartmentUserRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }
    }
}
