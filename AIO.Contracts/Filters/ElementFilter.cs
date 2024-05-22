using AIO.Contracts.Helpers;
#nullable disable

namespace AIO.Contracts.Filters
{
    public class ElementFilter : Pager
    {
        public long? Id { get; set; }
        public string Key { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
