#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class GovernorateFilter : Pager
    {
        public string? Name { get; set; }
    }
    public class GovernorateAdminFilter : AdminFilterBase
    {
        public string? Name { get; set; }
    }
}
