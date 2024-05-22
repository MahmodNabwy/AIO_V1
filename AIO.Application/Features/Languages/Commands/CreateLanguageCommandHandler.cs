using AutoMapper;
using AIO.Contracts.Features.Languages.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Core.Bases;
using AIO.Core.Entities.Languages;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Features.Languages.Commands
{
    public class CreateLanguageCommandHandler : BaseService<CreateLanguageCommandHandler>, IRequestHandler<CreateLanguageCommand, IHolderOfDTO>
    {
        public CreateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<CreateLanguageCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oData = await _unitOfWork.Language.AddAsync(_mapper.Map<Language>(request));
                lIndicators.Add(_unitOfWork.Complete() > 0);
                _holderOfDTO.Add(Res.id, oData.Id);
                _logger.LogInformation(Res.message, Res.Added);
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
