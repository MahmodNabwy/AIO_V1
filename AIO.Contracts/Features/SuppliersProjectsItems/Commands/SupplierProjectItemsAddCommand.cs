using AIO.Contracts.DTOs.Setter.SupplierProjectItems;
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
        public List<SupplierProjectItemsSetterDTO> items { get; set; }

    }
}
