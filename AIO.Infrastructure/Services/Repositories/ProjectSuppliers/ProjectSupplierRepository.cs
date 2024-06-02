using AIO.Contracts.DTOs.Getter.ProjectSupplier;
using AIO.Contracts.Enums;
using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.IServices.Repositories.Projects;
using AIO.Core.IServices.Repositories.ProjectSuppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Hangfire.Storage.Monitoring;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.ProjectSuppliers
{
    public class ProjectSupplierRepository : GenericRepository<ProjectSupplier>, IProjectSupplierRepository
    {
        private readonly AIODBContext _db;
        public ProjectSupplierRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }

        public IQueryable<ProjectSupplierDataDTO> GetAll(int projectId, int supplierTypeId)
        {
            var NothingLetterValue = (int)Contracts.Enums.Inusrance_letter_status.Nothing;

            var result = (from q in _db.ProjectSuppliers.AsNoTracking()
                          where q.ProjectId == projectId && (int)q.Supplier.TypeId == supplierTypeId

                          select new ProjectSupplierDataDTO
                          {
                              Id = q.Id,
                              SupplierId = q.SupplierId,
                              Name = q.Supplier.Name,
                              ContractNumber = q.ContractNumber,
                              TotalPrice = q.TotalPrice,
                              //InsurancesLettersTotal =
                              InsurancesLettersCount = q.Project.SupplierProjectInsurances
                              .Where(c => c.SupplierId == q.SupplierId && (int)c.StatusId != NothingLetterValue)
                              .Select(c => c.StatusId).Count(),       

                          }).AsQueryable();
            return result;
        }
    }
}
