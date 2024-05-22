using AIO.Application.Services.Departments;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.IServices.Services.Departments;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Hangfire.Storage.Monitoring;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectInsurance
{
    public class ProjectInsuranceService : BaseService<ProjectInsuranceService>, IProjectInsuranceService
    {
        public ProjectInsuranceService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectInsuranceService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> AddNewProjectInsurance(int projectId, int insuranceId)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oProjectInsurance = new AIO.Core.Entities.ProjectInsurances.ProjectInsurance();
                oProjectInsurance.CreatedAt = DateTime.Now;
                oProjectInsurance.ProjectId = projectId;
                oProjectInsurance.InsuranceConditionId = insuranceId;
                oProjectInsurance.CreatedBy = GetUserId();                

                var oData = await _unitOfWork.ProjectInsurance.AddAsync(oProjectInsurance);
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _logger.LogInformation(Res.message, Res.Added);                

            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
    }
}
