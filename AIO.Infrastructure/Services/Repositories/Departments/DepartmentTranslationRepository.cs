using AIO.Contracts.IServices.Repositories.Departments;
using AIO.Core.Entities.Departments;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Departments
{
    internal class DepartmentTranslationRepository : GenericRepository<DepartmentTranslation>, IDepartmentTranslationRepository
    {
        private readonly AIODBContext _db;
        public DepartmentTranslationRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
