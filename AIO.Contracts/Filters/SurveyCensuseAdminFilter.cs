﻿#nullable disable

namespace AIO.Contracts.Filters
{
    public class SurveyCensuseAdminFilter : AdminFilterBase
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public bool? IsInternal { get; set; }
    }
}
