using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectPaymentMethods;
using AIO.Core.Bases;
using AIO.Core.Entities.ProjectPaymentMethods;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.ProjectPaymentMethods
{
    public class ProjectPaymentMethodService : BaseService<ProjectPaymentMethodService>, IProjectPaymentMethodService
    {
        public ProjectPaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectPaymentMethodService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }
        public async Task<IHolderOfDTO> AddNewProjectPaymentMethod(int projectId, ProjectPaymentMethodSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oProjectPaymentMethod = new ProjectPaymentMethod();
                oProjectPaymentMethod.CreatedAt = DateTime.Now;
                oProjectPaymentMethod.CreatedBy = GetUserId();
                oProjectPaymentMethod.ProjectId = projectId;
                oProjectPaymentMethod.TypeId = (Contracts.Enums.PaymentMethodTypes)setterDTO.TypeId;
                oProjectPaymentMethod.Amount = setterDTO.Amount;
                oProjectPaymentMethod.AmountConcurrency = (Contracts.Enums.Concurrency_type)setterDTO.AmountConcurrency;
                oProjectPaymentMethod.Percentage = setterDTO.Percentage;

                var oData = await _unitOfWork.ProjectPaymentMethod.AddAsync(oProjectPaymentMethod);
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
