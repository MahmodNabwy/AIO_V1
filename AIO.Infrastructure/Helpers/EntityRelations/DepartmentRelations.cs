using AIO.Core.Entities.Departments;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Helpers
{
    public partial class EntityRelation
    {
        public void DepartmentRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasMany(d => d.DepartmentTranslations)
                   .WithOne(p => p.Department)
                   .HasForeignKey(d => d.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.Name })
                  .IsUnique(true);
            });

            modelBuilder.Entity<DepartmentTranslation>(entity =>
            {
                entity.HasIndex(a => new { a.DepartmentId, a.Locale })
                .IsUnique(true);
            });
        }
    }
}
