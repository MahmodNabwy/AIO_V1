using Boilerplate.Core.Entities.Languages;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Helpers
{
    public partial class EntityRelation
    {
        public void LanguageRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasMany(d => d.LanguageTranslations)
                   .WithOne(p => p.Language)
                   .HasForeignKey(d => d.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.Name })
                .IsUnique(true);

                entity.HasIndex(a => new { a.Locale })
                .IsUnique(true);
            });

            modelBuilder.Entity<LanguageTranslation>(entity =>
            {
                entity.HasIndex(a => new { a.LanguageId, a.Locale })
                .IsUnique(true);
            });
        }
    }
}
