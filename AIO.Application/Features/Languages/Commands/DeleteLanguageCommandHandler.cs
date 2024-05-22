using AutoMapper;
using AIO.Contracts.Features.Languages.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Features.Languages.Commands
{
    public class DeleteLanguageCommandHandler : BaseService<DeleteLanguageCommandHandler>, IRequestHandler<DeleteLanguageCommand, IHolderOfDTO>
    {
        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<DeleteLanguageCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var obj = await _unitOfWork.Language.FirstOrDefaultAsync(q => q.Id == request.Id);
                if (obj != null)
                {
                    if (!obj.IsDefault)
                    {
                        if (!obj.IsSystem)
                        {
                            _unitOfWork.Language.Delete(request.Id);
                            lIndicators.Add(_unitOfWork.Complete() > 0);
                            _logger.LogInformation(Res.message, Res.Deleted);
                        }
                        else
                            ErrorMessage(lIndicators, Res.CannotDeleteSystemData);
                    }
                    else
                        ErrorMessage(lIndicators, Res.CannotDeleteLanguage);
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
