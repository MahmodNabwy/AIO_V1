using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.ProjectInsurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void OwnerMappingProfile()
        {
            CreateMap<Owner, LookupGetterDTO>().ReverseMap();
        }
    }
}
