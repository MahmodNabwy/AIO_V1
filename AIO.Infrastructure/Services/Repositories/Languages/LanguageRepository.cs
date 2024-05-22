using AIO.Contracts.IServices.Repositories.Languages;
using AIO.Core.Entities.Languages;
using AIO.Infrastructure.DBContexts;
using AIO.Infrastructure.Services.Custom;

namespace AIO.Infrastructure.Services.Repositories.Languages
{
    internal class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        private readonly AIODBContext _db;
        public LanguageRepository(AIODBContext context) : base(context)
        {
            _db = context;
        }

    }
}
