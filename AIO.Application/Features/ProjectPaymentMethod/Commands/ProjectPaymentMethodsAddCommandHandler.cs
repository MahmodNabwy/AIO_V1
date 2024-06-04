using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectPaymentMethods;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Features.ProjectPaymentMethod.Commands
{
    public class ProjectPaymentMethodsAddCommandHandler : BaseService<ProjectPaymentMethodsAddCommandHandler>, IRequestHandler<ProjectPaymentMethodAddCommand, IHolderOfDTO>
    {
        private readonly IProjectPaymentMethodService _projectPaymentMethodService;

        public ProjectPaymentMethodsAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectPaymentMethodsAddCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectPaymentMethodService projectPaymentMethodService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectPaymentMethodService = projectPaymentMethodService;
        }
        public async Task<IHolderOfDTO> Handle(ProjectPaymentMethodAddCommand request, CancellationToken cancellationToken)
        {
            return await _projectPaymentMethodService.SaveAsync(request);
        }
    }
}
