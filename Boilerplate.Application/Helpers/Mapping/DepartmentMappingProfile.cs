using Boilerplate.Contracts.DTOs.Getter.Departments.Department;
using Boilerplate.Contracts.DTOs.Getter.Departments.DepartmentTranslation;
using Boilerplate.Contracts.DTOs.Getter.Departments.DepartmentUser;
using Boilerplate.Contracts.DTOs.Getter.Lookups;
using Boilerplate.Contracts.DTOs.Setter;
using Boilerplate.Contracts.DTOs.Setter.Departments.Department;
using Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentTranslation;
using Boilerplate.Contracts.DTOs.Setter.Departments.DepartmentUser;
using Boilerplate.Core.Entities.Departments;

namespace Boilerplate.Application.Helpers
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
