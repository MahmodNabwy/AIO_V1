using AIO.Contracts.Features.SuppliersProjectsItems.Commands;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.SupplierProjectItemServices
{
    public interface ISupplierProjectItemService
    {

        Task<IHolderOfDTO> SaveAsync(SupplierProjectItemsAddCommand request);
    }
}
