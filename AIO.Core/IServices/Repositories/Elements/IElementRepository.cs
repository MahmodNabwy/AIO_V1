using AIO.Contracts.Filters;
using AIO.Contracts.IServices.Custom;
using AIO.Core.Entities.Elements;

namespace AIO.Contracts.IServices.Repositories.Elements
{
    public interface IElementRepository : IGenericRepository<Element>
    {
        IQueryable<Element> buildFilterAdminQuery(ElementFilter filter);
    }
}