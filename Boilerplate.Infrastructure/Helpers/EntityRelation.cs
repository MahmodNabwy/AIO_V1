using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Helpers
{
    public partial class EntityRelation
    {
        public EntityRelation(ModelBuilder modelBuilder)
        {
            CreateRelationBetweenEntityAndDefaultValues(modelBuilder);
        }
        private void CreateRelationBetweenEntityAndDefaultValues(ModelBuilder modelBuilder)
        {

            DepartmentRelations(modelBuilder);

            DepartmentUserRelations(modelBuilder);

            ElementRelations(modelBuilder);

            LanguageRelations(modelBuilder);

            RoleRelations(modelBuilder);

            UserRelations(modelBuilder);

            UserRoleRelations(modelBuilder);

        }
    }
}
