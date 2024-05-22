using AIO.Contracts.IServices.Repositories.AppSettings;
using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Contracts.IServices.Repositories.Auth.Roles;
using AIO.Contracts.IServices.Repositories.Auth.SecurityQuestions;
using AIO.Contracts.IServices.Repositories.Departments;
using AIO.Contracts.IServices.Repositories.Elements;
using AIO.Contracts.IServices.Repositories.FileUploader;
using AIO.Contracts.IServices.Repositories.Languages;
using AIO.Contracts.IServices.Repositories.Migrations;
using AIO.Core.IServices.Custom.Repositories;
using AIO.Core.IServices.Repositories.Insurance_Conditions;
using AIO.Core.IServices.Repositories.ProjectInsurances;
using AIO.Core.IServices.Repositories.ProjectPaymentMethods;
using Microsoft.EntityFrameworkCore.Storage;

namespace AIO.Core.IServices.Custom
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

        #region Project Insurance
        public IProjectInsuranceRepository ProjectInsurance { get; }

        #endregion

        #region Project Payment Method
        public IProjectPaymentMethodRepository ProjectPaymentMethod { get; }

        #endregion


        #region Insurance_Condition
        public IInsuranceConditionsRepository InsuranceCondition { get; }

        #endregion

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
