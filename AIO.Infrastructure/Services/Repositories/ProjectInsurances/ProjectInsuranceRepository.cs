using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.IServices.Repositories.ProjectInsurances;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectInsurances
{
    public class ProjectInsuranceRepository : GenericRepository<ProjectInsurance>, IProjectInsuranceRepository
    {
        private readonly AIODBContext _db;
        public ProjectInsuranceRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
        public async Task<List<ProjectInsurancesDataGetterDTO>> GetListAsync(int projectId)
        {
            var result = await _db.ProjectsInsurances.AsNoTracking()
                                                     .Where(c => c.ProjectId == projectId && !c.IsDeleted)
                                                     .Select(c => new ProjectInsurancesDataGetterDTO
                                                     {
                                                         Id = c.Id,
                                                         Amount = c.Amount,
                                                         currency = (int)c.currency,
                                                         Date = c.Date,
                                                         InsuranceLetterValue = c.InsuranceLetterValue,
                                                         IsReturned = c.IsReturned,
                                                         Percentage = c.Percentage,
                                                         Period = c.Period,
                                                         StatusId = (int)c.StatusId,
                                                         TypeId = (int)c.TypeId,
                                                     })
                                                     .ToListAsync();
            return result;

        }


    }
}
