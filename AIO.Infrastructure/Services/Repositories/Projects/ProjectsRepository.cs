using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.Filters;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using AIO.Core.IServices.Repositories.Owners;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Projects
{
    public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
    {
        private readonly AIODBContext _db;

        public ProjectsRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
        public IQueryable<ProjectsDataGetterDTO> buildFilterQuery(ProjectFilter filter)
        {
            var query = _db.Projects.AsNoTracking()
                                    .Include(q => q.Owner)
                                    .Select(c => new ProjectsDataGetterDTO
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        ContractNumber = c.ContractNumber,
                                        ProjectStatus = c.FinalRecieptDate < DateTime.Now.Date ? "أنتهت" : "مستمرة",
                                        OwnerName = c.Owner.Name,
                                        TotalPrice = c.TotalPrice,
                                        TotalPriceConcurrency = (int)c.TotalPriceConcurrency,
                                        IsNew = c.IsNew
                                    }).AsQueryable();


            if (filter is not null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(filter.Name))
                        query = query.Where(x => x.Name.Contains(filter.Name));

                    if (!string.IsNullOrEmpty(filter.ContractNumber))
                        query = query.Where(x => x.ContractNumber.Contains(filter.ContractNumber));

                    if (!string.IsNullOrEmpty(filter.Owner))

                        query = query.Where(x => x.OwnerName.Contains(filter.Owner));

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return query;

        }
        public IQueryable<ProjectsDataGetterDTO> GetAll()
        {
            var result = _db.Projects.AsNoTracking()
                                     .Where(c => !c.IsDeleted)
                                     .Select(c => new ProjectsDataGetterDTO
                                     {
                                         Id = c.Id,
                                         Name = c.Name,
                                         ContractNumber = c.ContractNumber,
                                         ProjectStatus = c.FinalRecieptDate < DateTime.Now.Date ? "أنتهت" : "مستمرة",
                                         OwnerName = c.Owner.Name,
                                         TotalPrice = c.TotalPrice,
                                         TotalPriceConcurrency = (int)c.TotalPriceConcurrency,
                                         IsNew = c.IsNew
                                     }).AsQueryable();
            return result;
        }
    }
}
