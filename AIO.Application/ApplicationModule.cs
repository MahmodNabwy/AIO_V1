using Autofac;
using AIO.Application.Services;
using AIO.Application.Services.Agency;
using AIO.Application.Services.AppSettings;
using AIO.Application.Services.Auth;
using AIO.Application.Services.Dashboard;
using AIO.Application.Services.Departments;
using AIO.Application.Services.DepartmentUsers;
using AIO.Application.Services.Elements;
using AIO.Application.Services.EmailSenderService;
using AIO.Application.Services.Languages;
using AIO.Application.Services.LicenceService;
using AIO.Application.Services.Lookups;
using AIO.Application.Services.Migrations;
using AIO.Application.Services.PasswordGeneration;
using AIO.Application.Services.ThumbnailService;
using AIO.Contracts.IServices.Services;
using AIO.Contracts.IServices.Services.AppSettings;
using AIO.Contracts.IServices.Services.Auth;
using AIO.Contracts.IServices.Services.Dashboard;
using AIO.Contracts.IServices.Services.Departments;
using AIO.Contracts.IServices.Services.Elements;
using AIO.Contracts.IServices.Services.EmailSenderService;
using AIO.Contracts.IServices.Services.EncryptionAndDecryption;
using AIO.Contracts.IServices.Services.Languages;
using AIO.Contracts.IServices.Services.Lookups;
using AIO.Contracts.IServices.Services.Migrations;
using AIO.Contracts.IServices.Services.PasswordGeneration;
using AIO.Contracts.IServices.Services.Permissions;
using AIO.Contracts.IServices.Services.ThumbnailService;
using AIO.Contracts.models.ThumbnailModel;

namespace AIO.Application
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