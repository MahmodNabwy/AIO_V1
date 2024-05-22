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
    public class GetLanguageQueryHandler : BaseService<GetLanguageQueryHandler>, IRequestHandler<GetLanguageByIdQuery, IHolderOfDTO>
    {
        public GetLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<GetLanguageQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == request.Id, new[] { "LanguageTranslations" });
                if (query != null)
                {
                    _holderOfDTO.Add(Res.Response, _mapper.Map<LanguageDataGetterDTO>(query));
                    _logger.LogInformation(Res.message, Res.DataFetch);
                    lIndicators.Add(true);
                }
                else
                    NotFoundError(lIndicators);
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
