using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Projects.Commands
{
    public class ProjectAddCommand : IRequest<IHolderOfDTO>
    {
        public ProjectSetterDTO ProjectData { get; set; }
        public List<InsuranceConditionSetterDTO> InsuranceConditions { get; set; }
        public List<ProjectPaymentMethodSetterDTO> ProjectPaymentMethods { get; set; }
        public List<int> TaxeIds { get; set; }
    }
}
