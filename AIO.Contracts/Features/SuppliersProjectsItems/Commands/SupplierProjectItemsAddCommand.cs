using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.SuppliersProjectsItems.Commands
{
    public class SupplierProjectItemsAddCommand : IRequest<IHolderOfDTO>
    {
        public int ProjectId { get; set; }
        public int SupplierId { get; set; }        
        public string Code { get; set; } //AIO Code
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; } // (سعر الوحدة * الكمية)

    }
}
