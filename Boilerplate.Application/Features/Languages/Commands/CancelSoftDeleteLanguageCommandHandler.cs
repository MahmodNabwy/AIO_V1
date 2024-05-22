using AutoMapper;
using Boilerplate.Contracts.Features.Languages.Commands;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Core.Bases;
using Boilerplate.Core.IServices.Custom;
using Boilerplate.Shared.Consts;
using Boilerplate.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Boilerplate.Application.Features.Languages.Commands
{
    public class CancelSoftDeleteLanguageCommandHandler : BaseService<CancelSoftDeleteLanguageCommandHandler>, IRequestHandler<CancelSoftDeleteLanguageCommand, IHolderOfDTO>
    {
        public CancelSoftDeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<CancelSoftDeleteLanguageCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(CancelSoftDeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == request.Id);
                if (obj != null)
                {
                    await _unitOfWork.Language.CancelDeleteSoftAsync(obj);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _logger.LogInformation(Res.message, Res.cancelSoftDeleted);
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
