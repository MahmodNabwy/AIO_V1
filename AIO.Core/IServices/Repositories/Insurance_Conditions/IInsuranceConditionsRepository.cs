using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Insurance_conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Insurance_Conditions
{
    public interface IInsuranceConditionsRepository : IGenericRepository<Insurance_Condition>
    {
        //IQueryable<Supplier> buildFilterAdminQuery(SectorFilter filter);
        //Task<int> AddNewInsuranceCondition(InsuranceConditionSetterDTO setterDTO);
    }
}
