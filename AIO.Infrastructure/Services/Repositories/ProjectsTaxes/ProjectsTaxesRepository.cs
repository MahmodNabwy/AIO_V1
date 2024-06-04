using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Core.Entities.ProjectsTaxes;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectsTaxes;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectsTaxes
{
    public class ProjectsTaxesRepository : GenericRepository<ProjectTaxe>, IProjectsTaxesRepository
    {
        private readonly AIODBContext _db;

        public ProjectsTaxesRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
        public async Task<List<ProjectTaxesGetterDTO>> GetListAsync(int projectId)
        {
            var result = await _db.ProjectsTaxes.AsNoTracking()
                                                .Where(c => c.ProjectId == projectId && !c.IsDeleted)
                                                .Select(c => new ProjectTaxesGetterDTO
                                                {
                                                    Id = c.Id,
                                                    name = c.Taxe.Name,
                                                    TaxId = c.TaxId
                                                }).ToListAsync();
            return result;
        }
    }
}
