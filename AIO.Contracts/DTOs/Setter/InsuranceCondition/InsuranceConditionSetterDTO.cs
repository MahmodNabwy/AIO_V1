using AIO.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.InsuranceCondition
{
    public class InsuranceConditionSetterDTO
    {
        [JsonIgnore]
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
        public int Period { get; set; }
        public int currency { get; set; }
        public int StatusId { get; set; }
        public bool IsReturned { get; set; }

        public decimal? InsuranceLetterValue { get; set; }

    }
}
