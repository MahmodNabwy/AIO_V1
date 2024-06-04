using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Features.ProjectInsurances.Commands
{
    public class ProjectInsuranceDeleteCommandHadnler : BaseService<ProjectInsuranceDeleteCommandHadnler>, IRequestHandler<ProjectInsuranceDeleteCommand, IHolderOfDTO>
    {
        private readonly IProjectInsuranceService _projectInsuranceService;

        public ProjectInsuranceDeleteCommandHadnler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<ProjectInsuranceDeleteCommandHadnler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectInsuranceService projectInsuranceService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectInsuranceService = projectInsuranceService;
        }
        public async Task<IHolderOfDTO> Handle(ProjectInsuranceDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _projectInsuranceService.DeleteAsync(request.Id);
        }
    }
}
