using AIO.Contracts.IServices.Repositories.Elements;
using AIO.Core.Entities.Elements;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Elements
{
    internal class ElementTranslationRepository : GenericRepository<ElementTranslation>, IElementTranslationRepository
    {
        private readonly AIODBContext _db;
        public ElementTranslationRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }


    }
}
