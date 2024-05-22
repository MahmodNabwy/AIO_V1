using AIO.Core.Entities.Statements;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.Statements;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Statements
{
    public class StatementRepository : GenericRepository<Statement>, IStatementRepository
    {
        private readonly AIODBContext _db;
        public StatementRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
