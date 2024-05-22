using AIO.Core.Entities.Categories;
using AIO.Core.IServices.Repositories.Categories;
using AIO.Core.IServices.Repositories.Suppliers;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Infrastructure.Services.Repositories.Categories
{

    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        private readonly AIODBContext _db;
        public CategoriesRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }
    }
}
