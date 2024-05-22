using AIO.Core.Entities;
using AIO.Core.IServices.Custom.Repositories;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Repositories.Custom.Log_System
{
    internal class LogErrorRepository : GenericRepository<LogError>, ILogErrorRepository
    {
        private readonly AIODBContext _db;
        public LogErrorRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
