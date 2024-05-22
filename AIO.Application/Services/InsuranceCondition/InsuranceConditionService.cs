using AIO.Application.Services.ProjectInsurance;
using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.InsuranceCondition;
using AIO.Core.Bases;
using AIO.Core.Entities.Insurance_conditions;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Services.InsuranceCondition
{
    public class InsuranceConditionService : BaseService<InsuranceConditionService>, IInsuranceConditionService
    {

        public InsuranceConditionService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<InsuranceConditionService> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }
        public async Task<int> AddInsuranceCondition(InsuranceConditionSetterDTO setterDTO)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                if (setterDTO is not null)
                {
                    var oData = await _unitOfWork.InsuranceCondition.AddAsync(_mapper.Map<Insurance_Condition>(setterDTO));
                    if (_unitOfWork.Complete() > 0)
                    {
                        lIndicators.Add(true);
                        _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
                        return oData.Id;

                    }
                    return 0;

                }
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
                return 0;
            }
            return 0;
        }
    }
}
