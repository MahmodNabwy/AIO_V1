#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class RegionalOfficeFilter : Pager
    {
        public string Name { get; set; }
        public long GovernorateId { get; set; }       
        public bool? isMainLocation { get; set; }

    }
    public class RegionalOfficeAdminFilter : AdminFilterBase
    {
        public string Name { get; set; }
        public long GovernorateId { get; set; }
        public bool isMainLocation { get; set; }

    }
}
