using AIO.Contracts.DTOs.Getter.Departments.Department;
using AIO.Contracts.DTOs.Getter.Departments.DepartmentTranslation;
using AIO.Contracts.DTOs.Getter.Departments.DepartmentUser;
using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.DTOs.Setter;
using AIO.Contracts.DTOs.Setter.Departments.Department;
using AIO.Contracts.DTOs.Setter.Departments.DepartmentTranslation;
using AIO.Contracts.DTOs.Setter.Departments.DepartmentUser;
using AIO.Core.Entities.Departments;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void DepartmentMappingProfile()
        {
            #region Department

            CreateMap<DepartmentSetterDTO, Department>().ReverseMap();

            CreateMap<DepartmentUpdateSetterDTO, Department>().ReverseMap();

            CreateMap<Department, DepartmentGetterDTO>();

            CreateMap<Department, DepartmentDataGetterDTO>();

            CreateMap<Department, LookupGetterDTO>()
                .ForMember(d => d.Translations, o => o.MapFrom(x => x.DepartmentTranslations));

            #endregion

            #region Department Translation

            CreateMap<DepartmentTranslationSetterDTO, DepartmentTranslation>().ReverseMap();

            CreateMap<DepartmentTranslationUpdateSetterDTO, DepartmentTranslation>().ReverseMap();

            CreateMap<DepartmentTranslation, DepartmentTranslationGetterDTO>();

            CreateMap<DepartmentTranslation, DepartmentTranslationDataGetterDTO>();

            CreateMap<DepartmentTranslation, LookupTranslationGetterDTO>();

            #endregion 

            CreateMap<DepartmentUserSetterDTO, DepartmentUser>();

            CreateMap<DepartmentUserUpdateDataSetterDTO, DepartmentUser>();

            CreateMap<DepartmentUserUpdateSetterDTO, DepartmentUser>();

            CreateMap<DepartmentUserBatchSetterDTO, DepartmentUser>();

            CreateMap<DepartmentUser, DepartmentUserGetterDTO>()
                .ForMember(d => d.UserName, o => o.MapFrom(x => x.User.FullName))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(x => x.Department.Name));

        }
    }
}
