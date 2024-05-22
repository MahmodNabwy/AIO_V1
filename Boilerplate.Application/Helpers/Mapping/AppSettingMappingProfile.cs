using Boilerplate.Contracts.DTOs.Getter.AppSettings;
using Boilerplate.Contracts.DTOs.Setter.AppSettings;
using Boilerplate.Core.Entities.AppSettings;

namespace Boilerplate.Application.Helpers
{
    public partial class MappingProfile
    {
        private void AppSettingMappingProfile()
        {
            CreateMap<AppSettingSetterDTO, AppSetting>();

            CreateMap<AppSettingUpdateSetterDTO, AppSetting>();

            CreateMap<AppSetting, AppSettingGetterDTO>();

            CreateMap<AppSetting, AppSettingDataGetterDTO>();

        }
    }
}
