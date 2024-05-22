﻿#nullable disable
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class WebsiteTypeFilter : Pager
    {
        public long? Id { get; set; }
        public string Title { get; set; }


    }
    public class WebsiteTypeAdminFilter : WebsiteTypeFilter
    {
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }
    }
}
