using AIO.Contracts.DTOs.Getter.AppSettings;
using AIO.Contracts.DTOs.Setter.AppSettings;
using AIO.Core.Entities.AppSettings;

namespace AIO.Application.Helpers
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
