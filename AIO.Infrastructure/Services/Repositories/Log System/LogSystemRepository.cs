using AIO.Core.Entities;
using AIO.Core.IServices.Custom.Repositories;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Repositories.Custom.Log_System
{
    internal class LogSystemRepository : GenericRepository<LogSystem>, ILogSystemRepository
    {
        private readonly AIODBContext _db;
        public LogSystemRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
