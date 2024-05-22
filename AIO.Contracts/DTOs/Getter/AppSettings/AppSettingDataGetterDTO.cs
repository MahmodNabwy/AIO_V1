using AIO.Contracts.Bases;
#nullable disable

namespace AIO.Contracts.DTOs.Getter.AppSettings
{
    public class AppSettingDataGetterDTO : BaseGetterDTO
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
