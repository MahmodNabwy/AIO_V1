using AIO.Core.Entities.Items;
using AIO.Core.IServices.Repositories.Item;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Item
{
    public class ItemRepository : GenericRepository<Core.Entities.Items.Item>, IItemRepository
    {
        private readonly AIODBContext _db;

        public ItemRepository(AIODBContext context) : base(context)
        {
            _db = context;

        }
    }
}
