#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class EventTypeFilter : Pager
    {
        public string Name { get; set; }

    }
    public class EventTypeAdminFilter : EventTypeFilter
    {
        public long? Id { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPublished { get; set; }
        public int? Status { get; set; }

    }
}
