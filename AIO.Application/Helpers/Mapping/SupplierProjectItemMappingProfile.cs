using AIO.Contracts.DTOs.Setter.SupplierProjectPaymentMethods;
using AIO.Contracts.Features.SuppliersProjectsItems.Commands;
using AIO.Core.Entities.SupplierItems;
using AIO.Core.Entities.SupplierPaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile
    {
        private void SupplierProjectItemMappingProfile()
        {
            CreateMap<SupplierProjectItemsAddCommand, SupplierProjectItem>().ReverseMap();
        }
    }
}
