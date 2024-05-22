using Boilerplate.Contracts.IServices.Repositories.Elements;
using Boilerplate.Core.Entities.Elements;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories.Elements
{
    internal class ElementTranslationRepository : GenericRepository<ElementTranslation>, IElementTranslationRepository
    {
        private readonly BoilerplateDBContext _db;
        public ElementTranslationRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }


    }
}
