using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.IServices.Custom;
using Boilerplate.Core.Entities.Departments;

namespace Boilerplate.Contracts.IServices.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        IQueryable<Department> GetAllAdmin();
        Department GetByIdAdmin(long id);
        IQueryable<Department> buildFilterAdminQuery(DepartmentAdminFilter filter);
    }

}