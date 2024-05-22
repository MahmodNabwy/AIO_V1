using AutoMapper;
using AIO.Contracts.Features.Languages.DTOs.Getter.Language;
using AIO.Contracts.Features.Languages.Queries;
using AIO.Contracts.Interfaces.Custom;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Features.Languages.Queries
{
    public class GetAllAdminLanguagesQueryHandler : BaseService<GetAllAdminLanguagesQueryHandler>, IRequestHandler<GetAllAdminLanguagesQuery, IHolderOfDTO>
    {
        public GetAllAdminLanguagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<GetAllAdminLanguagesQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(GetAllAdminLanguagesQuery request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FindAllAsync(new[] { "LanguageTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LanguageGetterDTO>>(query.ToList()));
                _logger.LogInformation(Res.message, Res.DataFetch);
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
    }
}
