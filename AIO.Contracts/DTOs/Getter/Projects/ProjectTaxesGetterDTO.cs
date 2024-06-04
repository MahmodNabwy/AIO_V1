using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Projects
{
    public record ProjectTaxesGetterDTO
    {
        public int Id { get; set; }
        public int TaxId { get; set; }
        public string name { get; set; }
    }
}
