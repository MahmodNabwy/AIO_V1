using AIO.Core.Entities.Elements;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Helpers
{
    public partial class EntityRelation
    {
        public void ElementRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasIndex(a => new { a.key })
                .IsUnique(true);

                entity.HasMany(d => d.ElementTranslations)
                   .WithOne(p => p.Element)
                   .HasForeignKey(d => d.ElementId)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ElementTranslation>(entity =>
            {
                entity.HasIndex(a => new { a.ElementId, a.Locale })
                .IsUnique(true);
            });
        }
    }
}
