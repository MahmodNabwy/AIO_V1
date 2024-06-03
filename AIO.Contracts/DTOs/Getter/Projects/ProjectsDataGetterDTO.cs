using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Projects
{
    public class ProjectsDataGetterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string ContractNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public int currency { get; set; }
        public string ProjectStatus { get; set; }
        public bool IsNew { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public bool IncludeTaxes { get; set; }



    }
}
