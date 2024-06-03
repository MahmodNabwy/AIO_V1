using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.ProjectSupplier
{
    public class ProjectSupplierDataDTO
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public int InsurancesLettersCount { get; set; }
        public decimal? InsurancesLettersTotal { get; set; }
    }
}
