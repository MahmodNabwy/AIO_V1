using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.IServices.Repositories.Elements;
using Boilerplate.Core.Entities.Elements;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Services.Repositories.Elements
{
    internal class ElementRepository : GenericRepository<Element>, IElementRepository
    {
        private readonly BoilerplateDBContext _db;
        public ElementRepository(BoilerplateDBContext context) : base(context)
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
