using AIO.Contracts.Helpers;
#nullable disable

namespace AIO.Contracts.Filters
{
    public class AdminFilterBase : Pager
    {
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }
        public bool? IsPublished { get; set; }

    }
}
