using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.DTOs.Setter.ProjectSupplier;
using AIO.Core.Entities.ProjectSuppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void ProjectSupplierMappingProfile()
        {
            CreateMap<ProjectSupplierDataSetterDTO, ProjectSupplier>().ReverseMap();
        }
    }
}
