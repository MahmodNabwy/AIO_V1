using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectInsurances.Queries;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Application.Features.ProjectInsurances.Queries
{
    public class GetAllProjectInsurancesQueryHandler : BaseService<GetAllProjectInsurancesQueryHandler>, IRequestHandler<GetAllProjectInsurancesQuery, IHolderOfDTO>
    {
        private readonly IProjectInsuranceService _projectInsuranceService;

        public GetAllProjectInsurancesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<GetAllProjectInsurancesQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectInsuranceService projectInsuranceService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectInsuranceService = projectInsuranceService;
        }

        public async Task<IHolderOfDTO> Handle(GetAllProjectInsurancesQuery request, CancellationToken cancellationToken)
        {
            return await _projectInsuranceService.GetAllAsync(request);
        }
    }
}
