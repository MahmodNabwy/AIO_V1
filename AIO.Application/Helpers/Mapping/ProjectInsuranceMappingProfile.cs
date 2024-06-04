using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Features.ProjectInsurances.Commands;
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
        private void ProjectInsuranceMappingProfile()
        {
            CreateMap<InsuranceConditionSetterDTO, ProjectInsurance>().ReverseMap();
            CreateMap<ProjectInsurancesAddCommand, ProjectInsurance>().ReverseMap();
            CreateMap<ProjectInsurancesUpdateCommand, ProjectInsurance>().ReverseMap();
        }
    }
}
