using AIO.Contracts.IServices.Repositories.Migrations;
using AIO.Core.Entities.Migrations;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Services.Repositories.Migrations
{
    public class MigrationRepository : GenericRepository<Migration>, IMigrationRepository
    {
        public MigrationRepository(DbContext context) : base(context)
        {
        }
    }
}
