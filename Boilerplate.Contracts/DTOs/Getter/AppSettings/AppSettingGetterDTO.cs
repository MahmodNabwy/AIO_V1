using Boilerplate.Contracts.Bases;
#nullable disable

namespace Boilerplate.Contracts.DTOs.Getter.AppSettings
{
    public class AppSettingGetterDTO : BaseGetterWithUpdateDTO
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
