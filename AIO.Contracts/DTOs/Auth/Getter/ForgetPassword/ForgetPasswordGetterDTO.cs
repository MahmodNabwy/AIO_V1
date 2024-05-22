#nullable disable

namespace AIO.Contracts.DTOs.Auth.Getter.ForgetPassword
{
    public class ForgetPasswordGetterDTO
    {
        public string UserId { get; set; }
        public DateTime ResetTime { get; set; }
    }
}
