using AIO.Contracts.Helpers;
#nullable disable

namespace AIO.Contracts.Filters
{
    public class EgyptStatisticsJournalAdminFilter : Pager
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? Number { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }
    }
}
