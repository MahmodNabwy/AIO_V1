using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectPaymentMethods;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Helpers;
using AIO.Shared.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Features.ProjectPaymentMethod.Commands
{
    public class ProjectPaymentMethodsUpdateCommandHandler : BaseService<ProjectPaymentMethodsUpdateCommandHandler>, IRequestHandler<ProjectPaymentMethodUpdateCommand, IHolderOfDTO>
    {
        private readonly IProjectPaymentMethodService _projectPaymentMethodService;

        public ProjectPaymentMethodsUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectPaymentMethodsUpdateCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectPaymentMethodService projectPaymentMethodService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectPaymentMethodService = projectPaymentMethodService;
        }
        public async Task<IHolderOfDTO> Handle(ProjectPaymentMethodUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _projectPaymentMethodService.UpdateAsync(request);
        }
    }
}
