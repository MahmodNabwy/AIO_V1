using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.IServices.Repositories.ProjectInsurances;
using AIO.Core.IServices.Repositories.ProjectPaymentMethods;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectPaymentMethods
{
    public class ProjectPaymentMethodRepository : GenericRepository<ProjectPaymentMethod>, IProjectPaymentMethodRepository
    {
        private readonly AIODBContext _db;

        public ProjectPaymentMethodRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }


        public async Task<List<ProjectPaymentMethodGetterDTO>> GetListAsync(int projectId)
        {
            var result = await _db.ProjectsPaymentMethods.AsNoTracking()
                                                                 .Where(c => c.ProjectId == projectId && !c.IsDeleted)
                                                                 .Select(c => new ProjectPaymentMethodGetterDTO
                                                                 {
                                                                     Id = c.Id,
                                                                     Amount = c.Amount,
                                                                     currency = (int)c.currency,
                                                                     TypeId = (int)c.TypeId,
                                                                     Date = c.Date,
                                                                     Percentage = c.Percentage
                                                                 })
                                                                 .ToListAsync();
            return result;
        }
    }
}
