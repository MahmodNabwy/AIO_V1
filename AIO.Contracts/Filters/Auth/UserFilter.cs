﻿using AIO.Contracts.Enums;
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters.Auth
{
    public class UserFilter : Pager
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public bool? IsBanned { get; set; }
        public string? Address { get; set; }

    }
}
