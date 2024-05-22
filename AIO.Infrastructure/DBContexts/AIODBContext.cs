using AIO.Core.Entities;
using AIO.Core.Entities.AppSettings;
using AIO.Core.Entities.Auth;
using AIO.Core.Entities.Auth.Roles;
using AIO.Core.Entities.Departments;
using AIO.Core.Entities.Elements;
using AIO.Core.Entities.FilesLibrary;
using AIO.Core.Entities.Languages;
using AIO.Core.Entities.Migrations;
using AIO.Infrastructure.Configuration;
using AIO.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AIO.Infrastructure.DBContexts
{
    public class AIODBContext : IdentityDbContext<User>
    {
        public AIODBContext(DbContextOptions<AIODBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Ignore Identity Tables
            //builder.Ignore<IdentityRole>();
            //builder.Ignore<IdentityUser<string>>();
            //  builder.Ignore<IdentityUserRole<string>>();
            //builder.Ignore<IdentityUserToken<string>>();
            //builder.Ignore<IdentityUserLogin<string>>();
            //builder.Ignore<IdentityUserClaim<string>>();
            //builder.Ignore<IdentityRoleClaim<string>>();
            #endregion


            #region Identity
            //builder.Entity<User>()
            //    .ToTable("users", "security");
            //builder.Entity<Role>()
            //   .ToTable("roles", "security");
            //builder.Entity<UserRole>()
            //    .ToTable("user_roles", "security");
            //builder.Entity<IdentityUserClaim<string>>()
            //    .ToTable("user_claims", "security");
            //builder.Entity<IdentityUserLogin<string>>()
            //    .ToTable("user_logins", "security");
            //builder.Entity<IdentityUserToken<string>>()
            //    .ToTable("user_tokens", "security");
            //builder.Entity<IdentityRoleClaim<string>>()
            //    .ToTable("role_claims", "security");
            #endregion

            builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            new MicrosoftIdentityConfiguration(builder);

            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #region Seed Data
            new SeedData(builder);
            #endregion


            #region Entity Relation
            new EntityRelation(builder);
            #endregion


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #region DB Sets

        public virtual DbSet<UserRole> UserRoles { get; set; }

        #region Logs
        //  public virtual DbSet<LogSystem> LogSystems { get; set; }
        //public virtual DbSet<LogError> LogErrors { get; set; }
        #endregion

        #region Licence and UserGroups
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentUser> DepartmentUsers { get; set; }

        //public virtual DbSet<Licence> Licences { get; set; }
        // public virtual DbSet<TimeLog> TimeLogs { get; set; }
        //public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }
        // public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        //public virtual DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
        #endregion

        #region Permissions
        public virtual DbSet<PermissionModule> PermissionModules { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        #endregion

        #region Languages 
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageTranslation> LanguageTranslations { get; set; }
        #endregion

        #region FileLibrary
        public virtual DbSet<FilesLibrary> FilesLibraries { get; set; }
        #endregion

        #region Elements
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<ElementTranslation> ElementTranslations { get; set; }
        #endregion

        #region AppSettings
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        #endregion

        #region Migration
        public virtual DbSet<Migration> Migrations { get; set; }
        #endregion

        #endregion

    }


    public class BoilerplateDBContextFactory : IDesignTimeDbContextFactory<AIODBContext>
    {
        public AIODBContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var optionsBuilder = new DbContextOptionsBuilder<AIODBContext>();
            var connectionString = builder.Configuration.GetConnectionString("BoilerplateConnectionString");
            optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
            return new AIODBContext(optionsBuilder.Options);

        }
    }
}
