using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Departments;

namespace AIO.Contracts.IServices.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        IQueryable<Department> GetAllAdmin();
        Department GetByIdAdmin(long id);
        IQueryable<Department> buildFilterAdminQuery(DepartmentAdminFilter filter);
    }

}