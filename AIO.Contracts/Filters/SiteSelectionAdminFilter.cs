﻿#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class SiteSelectionAdminFilter : Pager
    {
        public long? Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPublished { get; set; }
        public int? Status { get; set; }
    }
}
