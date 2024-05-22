using AIO.Contracts.Helpers;
using AIO.Contracts.IServices.Repositories.AppSettings;
using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Contracts.IServices.Repositories.Auth.Roles;
using AIO.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using AIO.Contracts.IServices.Repositories.Departments;
using AIO.Contracts.IServices.Repositories.Elements;
using AIO.Contracts.IServices.Repositories.FileUploader;
using AIO.Contracts.IServices.Repositories.Languages;
using AIO.Contracts.IServices.Repositories.Migrations;
using AIO.Core.IServices.Custom;
using AIO.Core.IServices.Custom.Repositories;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Repositories.Custom.Log_System;
using AIO.Infrastructure.Services.Repositories;
using AIO.Infrastructure.Services.Repositories.AppSettings;
using AIO.Infrastructure.Services.Repositories.Auth;
using AIO.Infrastructure.Services.Repositories.Auth.Roles;
using AIO.Infrastructure.Services.Repositories.Departments;
using AIO.Infrastructure.Services.Repositories.Elements;
using AIO.Infrastructure.Services.Repositories.FileUploader;
using AIO.Infrastructure.Services.Repositories.Languages;
using AIO.Infrastructure.Services.Repositories.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AIO.Infrastructure.Services.Custom
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AIODBContext _context;

        public IRoleRepository Roles { get; private set; }
        public IRoleTranslationRepository RoleTranslations { get; }
        public IUserRepository Users { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        public ILicenceRepository Licences { get; private set; }
        public ITimeLogRepository TimeLogs { get; private set; }
        public ISecurityQuestionRepository SecurityQuestions { get; }
        public IUserSecurityQuestionRepository UserSecurityQuestions { get; }
        public IProfilePictureRepository ProfilePicture { get; private set; }


        #region  Permissions
        public IPermissionModuleRepository PermissionModule { get; private set; }
        public IRolePermissionRepository RolePermission { get; private set; }
        #endregion

        #region Language
        public ILanguageRepository Language { get; private set; }
        public ILanguageTranslationRepository LanguageTranslation { get; private set; }
        #endregion

        #region Departments
        public IDepartmentRepository Department { get; private set; }
        public IDepartmentTranslationRepository DepartmentTranslation { get; }
        public IDepartmentUserRepository DepartmentUser { get; private set; }
        #endregion

        #region Log
        public ILogSystemRepository LogSystem { get; private set; }
        public ILogErrorRepository LogError { get; private set; }
        #endregion

        #region Elements
        public IElementRepository Elements { get; }
        public IElementTranslationRepository ElementTranslations { get; }
        #endregion

        #region AppSettings
        public IAppSettingRepository AppSettings { get; }
        #endregion

        #region Migrations
        public IMigrationRepository Migrations { get; }
        #endregion

        public IFileUploaderRepository FileUploader { get; }

        public UnitOfWork(AIODBContext context)
        {
            _context = context;

            #region Role
            Roles = new RoleRepository(_context);
            RoleTranslations = new RoleTranslationRepository(_context);
            #endregion

            #region User
            Users = new UserRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            ProfilePicture = new ProfilePictureRepository(_context);
            #endregion

            Licences = new LicenceRepository(_context);
            TimeLogs = new TimeLogRepository(_context);

            #region Departments
            Department = new DepartmentRepository(_context);
            DepartmentTranslation = new DepartmentTranslationRepository(_context);
            DepartmentUser = new DepartmentUserRepository(_context);
            #endregion

            #region Permissions
            PermissionModule = new PermissionModuleRepository(_context);
            RolePermission = new RolePermissionRepository(_context);
            #endregion

            #region Language
            Language = new LanguageRepository(_context);
            LanguageTranslation = new LanguageTranslationRepository(_context);
            #endregion

            #region log
            LogError = new LogErrorRepository(_context);
            LogSystem = new LogSystemRepository(_context);
            #endregion

            FileUploader = new FileUploaderRepository(_context);

            #region Elements
            Elements = new ElementRepository(_context);
            ElementTranslations = new ElementTranslationRepository(_context);
            #endregion

            #region AppSettings
            AppSettings = new AppSettingRepository(_context);
            #endregion

            #region SecurityQuestions
            SecurityQuestions = new SecurityQuestionRepository(_context);
            #endregion

            #region UserSecurityQuestions
            UserSecurityQuestions = new UserSecurityQuestionRepository(_context);
            #endregion

            #region Migrations
            Migrations = new MigrationRepository(_context);
            #endregion

        }
        public IDbContextTransaction Transaction()
        {
            return _context.Database.BeginTransaction();
        }

        public int Complete()
        {
            onBeforeSaving();
            return _context.SaveChanges();
        }
        public void ChangeTracker()
        {
            _context.ChangeTracker.Clear();
        }
        public bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
        protected virtual void onBeforeSaving()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (HasProperty(entry.Entity, "CreatedAt"))
                    {
                        entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    }
                    if (HasProperty(entry.Entity, "CreatedBy"))
                    {
                        entry.Property("CreatedBy").CurrentValue = UserDetails.userId;
                    }
                    if (HasProperty(entry.Entity, "UpdatedAt"))
                    {
                        entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    }
                    if (HasProperty(entry.Entity, "UpdatedBy"))
                    {
                        entry.Property("UpdatedBy").CurrentValue = UserDetails.userId;
                    }
                }
                if (entry.State == EntityState.Modified)
                {
                    if (HasProperty(entry.Entity, "CreatedAt"))
                    {
                        entry.Property("CreatedAt").IsModified = false;
                    }
                    if (HasProperty(entry.Entity, "CreatedBy"))
                    {
                        entry.Property("CreatedBy").IsModified = false;
                    }
                    if (HasProperty(entry.Entity, "UpdatedAt"))
                    {
                        entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    }
                    if (HasProperty(entry.Entity, "UpdatedBy"))
                    {
                        entry.Property("UpdatedBy").CurrentValue = UserDetails.userId;
                    }
                }
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
