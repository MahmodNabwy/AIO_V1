using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.SupplierProjectPaymentMethods
{
    public class SupplierProjectSupplierPaymentMethodSetterDTO
    {
        [JsonIgnore]
        public int ProjectId { get; set; }

        [JsonIgnore]
        public int SupplierId { get; set; }
        public int Percentage { get; set; }
        public decimal Amount { get; set; }
        public int currency { get; set; }
        public int TypeId { get; set; }        
        public DateTime Date { get; set; }
    }
}
