using AIO.Contracts.DTOs.Setter.Files;
using AIO.Contracts.DTOs.Setter.InsuranceCondition;
using AIO.Contracts.DTOs.Setter.ProjectPaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.Projects
{
    public class ProjectRequestSetterDTO
    {
        public ProjectSetterDTO ProjectData { get; set; }
        public List<InsuranceConditionSetterDTO> InsuranceConditions { get; set; }
        public List<ProjectPaymentMethodSetterDTO> ProjectPaymentMethods { get; set; }
         
    }
}
