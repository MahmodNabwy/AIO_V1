using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.SupplierProjectInsurances;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.SupplierInsurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void SupplierProjectInsuranceMappingProfile()
        {
            CreateMap<SupplierProjectInsurancesSetterDTO, SupplierProjectInsurance>().ReverseMap();
        }
    }
}
