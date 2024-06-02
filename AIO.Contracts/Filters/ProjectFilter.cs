using AIO.Contracts.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Filters
{
    public class ProjectFilter : Pager
    {
        public string? Name { get; set; }
        public string? ContractNumber { get; set; }
        public string? Owner { get; set; }
    }
}
