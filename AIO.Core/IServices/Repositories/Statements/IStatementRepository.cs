using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Statements
{
    public interface IStatementRepository : IGenericRepository<Statement>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);
    }
}
