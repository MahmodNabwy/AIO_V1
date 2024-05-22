using Boilerplate.Contracts.IServices.Repositories.AppSettings;
using Boilerplate.Core.Entities.AppSettings;
using Boilerplate.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Services.Repositories.AppSettings;
public class AppSettingRepository : GenericRepository<AppSetting>, IAppSettingRepository
{
    public AppSettingRepository(DbContext context) : base(context)
    {
    }
}
