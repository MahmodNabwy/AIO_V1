using AIO.Contracts.Bases;
#nullable disable

namespace AIO.Contracts.DTOs.Auth.Getter.Roles.RoleTranslation
{
    public class RoleTranslationGetterDTO : BaseGetterDTO
    {
        public string Name { get; set; }
        public string Locale { get; set; }

    }
}
