#nullable disable
using AIO.Contracts.Bases;
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class JournalismFilter : Pager
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? JournalName { get; set; }
        public string? Title { get; set; }
    }
    public class JournalismAdminFilter : AdminFilterBase
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? JournalName { get; set; }
        public string? Title { get; set; }
    }
}
