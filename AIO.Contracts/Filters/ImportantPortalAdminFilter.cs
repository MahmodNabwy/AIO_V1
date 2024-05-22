using AIO.Contracts.Helpers;
#nullable disable

namespace AIO.Contracts.Filters
{
    public class ImportantPortalAdminFilter : Pager
    {
        public long? Id { get; set; }
        public string Title { get; set; }
    }
}
