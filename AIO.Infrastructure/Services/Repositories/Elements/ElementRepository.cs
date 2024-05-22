using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Repositories.Elements;
using AIO.Core.Entities.Elements;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Services.Repositories.Elements
{
    internal class ElementRepository : GenericRepository<Element>, IElementRepository
    {
        private readonly AIODBContext _db;
        public ElementRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

        public IQueryable<Element> buildFilterAdminQuery(ElementFilter filter)
        {
            var query = _db.Elements
                .Include(q => q.ElementTranslations)
                .AsQueryable();
            if (filter is not null)
            {
                try
                {
                    if (filter.Id != null && filter.Id > 0)
                        query = query.Where(x => x.ElementTranslations.Any(q => q.Id == filter.Id) || x.Id == filter.Id);

                    if (!string.IsNullOrEmpty(filter.Key))
                        query = query.Where(x => x.key.Contains(filter.Key));

                    if (filter.IsDeleted != null)
                        query = query.Where(x => x.IsDeleted == filter.IsDeleted);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return query.OrderBy(q => q.key);
        }
    }
}
