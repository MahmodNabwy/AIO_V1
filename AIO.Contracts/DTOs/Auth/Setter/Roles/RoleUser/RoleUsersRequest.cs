using System.ComponentModel.DataAnnotations;

namespace AIO.Contracts.DTOs.Auth.Setter.Roles.RoleUser
{
    public class RoleUsersRequest
    {
        [Required]
        public string UserId { get; set; }

        public List<string> RoleIds { get; set; }

    }
}
