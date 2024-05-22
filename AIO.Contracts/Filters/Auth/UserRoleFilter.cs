using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters.Auth
{
    public class UserRoleFilter : Pager
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
    }
}
