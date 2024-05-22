using AIO.Contracts.IServices.Repositories.Departments;
using AIO.Core.Entities.Departments;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Departments
{
    internal class DepartmentUserRepository : GenericRepository<DepartmentUser>, IDepartmentUserRepository
    {
        private readonly AIODBContext _db;
        public DepartmentUserRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }
    }
}
