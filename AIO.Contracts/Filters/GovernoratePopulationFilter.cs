#nullable disable

using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class GovernoratePopulationFilter
    {
        public long GovernorateId { get; set; }
        public DateTime Date { get; set; }
    }
    public class GovernoratePopulationAdminFilter : Pager
    {
        public long GovernorateId { get; set; }
        public DateTime? Date { get; set; }
    }
}
