using AIO.Contracts.Helpers;
#nullable disable

namespace AIO.Contracts.Filters
{
    public class LawRegulationFilter : Pager
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
