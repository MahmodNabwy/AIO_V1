using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Suppliers.Queries
{
    public class GetSupplierLookUpQuery : IRequest<IHolderOfDTO>
    {
        public int TypeId { get; set; }
    }
}
