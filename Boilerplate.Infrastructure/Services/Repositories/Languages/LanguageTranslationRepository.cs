using Boilerplate.Contracts.IServices.Repositories.Languages;
using Boilerplate.Core.Entities.Languages;
using Boilerplate.Infrastructure.DBContexts;
using Boilerplate.Infrastructure.Services.Custom;

namespace Boilerplate.Infrastructure.Services.Repositories.Languages
{
    internal class LanguageTranslationRepository : GenericRepository<LanguageTranslation>, ILanguageTranslationRepository
    {
        private readonly BoilerplateDBContext _db;
        public LanguageTranslationRepository(BoilerplateDBContext context) : base(context)
        {
            _db = context;
        }

    }
}
