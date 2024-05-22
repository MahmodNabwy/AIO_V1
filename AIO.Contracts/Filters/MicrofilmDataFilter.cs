﻿#nullable disable

using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters
{
    public class MicrofilmDataFilter : Pager
    {
        public string AgencyName { get; set; }
        public long? AgencyTypeId { get; set; }
        public long? FilmTypeId { get; set; }
        public int? FilmCount { get; set; }

    }
}
