using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.SupplierProjectItems
{
    public class SupplierProjectItemsSetterDTO
    {
        public int ProjectId { get; set; }
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; } // (سعر الوحدة * الكمية)
    }
}
