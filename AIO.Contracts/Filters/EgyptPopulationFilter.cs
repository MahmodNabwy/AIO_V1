#nullable disable

using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class EgyptPopulationAdminFilter : Pager
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
