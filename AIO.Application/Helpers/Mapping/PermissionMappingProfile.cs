﻿using AIO.Contracts.DTOs.Getter;
using AIO.Contracts.DTOs.Setter;
using AIO.Core.Entities;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void PermissionMappingProfile()
        {

            CreateMap<PermissionModuleSetterDTO, PermissionModule>().ReverseMap();
            CreateMap<PermissionModuleUpdateSetterDTO, PermissionModule>().ReverseMap();
            CreateMap<PermissionModule, PermissionModuleGetterDTO>();
            CreateMap<RolePermissionSetterDTO, RolePermission>().ReverseMap();
            CreateMap<RolePermissionUpdateDTO, RolePermission>().ReverseMap();
            CreateMap<RolePermission, RolePermissionGetterDTO>()
            .ForMember(d => d.RoleName, o => o.MapFrom(x => x.Role == null ? "" : x.Role.Name))
            .ForMember(d => d.ModuleName, o => o.MapFrom(x => x.Module == null ? "" : x.Module.Name));

        }
    }
}
