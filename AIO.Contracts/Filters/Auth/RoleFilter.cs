using AIO.Contracts.Helpers;
using Microsoft.AspNetCore.Identity;

namespace AIO.Contracts.Filters.Auth
{
    public class RoleFilter : Pager
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
