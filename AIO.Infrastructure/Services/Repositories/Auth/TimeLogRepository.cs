using AIO.Contracts.IServices.Repositories.Auth;
using AIO.Core.Entities.Auth;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Auth
{
    public class TimeLogRepository : GenericRepository<TimeLog>, ITimeLogRepository
    {
        private readonly AIODBContext _db;
        public TimeLogRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }
        //public async Task<TimeLog> GetLastCheckDate()
        //{
        //    //return await _db.TimeLogs.OrderByDescending(q => q.Id).FirstOrDefaultAsync();
        //}
    }
}
