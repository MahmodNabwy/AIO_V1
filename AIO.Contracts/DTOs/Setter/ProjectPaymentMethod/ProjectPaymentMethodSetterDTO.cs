using AIO.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.ProjectPaymentMethod
{
    public class ProjectPaymentMethodSetterDTO
    {
        [JsonIgnore]
        public int ProjectId { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public int AmountConcurrency { get; set; }
        public int TypeId { get; set; }
        
    }
}
