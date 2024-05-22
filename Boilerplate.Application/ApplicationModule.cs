using Autofac;
using Boilerplate.Application.Services;
using Boilerplate.Application.Services.Agency;
using Boilerplate.Application.Services.AppSettings;
using Boilerplate.Application.Services.Auth;
using Boilerplate.Application.Services.Dashboard;
using Boilerplate.Application.Services.Departments;
using Boilerplate.Application.Services.DepartmentUsers;
using Boilerplate.Application.Services.Elements;
using Boilerplate.Application.Services.EmailSenderService;
using Boilerplate.Application.Services.Languages;
using Boilerplate.Application.Services.LicenceService;
using Boilerplate.Application.Services.Lookups;
using Boilerplate.Application.Services.Migrations;
using Boilerplate.Application.Services.PasswordGeneration;
using Boilerplate.Application.Services.ThumbnailService;
using Boilerplate.Contracts.IServices.Services;
using Boilerplate.Contracts.IServices.Services.AppSettings;
using Boilerplate.Contracts.IServices.Services.Auth;
using Boilerplate.Contracts.IServices.Services.Dashboard;
using Boilerplate.Contracts.IServices.Services.Departments;
using Boilerplate.Contracts.IServices.Services.Elements;
using Boilerplate.Contracts.IServices.Services.EmailSenderService;
using Boilerplate.Contracts.IServices.Services.EncryptionAndDecryption;
using Boilerplate.Contracts.IServices.Services.Languages;
using Boilerplate.Contracts.IServices.Services.Lookups;
using Boilerplate.Contracts.IServices.Services.Migrations;
using Boilerplate.Contracts.IServices.Services.PasswordGeneration;
using Boilerplate.Contracts.IServices.Services.Permissions;
using Boilerplate.Contracts.IServices.Services.ThumbnailService;
using Boilerplate.Contracts.models.ThumbnailModel;

namespace Boilerplate.Application
{
    public class ApplicationModule : Module
    {
        // IOC Container Method
        protected override void Load(ContainerBuilder builder)
        {

            #region Auth, Role, User

            builder.RegisterType<AuthService>().As<IAuthService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleService>().As<IRoleService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Department

            builder.RegisterType<DepartmentService>().As<IDepartmentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DepartmentUserService>().As<IDepartmentUserService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Permissions and Licence

            builder.RegisterType<PermissionService>().As<IPermissionService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PermissionModuleService>().As<IPermissionModuleService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<LicenceService>().As<ILicenceService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Language and Menu

            builder.RegisterType<LanguageService>().As<ILanguageService>()
                .InstancePerLifetimeScope();
            #endregion

            #region Dashboard
            builder.RegisterType<DashboardService>().As<IDashboardServices>()
              .InstancePerLifetimeScope();
            #endregion

            #region PasswordGeneration

            builder.RegisterType<PasswordGenerationService>().As<IPasswordGenerationService>().SingleInstance();

            #endregion

            #region Element

            builder.RegisterType<ElementService>().As<IElementService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Lookups

            builder.RegisterType<LookupService>().As<ILookupService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Migrations

            builder.RegisterType<MigrationService>().As<IMigrationService>()
                .InstancePerLifetimeScope();

            #endregion

            #region Encryption And Decryption
            builder.RegisterType<EncryptionAndDecryptionService>().As<IEncryptionAndDecryptionService>()
                .InstancePerLifetimeScope();
            #endregion

            #region EmailTempletService
            builder.RegisterType<EmailTempletService>().As<IEmailTempleteService>()
                .InstancePerLifetimeScope();
            #endregion

            #region EmailSenderService
            builder.RegisterType<EmailSenderService>().As<IEmailSenderService>()
                .InstancePerLifetimeScope();
            #endregion

            #region AppSettingService
            builder.RegisterType<AppSettingService>().As<IAppSettingService>()
                .InstancePerLifetimeScope();
            #endregion
            //#region AppSettingService
            //builder.RegisterType<Mediator>().As<IMediator>()
            //    .InstancePerLifetimeScope();
            //#endregion 

            #region ThumbnailService

            builder.RegisterType<ImageThumbnailService>().As<IThumbnailService<ImageThumbnailData>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PDFThumbnailService>().As<IThumbnailService<PdfThumbnailData>>()
                .InstancePerLifetimeScope();

            #endregion
        }
    }
}