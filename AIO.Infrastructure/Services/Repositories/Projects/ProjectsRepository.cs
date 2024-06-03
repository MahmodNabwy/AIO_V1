using AIO.Contracts.DTOs.Getter.Projects;
using AIO.Contracts.Features.Projects.Queries;
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
                                        currency = (int)c.currency,
                                        IsNew = c.IsNew,
                                        IsConfirmed = c.IsConfirmed,
                                        IncludeTaxes = c.IncludeTaxes,
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
                                         currency = (int)c.currency,
                                         IsNew = c.IsNew,
                                         IsConfirmed = c.IsConfirmed,
                                         IncludeTaxes = c.IncludeTaxes,
                                     }).AsQueryable();
            return result;
        }

        public async Task<List<ProjectDateGetterByIdDTO>> GetByIdAsync(GetProjectByIdQuery request)
        {
            var result = await _db.Projects.AsNoTracking()
                                     .Where(c => c.Id == request.ProjectId)
                                     .Select(c => new ProjectDateGetterByIdDTO
                                     {
                                         Id = c.Id,
                                         Name = c.Name,
                                         ContractNumber = c.ContractNumber,
                                         OwnerName = c.Owner.Name,
                                         TotalPrice = c.TotalPrice,
                                         currency = (int)c.currency,
                                         IsNew = c.IsNew,
                                         AssignedNumber = c.AssignedNumber,
                                         AssignedToDate = c.AssignedToDate,
                                         FinalRecieptDate = c.FinalRecieptDate,
                                         HasDiscount = c.HasDiscount,
                                         ImplementationPeriod = c.ImplementationPeriod,
                                         InsurancePeriod = c.InsurancePeriod,
                                         LimitOfLiability = c.LimitOfLiability,
                                         OwnerId = c.OwnerId,
                                         ParentId = c.ParentId,
                                         PaymentCondition = c.PaymentCondition,
                                         PoNumber = c.PoNumber,
                                         PrimaryRecieptDate = c.PrimaryRecieptDate,
                                         ProjectTypeId = (int)c.ProjectTypeId,
                                         ProjectProfitabilityRatio = c.ProjectProfitabilityRatio,
                                         TotalPriceAfterDiscount = c.TotalPriceAfterDiscount,
                                         Insurances = c.ProjectInsurances.Select(x => new ProjectInsurancesDataGetterDTO
                                         {
                                             Amount = x.Amount,
                                             currency = (int)x.currency,
                                             Date = x.Date,
                                             Id = x.Id,
                                             InsuranceLetterValue = x.InsuranceLetterValue,

                                             Percentage = x.Percentage,
                                             Period = x.Period,
                                             StatusId = x.StatusId,
                                             TypeId = (int)x.TypeId
                                         }).ToList(),
                                         Taxes = c.IncludeTaxes == true ? c.ProjectTaxes.Select(x => new ProjectTaxesGetterDTO
                                         {
                                             Id = x.Id,
                                             TaxId = x.TaxId
                                         }).ToList() : null,
                                         PaymentMethods = c.ProjectPaymentMethods.Select(x => new ProjectPaymentMethodGetterDTO
                                         {
                                             Id = x.Id,
                                             Amount = x.Amount,
                                             currency = (int)x.currency,
                                             Date = x.Date,
                                             Percentage = x.Percentage,
                                             TypeId = (int)x.TypeId,
                                         }).ToList()
                                     }).ToListAsync();
            return result;
        }
    }
}
