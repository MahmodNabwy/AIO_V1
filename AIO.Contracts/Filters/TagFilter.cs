#nullable disable

using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class TagFilter : Pager
    {
        public string TagName { get; set; }

    }
    public class TagAdminFilter : TagFilter
    {
        public long? Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
