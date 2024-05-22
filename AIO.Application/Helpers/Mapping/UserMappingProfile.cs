using AIO.Contracts.Bases;
using AIO.Contracts.DTOs.Auth.Getter;
using AIO.Contracts.DTOs.Auth.Getter.Users;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Core.Entities;
using AIO.Core.Entities.Auth;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void UserMappingProfile()
        {

            CreateMap<UserRegisterSetterDTO, User>();

            CreateMap<UserSetterDTO, User>().ReverseMap();

            CreateMap<User, UserGetterDTO>()
                .ForMember(d => d.DisplayPath, o => o.MapFrom(s => buildProfileImagePath(s.Path))).ReverseMap();

            CreateMap<User, UserDataGetterDTO>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName));

            CreateMap<User, UserAuthGetterDTO>()
              .ForMember(d => d.FullName, o => o.MapFrom(s => s.FirstName + " " + s.LastName))
              .ForMember(d => d.DisplayPath, o => o.MapFrom(s => buildProfileImagePath(s.Path)));

            CreateMap<User, AdminAuthGetterDTO>()
              .ForMember(d => d.FullName, o => o.MapFrom(s => s.FirstName + " " + s.LastName))
              .ForMember(d => d.DisplayPath, o => o.MapFrom(s => buildProfileImagePath(s.Path)));

            CreateMap<User, UserAdminDataGetterDTO>()
                .ForMember(d => d.Roles, o => o.MapFrom(s => s.UserRoles.Select(q => q.Role)))
                .ForMember(d => d.Departments, o => o.MapFrom(s => s.UserGroups.Select(q => q.Department)))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName));

            CreateMap<User, UserInfoGetterDTO>().ReverseMap();

            CreateMap<BaseEntityWithUpdate, BaseGetterWithUpdateDTO>();

            CreateMap<BaseEntityUpdate, BaseGetterUpdateDTO>();

            CreateMap<ProfilePictureSetterDTO, ProfilePicture>().ReverseMap();

            CreateMap<ProfilePicture, ProfilePictureGetterDTO>();

            CreateMap<User, LookupStringGetterDTO>()
               .ForMember(d => d.Name, o => o.MapFrom(s => s.FullName))
               .ForMember(d => d.Translations, o => o.Ignore());
        }
    }
}
