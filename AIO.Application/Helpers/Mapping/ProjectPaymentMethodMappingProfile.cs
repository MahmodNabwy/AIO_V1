using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Core.Entities.ProjectInsurances;
using AIO.Core.Entities.ProjectPaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void ProjectPaymentMethodMappingProfile()
        {
            CreateMap<ProjectPaymentMethodSetterDTO, ProjectPaymentMethod>().ReverseMap();
        }
    }
}
