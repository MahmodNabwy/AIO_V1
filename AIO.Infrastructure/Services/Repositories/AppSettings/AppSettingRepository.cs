using AIO.Contracts.IServices.Repositories.AppSettings;
using AIO.Core.Entities.AppSettings;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Services.Repositories.AppSettings;
public class AppSettingRepository : GenericRepository<AppSetting>, IAppSettingRepository
{
    public AppSettingRepository(DbContext context) : base(context)
    {
    }
}
