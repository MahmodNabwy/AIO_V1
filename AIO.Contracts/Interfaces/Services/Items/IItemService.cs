using AIO.Contracts.Features.Items.Commands;
using AIO.Contracts.Interfaces.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Interfaces.Services.Items
{
    public interface IItemService
    {
        Task<IHolderOfDTO> GetAllAsync();
        Task<IHolderOfDTO> SaveAsync(ItemsAddCommand request);
    }
}
