using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.InsuranceCondition
{
    public interface IInsuranceConditionService
    {
        Task<int> AddInsuranceCondition(InsuranceConditionSetterDTO setterDTO);
    }
}
