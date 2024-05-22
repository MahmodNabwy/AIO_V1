#nullable disable
using AIO.Contracts.Bases;

namespace AIO.Contracts.DTOs.Auth.Getter
{
    public class LicenceGetterDTO : BaseGetterWithUpdateDTO
    {
        public string PublicKey { get; set; }
        public string LicenceKey { get; set; }
    }
}
