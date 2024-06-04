using AIO.Contracts.DTOs.Getter.Items;
using AIO.Core.Entities.Invoices;
using AIO.Core.Entities.Items;
using AIO.Core.IServices.Repositories.Invoices;
using AIO.Core.IServices.Repositories.Items;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Items
{
    public class ItemsRepository : GenericRepository<Item>, IItemsRepository
    {
        private readonly AIODBContext _db;

        public ItemsRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
        public async Task<List<ItemGetterDTO>> GetAllAsync()
        {
            var result = await _db.Items.AsNoTracking()
                                        .Where(c => !c.IsDeleted)
                                        .Select(c=> new ItemGetterDTO
                                        {
                                            Id = c.Id,
                                            Code = c.Code,  
                                            Description= c.Description
                                        })
                                        .ToListAsync();
            return result;
        }
    }
}
