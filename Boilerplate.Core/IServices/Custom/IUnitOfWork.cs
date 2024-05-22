using Boilerplate.Contracts.IServices.Repositories.AppSettings;
using Boilerplate.Contracts.IServices.Repositories.Auth;
using Boilerplate.Contracts.IServices.Repositories.Auth.Roles;
using Boilerplate.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using Boilerplate.Contracts.IServices.Repositories.Departments;
using Boilerplate.Contracts.IServices.Repositories.Elements;
using Boilerplate.Contracts.IServices.Repositories.FileUploader;
using Boilerplate.Contracts.IServices.Repositories.Languages;
using Boilerplate.Contracts.IServices.Repositories.Migrations;
using Boilerplate.Core.IServices.Custom.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Boilerplate.Core.IServices.Custom
{
    public interface IUnitOfWork : IDisposable
    {
        public IRoleRepository Roles { get; }
        public IRoleTranslationRepository RoleTranslations { get; }
        public IUserRepository Users { get; }
        public ISecurityQuestionRepository SecurityQuestions { get; }
        public IUserSecurityQuestionRepository UserSecurityQuestions { get; }
        public IUserRoleRepository UserRoles { get; }
        public ILicenceRepository Licences { get; }
        public ITimeLogRepository TimeLogs { get; }
        public IProfilePictureRepository ProfilePicture { get; }

        #region Departments
        public IDepartmentRepository Department { get; }
        public IDepartmentTranslationRepository DepartmentTranslation { get; }
        public IDepartmentUserRepository DepartmentUser { get; }
        #endregion

        #region Permission
        public IPermissionModuleRepository PermissionModule { get; }
        public IRolePermissionRepository RolePermission { get; }
        #endregion

        #region Language
        public ILanguageRepository Language { get; }
        public ILanguageTranslationRepository LanguageTranslation { get; }
        #endregion

        #region Log
        public ILogSystemRepository LogSystem { get; }
        public ILogErrorRepository LogError { get; }
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

        public IDbContextTransaction Transaction();
        public int Complete();
        void ChangeTracker();
    }
}
