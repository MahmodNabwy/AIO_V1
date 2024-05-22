using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.IServices.Custom;
using Boilerplate.Core.Entities.Elements;

namespace Boilerplate.Contracts.IServices.Repositories.Elements
{
    public interface IElementRepository : IGenericRepository<Element>
    {
        IQueryable<Element> buildFilterAdminQuery(ElementFilter filter);
    }
}