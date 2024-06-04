using AIO.Contracts.DTOs.Getter.Items;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Invoices;
using AIO.Core.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.IServices.Repositories.Items
{
    public interface IItemsRepository : IGenericRepository<Item>
    {
        Task<List<ItemGetterDTO>> GetAllAsync();
    }
}
