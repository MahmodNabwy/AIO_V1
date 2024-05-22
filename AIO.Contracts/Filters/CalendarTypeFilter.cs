#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class CalendarTypeFilter : Pager
    {
        public string Type { get; set; }
    }
    public class CalendarTypeAdminFilter : CalendarTypeFilter
    {
        public long? Id { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
