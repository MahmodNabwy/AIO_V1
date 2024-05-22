using System.ComponentModel.DataAnnotations;

namespace AIO.Contracts.DTOs.Auth.Setter.Roles.RoleUser
{
    public class RoleUserSetterDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }


    }
}
