using AIO.Application.Features.ProjectInsurances.Commands;
using AIO.Application.Services.ProjectInsurances;
using AIO.Contracts.Features.ProjectInsurances.Commands;
using AIO.Contracts.Features.ProjectTaxes.Queries;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.Interfaces.Services.ProjectInsurance;
using AIO.Contracts.Interfaces.Services.ProjectTaxes;
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

namespace AIO.Application.Features.ProjectTaxes.Queries
{
    public class GetAllProjectTaxesQueryHandler : BaseService<GetAllProjectTaxesQueryHandler>, IRequestHandler<GetAllProjectTaxesQuery, IHolderOfDTO>
    {
        private readonly IProjectTaxesService _projectTaxesService;

        public GetAllProjectTaxesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
        ILogger<GetAllProjectTaxesQueryHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IProjectTaxesService projectTaxesService)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _projectTaxesService = projectTaxesService;
        }

        public async Task<IHolderOfDTO> Handle(GetAllProjectTaxesQuery request, CancellationToken cancellationToken)
        {
            return await _projectTaxesService.GetAllAsync(request);
        }
    }
}
