using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.DTOs.Setter.Departments.Department;
using AIO.Contracts.DTOs.Setter.Projects;
using AIO.Contracts.Features.Projects.Commands;
using AIO.Core.Entities.Departments;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void ProjectMappingProfile()
        {
            CreateMap<ProjectSetterDTO, Project>().ReverseMap();

            CreateMap<ProjectUpdateCommand, Project>().ReverseMap();

            CreateMap<Project, LookupGetterDTO>().ReverseMap();

        }

    }
}
