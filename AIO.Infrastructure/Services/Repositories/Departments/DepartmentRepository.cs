using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Repositories.Departments;
using AIO.Core.Entities.Departments;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Services.Repositories.Departments
{
    internal class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AIODBContext _db;
        public DepartmentRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }
        public IQueryable<Department> GetAllAdmin()
        {
            var query = _db.Departments
                .Include(q => q.DepartmentTranslations)
                .Include(q => q.MainDepartment).Include(q => q.DepartmentTranslations)
                .AsQueryable();

            return query;
        }
        public Department GetByIdAdmin(int id)
        {
            var query = _db.Departments
                .Where(q => q.Id == id)
                .Include(q => q.DepartmentTranslations)
                .Include(q => q.MainDepartment).Include(q => q.DepartmentTranslations)
                .AsQueryable();

            return query.FirstOrDefault();
        }
        public IQueryable<Department> buildFilterAdminQuery(DepartmentAdminFilter filter)
        {
            var query = _db.Departments
                .Include(q => q.DepartmentTranslations)
                .AsQueryable();
            if (filter is not null)
            {
                try
                {
                    if (filter.Id != null && filter.Id > 0)
                        query = query.Where(x => x.DepartmentTranslations.Any(q => q.Id == filter.Id) || x.Id == filter.Id);

                    if (!string.IsNullOrEmpty(filter.Name))
                        query = query.Where(x => x.DepartmentTranslations.Any(q => q.Name.Contains(filter.Name)) || x.Name.Contains(filter.Name));

                    if (filter.IsDeleted != null)
                        query = query.Where(x => x.IsDeleted == filter.IsDeleted);

                    if (filter.ParentId != null)
                        query = query.Where(x => x.ParentId == filter.ParentId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return query;
        }

    }
}
