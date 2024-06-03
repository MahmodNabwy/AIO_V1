using AIO.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Getter.Projects
{
    public record ProjectInsurancesDataGetterDTO
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
        public int Period { get; set; }
        public int TypeId { get; set; }
        public int currency { get; set; }
        public decimal? InsuranceLetterValue { get; set; }  
        public bool IsReturned { get; set; }
        public Inusrance_letter_status? StatusId { get; set; } 
    }
}
