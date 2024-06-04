using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
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
            CreateMap<ProjectPaymentMethodAddCommand, ProjectPaymentMethod>().ReverseMap();
            CreateMap<ProjectPaymentMethodUpdateCommand, ProjectPaymentMethod>().ReverseMap();
        }
    }
}
