using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectPaymentMethod.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectPaymentMethods;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
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
    public class ProjectPaymentMethodDeleteCommandHadnler : BaseService<ProjectPaymentMethodDeleteCommandHadnler>, IRequestHandler<ProjectPaymentMethodDeleteCommand, IHolderOfDTO>
    {
        private readonly IProjectPaymentMethodService _projectPaymentMethodService;

        public ProjectPaymentMethodDeleteCommandHadnler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectPaymentMethodDeleteCommandHadnler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectPaymentMethodService projectPaymentMethodService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectPaymentMethodService = projectPaymentMethodService;
        }
        public async Task<IHolderOfDTO> Handle(ProjectPaymentMethodDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _projectPaymentMethodService.DeleteAsync(request.Id);
        }
    }
}
