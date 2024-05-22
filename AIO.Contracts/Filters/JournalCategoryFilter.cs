#nullable disable
using AIO.Contracts.Bases;
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class JournalCategoryFilter : Pager
    {
        public string? Name { get; set; }
    }
    public class JournalCategoryAdminFilter : AdminFilterBase
    {
        public string? Name { get; set; }
    }
}
