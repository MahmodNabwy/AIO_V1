using Boilerplate.Core.Entities.Departments;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Helpers
{
    public partial class EntityRelation
    {
        public void DepartmentUserRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentUser>(entity =>
            {
                entity.HasIndex(a => new { a.UserId, a.DepartmentId })
                  .IsUnique(true);
            });
        }
    }
}
